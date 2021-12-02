using System.Collections.Generic;
using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IPaidServicesService
    {
        IEnumerable<PaidServices> GetAllPaidServices(ApplicationContext db);
    }
}