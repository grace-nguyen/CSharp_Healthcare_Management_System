using System;
using Healthcare_Management_System.Models;
using Healthcare_Management_System.Services;
using Healthcare_Management_System.Access;

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

            // Add users data
            var adminUser = new User {Id = 1, Username = "admin", Password = "admin", Role = "admin"};
            var doctorUser = new User {Id = 2, Username = "doctor", Password = "doctor", Role = "doctor"};
            var nurseUser = new User {Id = 3, Username = "nurse", Password = "nurse", Role = "nurse"};
            var patientUser = new User {Id = 4, Username = "patient", Password = "patient", Role = "patient"};
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
            }
            else
            {
                Console.WriteLine("Authentication failed. Invalid username or password!");
            }

        }
    }
}