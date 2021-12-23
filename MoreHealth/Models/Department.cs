using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoreHealth.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        [JsonIgnore]
        public List<Specialization> Specializations { get; set; }
    }
}