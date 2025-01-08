using System;
using Healthcare_Management_System.Models;
using Healthcare_Management_System.Services;

namespace Healthcare_Management_System.Access;

public static class DoctorAccess
{
    public static void Execute(
        User authenticatedUser, 
        PatientService patientService, 
        AppointmentService appointmentService, 
        MedicalRecordService medicalRecordService,
        DoctorService doctorService
    )
    {
        // Doctor can view and manage their own appointments and patients
        Console.WriteLine("Doctor Access Granted");
        // Add sample data
        var patient1 = new Patient { Id = 1, FirstName = "John", LastName = "Doe", MedicalHistory = "None" };
        patientService.AddPatient(patient1);

        var appointment1 = new Appointment { Id = 1, PatientId = 1, DoctorId = authenticatedUser.Id,  AppointmentDate = new DateTime(2025, 1, 15) };
        appointmentService.AddAppointment(appointment1);

        var medicalRecord1 = new MedicalRecord { Id = 1, PatientId = 1, DoctorId = authenticatedUser.Id, Diagnosis = "None", Treatment = "None" };  
        medicalRecordService.AddMedicalRecord(medicalRecord1);

        // Display the data
        Console.WriteLine("Patients:");
        patientService.DisplayPatients();
        Console.WriteLine("\nAppointments:");
        appointmentService.DisplayAppointments();
        Console.WriteLine("\nMedical Records:");
        medicalRecordService.DisplayMedicalRecords();

        // Generate reports
        Console.WriteLine("\nGenerate Medical Record Report for Patient 1:");
        medicalRecordService.GenerateMedicalHistoryReport(1, patientService);

        Console.WriteLine("\nGenerate Appointment schedule report  for Doctor 1:");
        doctorService.GenerateAppointmentScheduleReport(authenticatedUser.Id, appointmentService);
    }
}
