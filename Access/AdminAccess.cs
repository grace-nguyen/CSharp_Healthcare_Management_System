using System;
using Healthcare_Management_System.Models;
using Healthcare_Management_System.Services;

namespace Healthcare_Management_System.Access;

public static class AdminAccess
{
    public static void Execute(
        PatientService patientService, 
        DoctorService doctorService, 
        NurseService nurseService, 
        AppointmentService appointmentService, 
        MedicalRecordService medicalRecordService)
    {
        // Admin can manage all data
        Console.WriteLine("Admin Access granted!");
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
