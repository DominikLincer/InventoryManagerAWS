namespace InventoryManagerDemo.Database.Models
{
    public class Pallet
    {
        public int Id { get; set; }
        public virtual Size Size { get; set; }
        public decimal Weight { get; set; }
        public bool IsPlaced { get; set; }
    }
}
