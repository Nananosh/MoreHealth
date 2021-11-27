using System;
using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class WorkingShift
    {
        public int Id { get; set; }
        public DateTime StartWorkShift { get; set; }
        public DateTime EndWorkShift { get; set; }
        public List<WorkSchedule> WorkSchedules { get; set; }
    }
}