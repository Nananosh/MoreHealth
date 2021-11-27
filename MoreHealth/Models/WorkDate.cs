using System;
using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class WorkDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<WorkSchedule> WorkSchedules { get; set; }
    }
}