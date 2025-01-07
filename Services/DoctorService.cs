using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Services;

public class DoctorService
{
    private List<Doctor> doctors = new List<Doctor>();

    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
    }

    public void updateDoctor(Doctor doctor)
    {
        var existingDoctor = doctors.Find(d => d.Id == doctor.Id);
        if (existingDoctor != null)
        {   
            existingDoctor.FirstName = doctor.FirstName;
            existingDoctor.LastName = doctor.LastName;
            existingDoctor.Specialty = doctor.Specialty;
        }
    }

    public void RemoveDoctor(int id)
    {
        doctors.RemoveAll(d => d.Id == id);
    }

    public void DisplayDoctors() 
    {
        foreach (var doctor in doctors)
        {
            doctor.DisplayInfo();
        }
    }

    public Doctor SearchDoctorById(int id)
    {
        return doctors.FirstOrDefault(d => d.Id == id);
    }

    public List<Doctor> SearchDoctorByName(string name)
    {
        return doctors.Where(d => d.FirstName.Contains(name) || d.LastName.Contains(name)).ToList();
    }

    public List<Doctor> SearchDoctorBySpecialty(string specialty)
    {
        return doctors.Where(d => d.Specialty.Contains(specialty)).ToList();
    }

    // Reporting: Generate appointment schedule for a specific doctor
    public void GenerateAppointmentScheduleReport(int doctorId, AppointmentService appointmentService)
    {
        var doctor = SearchDoctorById(doctorId);
        if (doctor != null)
        {
            doctor.DisplayInfo();
            var appointments = appointmentService.SearchAppointmentsByDoctorId(doctorId);
            foreach (var appointment in appointments)
            {
                appointment.DisplayInfo();
            }
        } 
        else {
            Console.WriteLine("Doctor not found");
        }
    }

}

