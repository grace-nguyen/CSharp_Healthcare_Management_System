using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Observers;

public interface IObserver
{
   void Update(MedicalRecord medicalRecord); 
} 
