using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMS.Data.Models;

namespace MMS.Data.Services
{
    // This interface describes the operations that a PatientService class should implement
    public interface IPatientService
    {
        // Initialise the repository - only to be used during development
        void Initialise();

        // ------------------------------ Patient Management -------------------------------
        IList<Patient> GetPatients();
        Patient GetPatient(int id);
        Patient GetPatientByEmail(string email);
        bool IsDuplicateEmail(string email, int patientId);
        Patient AddPatient(string name, string email, int age);
        Patient UpdatePatient(Patient updated);
        bool DeletePatient(int id);
        IList<Patient> GetPatientsScript(Func<Patient, bool> s);

        // ------------------------------ Medicine Management -------------------------------

        Medicine CreateMedicine(int patientId, string medicineName);
        Medicine GetMedicine(int id);
        Medicine CloseRequest(int id, string resolution = "Script resolved.");
        bool DeleteMedicine(int id);
        IList<Medicine> GetAllMedicines();
        IList<Medicine> GetOpenMedicineRequests();
        IList<Medicine> SearchMedicineRequests(MedicineRange range, string query);
        IList<Medicine> GetMedicinesQuery(Func<Medicine, bool> q);

        // ------------------------------ User Management -------------------------------

        User GetUserByEmail(string email);
        User Authenticate(string email, string password);
        User Register(string name, string email, string password, Role role);


    }
}
