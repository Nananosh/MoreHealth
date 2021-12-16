using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoreHealth.Business.Interfaces;
using MoreHealth.Constants.UserMessagesConstants;
using MoreHealth.Models;
using MoreHealth.ViewModels;

namespace MoreHealth.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        public IEnumerable<Appointment> GetAllTalons(ApplicationContext db)
        {
            var appointments = db.Appointments.Include(d => d.Doctor).Include(p => p.Patient);

            return appointments;
        }

        public IEnumerable<Appointment> GetTalonsByDoctorDate(ApplicationContext db, int id, DateTime talon)
        {
            var appointments = db.Appointments.Include(d => d.Doctor).Include(p => p.Patient).AsQueryable();
            appointments = appointments.Where(
                x => x.DateStart.Date == talon.Date
                && x.DateStart.Month == talon.Month
                && x.DateStart.Year == talon.Year);

            appointments = appointments.Where(x => x.Doctor.Id == id);
            appointments = appointments.Where(x => x.Patient == null);

            return appointments;
        }

        public string AddPatientTalon(ApplicationContext db, int talon, string address, int patientId)
        {
            var talons = db.Appointments.FirstOrDefault(x => x.Id == talon);

            if (talons == null)
            {
                return UserMessagesConstants.TicketToDoctorCouldNotBeOrdered;
            }

            talons.Address = address;
            talons.PatientId = patientId;

            db.Appointments.Update(talons);
            db.SaveChanges();

            return UserMessagesConstants.TicketToDoctorSuccessfullyOrdered;
        }

        public string CallingDoctorHome(ApplicationContext db, AppointmentHome appointmentHome)
        {
            db.AppointmentHomes.Add(appointmentHome);
            db.SaveChanges();

            return UserMessagesConstants.CallingDoctorHomeSuccessfull;
        }
    }
}