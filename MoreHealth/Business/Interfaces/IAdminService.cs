using MoreHealth.Models;
using MoreHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.Business.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Cabinet> GetAllCabinets();
        IEnumerable<AppointmentHome> GetAllAppointmentHome();
        Cabinet UpdateCabinet(Cabinet model);
        Cabinet CreateCabinet(Cabinet model);
        void RemoveCabinet(Cabinet model);
        string RemoveAppointmentHome(AppointmentHomeViewModel model);

    }
}
