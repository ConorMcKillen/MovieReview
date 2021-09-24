using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using MMS.Data.Models;

namespace MMS.Data.Services
{
    public class PatientServiceList : IPatientService
    {
        private readonly string PATIENT_STORE = "patients.json";
        private readonly string USER_STORE = "users.json";

        private IList<Patient> Patients;
        private IList<User> Users;

        public PatientServiceList()
        {
            Load();
        }

        // load data from local json store
        private void Load()
        {
            try
            {
                string patients = File.ReadAllText(PATIENT_STORE);
                string users = File.ReadAllText(USER_STORE);
                Patients = JsonSerializer.Deserialize<List<Patient>>(patients);

                // ensure each medicine request Patient property is set as this is lost in serialisation
                foreach(var p in Patients)
                {
                    foreach(var m in p.Medicines)
                    {
                        m.Patient = p;
                    }
                }
                Users = JsonSerializer.Deserialize<List<User>>(users);
            }
            catch(Exception )
            {
                Patients = new List<Patient>();
                Users = new List<User>();
            }
        }

        // write to local json store
        private void Store()
        {
            var patients = JsonSerializer.Serialize(Patients);
            File.WriteAllText(PATIENT_STORE, patients);
            var users = JsonSerializer.Serialize(Users);
            File.WriteAllText(USER_STORE, users);
        }

        public void Initialise()
        {
            Patients.Clear(); // Wipe all patients
            Users.Clear();
        }

        //-------------------- Patient Related Operations --------------------------

        // retrieve list of Patients 
        public IList<Patient> GetPatients()
        {
            return Patients;
        }

        // Retrieve patient by ID
        public Patient GetPatient(int id)
        {
            return Patients.FirstOrDefault(p => p.Id == id);
        }

        // Add a new patient checking a patient with the same email does not exist
        public Patient AddPatient(string name, string email, int age)
        {
            // check if email is already in use by another patient
            var existing = GetPatientByEmail(email);
            if(existing != null)
            {
                return null; // email in use so we cannot create a patient
            }

            // email is unique so go ahead and create patient
            var p = new Patient
            {
                // simple mechanism to calculate next ID
                Id = Patients.Count + 1,
                Name = name,
                Email = email,
                Age = age
            };

            Patients.Add(p);
            Store(); // write to local file store
            return p; // return newly added patient
        }

        // Delete the patient identified by ID returning true if deleted and false if not found
        public bool DeletePatient(int id)
        {
            var p = GetPatient(id);
            if(p == null)
            {
                return false;
            }
            Patients.Remove(p);
            Store(); // write to local file store
            return true;
        }

        // Update the patient with the details in updated
        public Patient UpdatePatient(Patient updated)
        {
            // verify that the patient exists
            var patient = GetPatient(updated.Id);
            if (patient == null)
            {
                return null;
            }
            // update the details of the patient retrieved and save
            patient.Name = updated.Name;
            patient.Email = updated.Email;
            patient.Age = updated.Age;

            Store(); // write to local file store
            return patient;
        }

        public Patient GetPatientByEmail(string email)
        {
            return Patients.FirstOrDefault(p => p.Email == email);
        }

        public IList<Patient> GetPatientsScript(Func<Patient, bool> s)
        {
            return Patients.Where(s).ToList();
        }

        public bool IsDuplicateEmail(string email, int patientId)
        {
            var existing = GetPatientByEmail(email);
            // if a patient with email exists and the Id does not match
            // the patientId (if provided), then they cannot use the email
            return existing != null && patientId != existing.Id;
        }


        //------------------------------- Medicine Management --------------------------------------------

        public Medicine CreateMedicine(int patientId, string medicineName)
        {
            var patient = GetPatient(patientId);
            if (patient == null) return null;

            var medicine = new Medicine
            {
                Id = Patients.Sum(p => p.Medicines.Count()) + 1,
                MedicineName = medicineName,
                CreatedOn = DateTime.Now,
                Active = true,
                PatientId = patientId,
                Patient = patient
            };

            patient.Medicines.Add(medicine);
            Store();
            return medicine;
        }

        // retrive medicine by Id
        public Medicine GetMedicine(int id)
        {
            return Patients.SelectMany(p => p.Medicines)
                           .FirstOrDefault(m => m.Id == id);
        }

        // Close medicine request
        public Medicine CloseRequest(int id, string resolution)
        {
            var medicine = GetMedicine(id);
            if (medicine == null || !medicine.Active) return null;

            medicine.Active = false;
            medicine.ResolvedOn = DateTime.Now;
            medicine.Resolution = resolution;
            Store();

            return medicine;
        }

        // remove specified medicine request
        public bool DeleteMedicine(int id)
        {
            // find medicine
            var medicine = GetMedicine(id);
            if (medicine == null) return false;

            // remove medicine from patient 
            var result = medicine.Patient.Medicines.Remove(medicine);

            return result;
        }

        // retrieve all tickets
        public IList<Medicine> GetAllMedicines()
        {
            var medicines = Patients.SelectMany(p => p.Medicines).ToList();
            return medicines;
        }

        // retrieve only open (active) medicine requests
        public IList<Medicine> GetOpenMedicineRequests()
        {
            var medicines = Patients.SelectMany(p => p.Medicines.Where(m => m.Active)).ToList();
            return medicines;
        }

        // perform search on medicine requests
        public IList<Medicine> SearchMedicineRequests(MedicineRange range, string query)
        {
            query = query == null ? "" : query.ToLower();

            // search medicine patient name
            var m1 = Patients.SelectMany(p => p.Medicines).Where(m => GetPatient(m.PatientId).Name.ToLower().Contains(query.ToLower()));

            // serach medicien request
            var m2 = Patients.SelectMany(p => p.Medicines)
                             .Where(m => m.MedicineName.ToLower().Contains(query.ToLower()));

            // execute the join query (calling ToList() executes the query)
            var m = m1.Union(m2).Where(t =>
                    range == MedicineRange.OPEN && t.Active ||
                    range == MedicineRange.CLOSED && !t.Active ||
                    range == MedicineRange.ALL
            ).ToList();

            return m;
        }

        public IList<Medicine> GetMedicinesQuery(Func<Medicine, bool> q)
        {
            return Patients.SelectMany(p => p.Medicines)
                           .Where(q)
                           .ToList();
        }

        //------------------------ User Related Operations -------------------------

        // Retrieve user by email
        public User GetUserByEmail(string email)
        {
            return Users.FirstOrDefault(u => u.Email == email);
        }

        // Authenicate a user
        public User Authenticate(string email, string password)
        {
            // retrive user based on Email address (assumes Email is unique)
            var user = GetUserByEmail(email);

            // Verify if the user exists password matche the password provided
            if (user == null || user.Password != password)
            {
                return null; // no such user
            }
            return user; // user authenticated
        }

        // Register a new user
        public User Register(string name, string email, string password, Role role)
        {
            // check that the user does not already exist
            var exists = GetUserByEmail(email);
            if (exists != null)
            {
                return null;
            }

            // create user
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = role
            };

            Users.Add(user);
            Store();
            return user;
        }



    }
}
