using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Observers;

public class PatientObserver : IObserver
{
    private readonly int _patientId;

    public PatientObserver(int patientId)
    {
        _patientId = patientId;
    }

    public void Update(MedicalRecord medicalRecord)
    {
        if (medicalRecord.PatientId == _patientId)
        {
            Console.WriteLine($"Patient with ID {_patientId} has a new update on their medical record: ");
            medicalRecord.DisplayInfo();
        }
    }
}
