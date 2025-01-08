using System;
using Healthcare_Management_System.Models;
using Healthcare_Management_System.Services;

namespace Healthcare_Management_System.Access;

public static class NurseAccess
{
    public static void Execute(
        PatientService patientService, 
        AppointmentService appointmentService, 
        NurseService nurseService
    )
    {
        // Nurse can view patients and appointments
        Console.WriteLine("Nurse access granted!");
        // Add sample data
        var patient1 = new Patient { Id = 1, FirstName = "John", LastName = "Doe", MedicalHistory = "None" };
        patientService.AddPatient(patient1);

        var appointment1 = new Appointment { Id = 1, PatientId = 1, DoctorId = 1, AppointmentDate = new DateTime(2025, 1, 15) };
        appointmentService.AddAppointment(appointment1);

        // Display the data
        Console.WriteLine("Patients:");
        patientService.DisplayPatients();
        Console.WriteLine("\nAppointments:");
        appointmentService.DisplayAppointments();
    }
}
