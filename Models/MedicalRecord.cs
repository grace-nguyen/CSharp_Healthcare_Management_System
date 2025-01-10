using System;
using Healthcare_Management_System.Observers;

namespace Healthcare_Management_System.Models;

public class MedicalRecord : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    public int Id { get; set; }
    public int PatientId  { get; set; }
    public int DoctorId { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }  

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    } 

    public void UpdateRecord(string diagnosis, string treatment)
    {
        Diagnosis = diagnosis;
        Treatment = treatment;
        Notify();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Record ID: {Id}, Patient ID: {PatientId}, Doctor ID: {DoctorId}, Diagnosis: {Diagnosis}, Treatment: {Treatment}");
    }

    
}
