using System;
using System.Text;
using System.Collections.Generic;
using MMS.Data.Models;

namespace MMS.Data.Services
{
    public static class ServiceSeeder
    {
        // use this class to seed the database with dummy test data using an IPatientService

        public static void Seed(IPatientService svc)
        {
            svc.Initialise();

            // add patients

            var p1 = svc.AddPatient("Enver Hoxha", "enverhoxha@albaniancommunistparty.alb", 77);
            var p2 = svc.AddPatient("Joseph Tito", "tito@yugoslavia.com", 80);
            var p3 = svc.AddPatient("Idi Amin", "bigidi@ugandanboss.com", 64);
            var p4 = svc.AddPatient("Leo Fender", "leo@fender.com", 65);
            var p5 = svc.AddPatient("John Steinbeck", "bigbadjohn@outlook.com", 40);

            // add medicine requests
            var m1 = svc.CreateMedicine(p1.Id, "Need medicine to give me energy to build more bunkers.");
            var m2 = svc.CreateMedicine(p2.Id, "Need something to put in Stalin's tea.");
            var m3 = svc.CreateMedicine(p3.Id, "Paracetemol");
            var m4 = svc.CreateMedicine(p4.Id, "Grapes, Tortilas...");

            svc.CloseRequest(p1.Id, "Send old man Hoxha a Red Bull...");

            // add users

            var u1 = svc.Register("Guest", "guest@mms.com", "guest", Role.guest);
            var u2 = svc.Register("Administrator", "admin@mms.com", "admin", Role.admin);
            var u3 = svc.Register("Manager", "manager@mms.com", "manager", Role.manager);
           


        }


    }
}
