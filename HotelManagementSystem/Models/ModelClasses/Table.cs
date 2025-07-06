using HotelManagementSystem.Models.Common;

public class Table: BaseEntity
{
    public int Id { get; set; }

    public string TableNumber { get; set; } = string.Empty;

    public string? QRCodeUrl { get; set; } 

    public ICollection<Order>? Orders { get; set; }//Navigation property
}
