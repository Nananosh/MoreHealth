using MoreHealth.Models;

namespace MoreHealth.ViewModels
{
    public class SpecializationViewModel
    {
        public int Id { get; set; }
        public string SpecializationName{ get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}