using System;

namespace Healthcare_Management_System.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Appointment ID: {Id}, Patient ID: {PatientId}, Doctor ID: {DoctorId}, Date: {AppointmentDate}");
    }
}
