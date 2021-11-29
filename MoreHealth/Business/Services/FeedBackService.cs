using MoreHealth.Business.Interfaces;
using MoreHealth.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoreHealth.Business.Services
{
    public class FeedBackService : IFeedBackService
    {

        public IEnumerable<Doctor> GetAllDoctors(ApplicationContext db)
        {
            IEnumerable<Doctor> doctors = db.Doctor;

            return doctors;
        }
    }
}
