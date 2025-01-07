using System;

namespace Healthcare_Management_System.Models;

public class Nurse : Person
{
    public string Department { get; set; }

    public new void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Department: {Department}");
    }
}
