namespace MoreHealth.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public string Text { get; set; }
        public bool IsLike { get; set; }
    }
}