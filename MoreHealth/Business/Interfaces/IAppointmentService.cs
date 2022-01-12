﻿using System;
using System.Collections;
using System.Collections.Generic;
using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllTalons(ApplicationContext db);
        IEnumerable<Appointment> GetTalonsByDoctorDate(ApplicationContext db,int id, DateTime talon);
        string AddPatientTalon(ApplicationContext db, int talon, string address, int patientId);
        string CallingDoctorHome(ApplicationContext db, AppointmentHome appointmentHome);
        public IEnumerable<Appointment> GetTalonsByDoctorId(ApplicationContext db, int id);
        public Appointment AddDoctorTalon(ApplicationContext db, Appointment appointment);
        public Appointment EditDoctorTalon(ApplicationContext db, Appointment appointment);
        public void DeleteDoctorTalon(ApplicationContext db, Appointment appointment);
    }
}