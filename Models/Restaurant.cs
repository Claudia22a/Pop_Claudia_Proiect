namespace Pop_Claudia_Proiect.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public List<Table> Tables { get; set; } = new List<Table>();
    }
}
