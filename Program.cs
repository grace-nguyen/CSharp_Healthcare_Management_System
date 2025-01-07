using System;
using Healthcare_Management_System.Models;
using Healthcare_Management_System.Services;

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
            var adminUser = new User {Id = 1, Username = "admin", Password = "admin", Role = "Admin"};
            var doctorUser = new User {Id = 2, Username = "doctor", Password = "doctor", Role = "Doctor"};
            var nurseUser = new User {Id = 3, Username = "nurse", Password = "nurse", Role = "Nurse"};
            var patientUser = new User {Id = 4, Username = "patient", Password = "patient", Role = "Patient"};
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
                Console.WriteLine("User authenticated successfully!");
                authenticatedUser.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Invalid username or password!");
            }

            // Add data to the services
            var patient = new Patient { Id = 1, FirstName = "John", LastName = "Doe", MedicalHistory = "None" };
            var patient2 = new Patient { Id = 2, FirstName = "Jane", LastName = "Lucky", MedicalHistory = "None" };
            patientService.AddPatient(patient);
            patientService.AddPatient(patient2);

            var doctor = new Doctor { Id = 1, FirstName = "Jane", LastName = "Smith", Specialty = "Cardiology" };
            doctorService.AddDoctor(doctor);

            var nurse = new Nurse { Id = 1, FirstName = "Alice", LastName = "Johnson", Department = "Cardiology" };
            nurseService.AddNurse(nurse);

            var appointment = new Appointment { Id = 1, PatientId = 1, DoctorId = 1,  AppointmentDate = DateTime.Now };
            appointmentService.AddAppointment(appointment);

            var medicalRecord = new MedicalRecord { Id = 1, PatientId = 1, DoctorId = 1, Diagnosis = "Heart Disease", Treatment = "Medication" };
            medicalRecordService.AddMedicalRecord(medicalRecord);

            // Display the data
            Console.WriteLine("Patients:");
            patientService.DisplayPatients();

            Console.WriteLine("\nDoctors:");
            doctorService.DisplayDoctors();

            Console.WriteLine("\nNurses:");
            nurseService.DisplayNurses();

            Console.WriteLine("\nAppointments:");
            appointmentService.DisplayAppointments();

            Console.WriteLine("\nMedical Records:");
            medicalRecordService.DisplayMedicalRecords();

            // Update data
            patient.Id = 1;
            patient.FirstName = "Lena Lena";
            patientService.UpdatePatient(patient);

            // Console.WriteLine("\nUpdated Patients:");
            // patientService.DisplayPatients();

            // Search functionality
            Console.WriteLine("\nSearch Patient by ID:");
            var searchedPatient = patientService.SearchPatientById(1);
            searchedPatient?.DisplayInfo();

             Console.WriteLine("\nSearch Patients by Name:");
            var searchedPatients = patientService.SearchPatientsByName("Jane");
            foreach (var p in searchedPatients)
            {
                p.DisplayInfo();
            }

            // Search by appointment date
            Console.WriteLine("\nSearch Appointments by Date:");
            var searchDate = new DateTime(2025, 1, 6);
            var searchDate2 =  DateTime.Now.Date;
            var searchedAppointments = appointmentService.SearchAppointmentsByDate(searchDate);
            foreach (var a in searchedAppointments)
            {
                a.DisplayInfo();
            }

            //Report
            Console.WriteLine("\nGenerate a specific Patient:");
            patientService.GenerateMedicalHistoryReport(5);

            Console.WriteLine("\nGenerate appointment schedules for a specific doctor:");
            doctorService.GenerateAppointmentScheduleReport(1, appointmentService);

            // Remove data
            // patientService.RemovePatient(1);

            // Console.WriteLine("\nRemoved Patients:");
            // patientService.DisplayPatients();

        }
    }
}