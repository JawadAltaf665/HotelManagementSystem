namespace HotelManagementSystem.Dtos
{
    public class OrderDTO : BaseEntityDTO
    {
        public int Id { get; set; }

        public int TableId { get; set; }

        public string TableNumber { get; set; } = string.Empty;

        public List<OrderItemDTO> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }

        public DateTime OrderTime { get; set; }

        public string Status { get; set; } = "Pending";
    }

}
