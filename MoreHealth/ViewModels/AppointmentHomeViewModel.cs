using MoreHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.ViewModels
{
    public class AppointmentHomeViewModel
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}
