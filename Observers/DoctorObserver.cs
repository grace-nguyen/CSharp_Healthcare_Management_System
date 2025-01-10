using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Observers;

public class DoctorObserver : IObserver
{
    private readonly int _doctorId;
    
    public DoctorObserver(int doctorId)
    {
        _doctorId = doctorId;
    }

    public void Update(MedicalRecord medicalRecord)
    {
        if (medicalRecord.DoctorId == _doctorId)
        {
            Console.WriteLine($"Doctor with ID {_doctorId} has a new update on their medical record: ");
            medicalRecord.DisplayInfo();
        }
    }
}
