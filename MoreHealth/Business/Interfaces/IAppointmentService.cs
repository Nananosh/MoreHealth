using System;
using System.Collections.Generic;
using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllTalons(ApplicationContext db);
        IEnumerable<Appointment> GetTalonsByDoctorDate(ApplicationContext db,int id, DateTime talon );
        string AddPatientTalon(ApplicationContext db, int talon, string address, int patientId);
        string CallingDoctorHome(ApplicationContext db, AppointmentHome appointmentHome);
    }
}