using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;

namespace MoreHealth.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        public IEnumerable<Appointment> GetAllTalons(ApplicationContext db)
        {
            var appointments = db.Appointments.Include(d => d.Doctor).Include(p => p.Patient);

            return appointments;
        }
    }
}