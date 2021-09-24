using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMS.Data.Models;
using MMS.Data.Repositories;
using MMS.Data.Security;




namespace MMS.Data.Services
{
    public class PatientServiceDb : IPatientService
    {
        private readonly DatabaseContext db;

        public PatientServiceDb()
        {
            db = new DatabaseContext();
        }

        public void Initialise()
        {
            db.Initialise();
        }

        // -------------------------- Patient Related Operations ------------------------------

        // retrieve list of Patients
        public IList<Patient> GetPatients()
        {
            // return the collection as a list
            return db.Patients.ToList();
        }

        // Retrieve patient by Id
        public Patient GetPatient(int id)
        {
            return db.Patients
                     .Include(p => p.Medicines)
                     .FirstOrDefault(p => p.Id == id);
        }

        // Add a new patient checking a patient with the same email doesn't exist
        public Patient AddPatient(string name, string email, int age)
        {
            // check if email is already in use by another patient
            var existing = GetPatientByEmail(email);
            if (existing != null)
            {
                return null; // email in use so we cannot create patient
            }
            // email is unique so go ahead and create patient
            var p = new Patient
            {
                // Id is automatically set by the database
                Name = name,
                Email = email,
                Age = age
            };

            db.Patients.Add(p);
            db.SaveChanges(); // write to database

            return p; // return newly added patient
        }

        // Delete the patient identified by Id returning true if deleted and false if not found
        public bool DeletePatient(int id)
        {
            var p = GetPatient(id);
            if (p == null)
            {
                return false;
            }

            db.Patients.Remove(p);
            db.SaveChanges(); // write to database
            return true;
        }

        // Update the patient with the details in updated
        public Patient UpdatePatient(Patient updated)
        {
            // verfidy the patient exists
            var patient = GetPatient(updated.Id);
            if (patient == null)
            {
                return null;
            }

            // update the details of the patient retrieved and save
            patient.Name = updated.Name;
            patient.Email = updated.Email;
            patient.Age = updated.Age;

            db.SaveChanges(); // write to database
            return patient;
        }

        public Patient GetPatientByEmail(string email)
        {
            return db.Patients.FirstOrDefault(p => p.Email == email);
        }

        public IList<Patient> GetPatientsScript(Func<Patient, bool> s)
        {
            return db.Patients
                     .Include(p => p.Medicines)
                     .Where(s).ToList();
        }

        public bool IsDuplicateEmail(string email, int patientId)
        {
            var existing = GetPatientByEmail(email);
            // if a patient with email exists and the Id does not match
            // the patientId (if provided), then they cannot use the email

            return existing != null & patientId != existing.Id;
        }

        // ----------------------------- Medicine Management ------------------------------

        public Medicine CreateMedicine(int patientId, string medicineName)
        {
            var patient = GetPatient(patientId);
            if (patient == null) return null;

            var medicine = new Medicine
            {
                // Id created by Database
                MedicineName = medicineName,
                PatientId = patientId,

                // set by default in model but we can override here if required 
                CreatedOn = DateTime.Now,
                Active = true
            };

            patient.Medicines.Add(medicine);
            db.SaveChanges(); // write to database

            return medicine;
        }

        // return medicine nad realted patient
        public Medicine GetMedicine(int id)
        {
            return db.Medicines
                     .Include(m => m.Patient)
                     .FirstOrDefault(m => m.Id == id);
        }

        // Closed the specified medicine request - must exist and not already closed 
        public Medicine CloseRequest(int id, string resolution)
        {
            var medicine = GetMedicine(id);
            // if medicine request does not exist or is already closed return null
            if (medicine == null || medicine.Active == false) return null;

            // medicine request exists and is active so close
            medicine.Active = false;
            medicine.Resolution = resolution;
            medicine.ResolvedOn = DateTime.Now;

            db.SaveChanges(); // write to database
            return medicine; // return closed ticket
        }

        // delete speciied medicine request returning true if successful otherwise false
        public bool DeleteMedicine(int id)
        {
            // find medicine
            var medicine = GetMedicine(id);
            if (medicine == null) return false;

            // remove medicine request from patient
            var result = medicine.Patient.Medicines.Remove(medicine);

            db.SaveChanges();

            return result;
        }

        // return all medicine requests and the patient generating the request
        public IList<Medicine> GetAllMedicines()
        {
            var medicines = db.Medicines
                              .Include(m => m.Patient)
                              .ToList();
            return medicines;
        }

        public IList<Medicine> GetOpenMedicineRequests()
        {
            return db.Medicines
                     .Include(m => m.Patient)
                     .Where(m => m.Active)
                     .ToList();
        }

        public IList<Medicine> GetMedicinesQuery(Func<Medicine, bool> q)
        {
            return db.Medicines
                     .Include(m => m.Patient)
                     .Where(q).ToList();
        }

        // perform a search of the medicine requests based on a query and
        // an active range 'ALL', 'OPEN', 'CLOSED'
        public IList<Medicine> SearchMedicineRequests(MedicineRange range, string query)
        {
            // ensure query is not null
            query ??= "";

            // search patient name 
            var m1 = db.Medicines
                       .Include(m => m.Patient)
                       .Where(m => m.Patient.Name.ToLower().Contains(query.ToLower()));

            // search medicine request
            var m2 = db.Medicines
                       .Include(m => m.Patient)
                       .Where(m => m.MedicineName.ToLower().Contains(query.ToLower()));

            // Use Union to join both queries and Where to filter by ticket status
            // Calling ToList() actually executes the final combined query
            return m1.Union(m2).Where(m =>
                   range == MedicineRange.OPEN && m.Active ||
                   range == MedicineRange.CLOSED && !m.Active ||
                   range == MedicineRange.ALL
            ).ToList();
        }

        // ------------------------- User Related Operations --------------------------

        // Retrieve user by email
        public User GetUserByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        // Authenticate a user
        public User Authenticate(string email, string password)
        {
            // retrieve the user based on the email address (assumes email is unique)
            var user = GetUserByEmail(email);

            // Verify the user exists and Hashed User password matches the password provided
            // return user if authenticated otherwise null
            return (user != null && Hasher.ValidateHash(user.Password, password)) ? user : null;
        }

        // Register a new user
        public User Register(string name, string email, string password, Role role)
        {
            // check that the user does not already exist (unique username)
            var exists = GetUserByEmail(email);
            if(exists != null)
            {
                return null;
            }

            // create user
            var user = new User
            {
                Name = name,
                Email = email,
                Password = Hasher.CalculateHash(password),
                Role = role
            };

            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }


    }
}
