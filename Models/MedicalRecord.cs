using System;

namespace Healthcare_Management_System.Models;

public class MedicalRecord
{
    public int Id { get; set; }
    public int PatientId  { get; set; }
    public int DoctorId { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Record ID: {Id}, Patient ID: {PatientId}, Doctor ID: {DoctorId}, Diagnosis: {Diagnosis}, Treatment: {Treatment}");
    }
}
