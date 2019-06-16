namespace InventoryManagerDemo.Database.Models
{
    public class Stillage
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public decimal MaximumLoad { get; set; }
        public int FreeSpaces { get; set; }
    }
}
