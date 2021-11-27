using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public List<Doctor> Doctor { get; set; }
        public WorkingShift WorkingShift { get; set; }
        public WorkDate WorkDate { get; set; }
    }
}