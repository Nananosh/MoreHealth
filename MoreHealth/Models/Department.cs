using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<Specialization> Specializations { get; set; }
    }
}