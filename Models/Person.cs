using System;

namespace Healthcare_Management_System.Models;

public abstract class Person
{
    public int Id { get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void DisplayInfo() 
    {
        Console.WriteLine($"ID: {Id}, Name: {FirstName} {LastName}");
    }
}
