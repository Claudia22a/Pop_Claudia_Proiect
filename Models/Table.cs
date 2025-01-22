namespace Pop_Claudia_Proiect.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Seats { get; set; }
        public int RestaurantId { get; set; } 
        public Restaurant? Restaurant { get; set; }
    }
}
