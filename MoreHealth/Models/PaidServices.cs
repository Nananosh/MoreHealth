namespace MoreHealth.Models
{
    public class PaidServices
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ForeignPrice { get; set; }
    }
}