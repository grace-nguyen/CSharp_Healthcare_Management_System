using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Services;

public class NurseService
{
    private List<Nurse> nurses = new List<Nurse>();

    public void AddNurse(Nurse nurse)
    {
        nurses.Add(nurse);
    }

    public void UpdateNurse(Nurse nurse)
    {
        var existingNurse = nurses.Find(n => n.Id == nurse.Id);
        if (existingNurse != null)
        {
            existingNurse.FirstName = nurse.FirstName;
            existingNurse.LastName = nurse.LastName;
            existingNurse.Department = nurse.Department;
        }
    }

    public void RemoveNurse(int id)
    {
        nurses.RemoveAll(n => n.Id == id);
    }

    public void DisplayNurses()
    {
        foreach (var nurse in nurses)
        {
            nurse.DisplayInfo();
        }
    }

}
