﻿namespace MoreHealth.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int? PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}