using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public IEnumerable<Appointment> GetTalonsByDoctorId(ApplicationContext db, int id)
        {
            var appointments = db.Appointments.Include(x => x.Patient).Where(x => x.Doctor.Id == id);

            return appointments;
        }

        public Appointment AddDoctorTalon(ApplicationContext db, Appointment appointment)
        {
            var addAppointment = new Appointment
            {
                DoctorId = appointment.DoctorId,
                DateStart = appointment.DateStart,
                DateEnd = appointment.DateEnd
            };
            db.Appointments.Add(addAppointment);
            db.SaveChanges();

            var addedAppointment =
                db.Appointments
                    .Include(x => x.Doctor)
                    .FirstOrDefault(x => x.Id == addAppointment.Id);

            return addAppointment;
        }

        public Appointment EditDoctorTalon(ApplicationContext db, Appointment appointment)
        {
            var editAppointment = db.Appointments
                .FirstOrDefault(x => x.Id == appointment.Id);

            if (editAppointment != null)
            {
                editAppointment.DateEnd = appointment.DateEnd;
                editAppointment.DateStart = appointment.DateStart;
                db.SaveChanges();
            }
            
            var editedAppointment = db.Appointments
                .Include(x => x.Patient)
                .FirstOrDefault(x => x.Id == editAppointment.Id);

            return editedAppointment;
        }

        public void DeleteDoctorTalon(ApplicationContext db, Appointment appointment)
        {
            var deleteAppointment = db.Appointments.FirstOrDefault(x => x.Id == appointment.Id);
            if (deleteAppointment != null) db.Appointments.Remove(deleteAppointment);
            db.SaveChanges();
        }
    }
}