using System.Collections.Generic;

using MoreHealth.Models;

namespace MoreHealth.Business.Interfaces
{
    public interface IFeedBackService
    {
        IEnumerable<Doctor> GetAllDoctors(ApplicationContext db);
    }
}
