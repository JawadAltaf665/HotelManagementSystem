using HotelManagementSystem.Models.ModelClasses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Order
{
    public int Id { get; set; }

    public int TableId { get; set; }

    public Table? Table { get; set; }

    public List<OrderItem> items { get; set; } //JSON string format

    public decimal TotalAmount { get; set; }

    public DateTime OrderTime { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Pending";  //Pending, InProcess, Done
}
