namespace Pop_Claudia_Proiect.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public DateTime ReservationTime { get; set; }
        public int TableId { get; set; }
        public required Table Table { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
    }
}
