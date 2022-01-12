using System.Threading.Tasks;

namespace MoreHealth.Business.Interfaces
{
    public interface ISeedDatabaseService
    {
        public Task CreateStartAdmin();
        public Task CreateStartRole();
    }
}