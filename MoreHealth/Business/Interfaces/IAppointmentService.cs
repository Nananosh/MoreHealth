using System.Collections.Generic;
using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllTalons(ApplicationContext db);
    }
}