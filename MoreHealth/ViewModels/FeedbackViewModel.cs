using System.ComponentModel.DataAnnotations;
using MoreHealth.Models;

namespace ItransitionCourseProject.ViewModels.Account
{
    public class FeedbackViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Patient Patient { get; set; }
        [Required]
        public Doctor Doctor { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsLike { get; set; }
    }
}