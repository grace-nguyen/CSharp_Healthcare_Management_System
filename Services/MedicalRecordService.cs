using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Services;

public class MedicalRecordService
{
    private List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

    public void AddMedicalRecord(MedicalRecord medicalRecord)
    {
        medicalRecords.Add(medicalRecord);
    }

    public void UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        var existingMedicalRecord = medicalRecords.Find(mr => mr.Id == medicalRecord.Id);
        if (existingMedicalRecord != null)
        {
            existingMedicalRecord.PatientId = medicalRecord.PatientId;
            existingMedicalRecord.DoctorId = medicalRecord.DoctorId;
            existingMedicalRecord.Diagnosis = medicalRecord.Diagnosis;
            existingMedicalRecord.Treatment = medicalRecord.Treatment;
        }
    }

    public void RemoveMedicalRecord(int id)
    {
        medicalRecords.RemoveAll(mr => mr.Id == id);
    }

    public void DisplayMedicalRecords()
    {
        foreach (var medicalRecord in medicalRecords)
        {
            medicalRecord.DisplayInfo();
        }
    }

    // Search methods
    public List<MedicalRecord> SearchMedicalRecordsByPatientId(int patientId)
    {
        return medicalRecords.Where(mr => mr.PatientId == patientId).ToList();
    }

    public List<MedicalRecord> SearchMedicalRecordsByDoctorId(int doctorId)
    {
        return medicalRecords.Where(mr => mr.DoctorId == doctorId).ToList();
    }

    // Reporting: Generate medical record report for a specific patient
    public void GenerateMedicalHistoryReport(int patientId, PatientService patientService)
    {
        var patient = patientService.SearchPatientById(patientId);
        if (patient != null)
        {
            Console.WriteLine("Medical Record Report for Patient: " + patient.FirstName + " " + patient.LastName);
            var medicalRecords = SearchMedicalRecordsByPatientId(patientId);
            foreach (var medicalRecord in medicalRecords)
            {
                medicalRecord.DisplayInfo();
            }
        } 
        else {
            Console.WriteLine("Patient not found");
        }
    }
}

