using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly ApplicationContext db;
        private readonly IMapper mapper;

        public AppointmentService(
            ApplicationContext context,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.db = context;
        }

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

        public void CancelAppointment(int id)
        {
            var cancelAppointment = db.Appointments.FirstOrDefault(x => x.Id == id);

            if (cancelAppointment != null)
            {
                cancelAppointment.PatientId = null;
                db.SaveChanges();
            }
        }

        public DoctorViewModel GetDoctorById(int id)
        {
            var doctor = db.Doctor.Where(x => x.Id == id).FirstOrDefault();

            return mapper.Map<DoctorViewModel>(doctor);
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

        public List<Appointment> GetTalonsByPatientId(ApplicationContext db, int id)
        {
            var appointments = db.Appointments.Include(x => x.Doctor).ThenInclude(x => x.Cabinet)
                .Where(x => x.Patient.Id == id)
                .OrderByDescending(x => x.DateStart).ToList();

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

        public Appointment GetTalonById(int id)
        {
            var appointment = db.Appointments
                .Include(x => x.Doctor)
                .ThenInclude(x => x.Cabinet)
                .Include(x => x.Patient)
                .FirstOrDefault(x => x.Id == id);

            return appointment;
        }

        public List<Patient> GetAllPatient()
        {
            var patients = db.Patient.Include(x => x.User).ToList();
            return patients;
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = db.Doctor
                .Include(x => x.Cabinet)
                .Include(x => x.Specialization)
                .ThenInclude(x => x.Department).ToList();

            return doctors;
        }
    }
}