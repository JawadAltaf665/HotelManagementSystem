namespace HotelManagementSystem.Dtos
{
    public class TableDTO
    {
        public int Id { get; set; }

        public string TableNumber { get; set; } = string.Empty;

        public string? QRCodeUrl { get; set; }
    }

}
