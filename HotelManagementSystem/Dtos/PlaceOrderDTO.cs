namespace HotelManagementSystem.Dtos
{
    public class PlaceOrderDTO
    {
        public int TableId { get; set; }

        public List<OrderItemDTO> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }
    }

}
