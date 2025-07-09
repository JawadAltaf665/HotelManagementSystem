namespace HotelManagementSystem.Models.ModelClasses
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Foreign key
        public Order? Order { get; set; } // Navigation property

        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; } // Navigation property

        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
