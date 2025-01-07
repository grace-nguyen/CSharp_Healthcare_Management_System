using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Services;

public class AppointmentService
{
    private List<Appointment> appointments = new List<Appointment>();

    public void AddAppointment(Appointment appointment)
    {
        appointments.Add(appointment);
    }

    public void UpdateAppointment(Appointment appointment)
    {
        var existingAppointment = appointments.Find(a => a.Id == appointment.Id);
        if (existingAppointment != null)
        {
            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
        }
    }

    public void RemoveAppointment(int id)
    {
        appointments.RemoveAll(a => a.Id == id);
    }

    public void DisplayAppointments()
    {
        foreach (var appointment in appointments)
        {
            appointment.DisplayInfo();
        }
    }

    // Search methods
    public List<Appointment> SearchAppointmentsByPatientId(int patientId)
    {
        return appointments.Where(a => a.PatientId == patientId).ToList();
    }

    public List<Appointment> SearchAppointmentsByDoctorId(int doctorId)
    {
        return appointments.Where(a => a.DoctorId == doctorId).ToList();
    }

    public List<Appointment> SearchAppointmentsByDate(DateTime date)
    {
        return appointments.Where(a => a.AppointmentDate.Date == date.Date).ToList();
    }


}
