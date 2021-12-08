using System;
using System.Collections.Generic;

namespace MoreHealth.Models
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public string RecurrenceRule { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}