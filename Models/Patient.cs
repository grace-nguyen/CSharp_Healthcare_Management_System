using System;

namespace Healthcare_Management_System.Models;

public class Patient : Person
{
    public string MedicalHistory { get; set; }

    public new void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Medical History: {MedicalHistory}");
    }
}
