using System;
using Healthcare_Management_System.Models;
using Healthcare_Management_System.Services;
using Healthcare_Management_System.Access;
using Healthcare_Management_System.Factories;
using Healthcare_Management_System.Observers;

namespace Healthcare_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of the services
            var userService = new UserService();
            var patientService = new PatientService();
            var doctorService = new DoctorService();
            var nurseService = new NurseService();
            var appointmentService = new AppointmentService();
            var medicalRecordService = new MedicalRecordService();

            // Create instance of the UserFactory
            var userFactory = new UserFactory();

            // Add users data using the factory
            var adminUser = userFactory.CreateUser(1, "admin", "admin", "admin");
            var doctorUser = userFactory.CreateUser(2, "doctor", "doctor", "doctor");
            var nurseUser = userFactory.CreateUser(3, "nurse", "nurse", "nurse");
            var patientUser = userFactory.CreateUser(4, "patient", "patient", "patient");

            userService.AddUser(adminUser);
            userService.AddUser(doctorUser);
            userService.AddUser(nurseUser);
            userService.AddUser(patientUser);
            
            
            // Authenticate user
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var authenticatedUser = userService.AuthenticateUser(username, password);
            if (authenticatedUser != null)
            {
                Console.WriteLine($"Welcome {authenticatedUser.Username}!");
                Console.WriteLine($"Role: {authenticatedUser.Role}");

                //Role based access control
                switch (authenticatedUser.Role) 
                {
                    case "admin":
                        AdminAccess.Execute(patientService, doctorService, nurseService, appointmentService, medicalRecordService);
                        break;
                    case "doctor":
                        DoctorAccess.Execute(authenticatedUser, patientService, appointmentService, medicalRecordService, doctorService);
                        break;
                    case "nurse":
                        NurseAccess.Execute(patientService, appointmentService, nurseService);
                        break;
                    default:
                        Console.WriteLine("Access denied.");
                        break;

                }

                // Example of attaching observers and updating a medial record
                var medicalRecord = new MedicalRecord { Id = 1, PatientId = 3, DoctorId = 4, Diagnosis = "None", Treatment = "None" };
                var doctorObserver = new DoctorObserver(4);
                var patientObserver = new PatientObserver(2);

                medicalRecord.Attach(doctorObserver);
                medicalRecord.Attach(patientObserver);

                medicalRecord.UpdateRecord("Heart Disease", "Medication");
            }
            else
            {
                Console.WriteLine("Authentication failed. Invalid username or password!");
            }

        }
    }
}