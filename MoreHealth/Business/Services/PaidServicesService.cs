using System.Collections.Generic;
using MoreHealth.Business.Interfaces;
using MoreHealth.Models;

namespace MoreHealth.Business.Services
{
    public class PaidServicesService : IPaidServicesService
    {
        public IEnumerable<PaidServices> GetAllPaidServices(ApplicationContext db)
        {
            var paidServices = db.PaidServices;
            return paidServices;
        }
    }
}