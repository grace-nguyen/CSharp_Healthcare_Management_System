using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Services;

public class PatientService
{
    private List<Patient> patients = new List<Patient>();

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }

    public void UpdatePatient(Patient patient)
    {
        var existingPatient = patients.Find(p => p.Id == patient.Id);
        if (existingPatient != null)
        {
            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.MedicalHistory = patient.MedicalHistory;
        }
    }

    public void RemovePatient(int id)
    {
        patients.RemoveAll(p => p.Id == id);
    }

    public void DisplayPatients() 
    {
        foreach (var patient in patients)
        {
            patient.DisplayInfo();
        }
    }

    public Patient SearchPatientById(int id)
    {
        return patients.FirstOrDefault(p => p.Id == id);
    }

    public List<Patient> SearchPatientsByName(string name)
    {
        return patients.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name)).ToList();
    }

    // Reporting: Generate reports of all patients
    public void GenerateAllPatientReport() 
    {
        Console.WriteLine("All Patients Report");
        foreach (var patient in patients)
        {
            patient.DisplayInfo();
        }
    }

    // Reporting: Generate medical history reports for a specific patient
    public void GenerateMedicalHistoryReport(int patientId)
    {
        var patient = SearchPatientById(patientId);
        Console.WriteLine("log", patient);
        if (patient != null)
        {
            patient.DisplayInfo();
        } else {
            Console.WriteLine("Patient not found");
        }
    }
}
