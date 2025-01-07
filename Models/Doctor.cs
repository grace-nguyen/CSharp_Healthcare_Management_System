using System;

namespace Healthcare_Management_System.Models;

public class Doctor : Person
{
    public string Specialty { get; set; }

    public new void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Specialty: {Specialty}");
    }
}
