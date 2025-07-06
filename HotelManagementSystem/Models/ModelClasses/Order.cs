public class Order
{
    public int Id { get; set; }

    public int TableId { get; set; }

    public Table? Table { get; set; }

    public string OrderItems { get; set; } = string.Empty; //JSON string format

    public decimal TotalAmount { get; set; }

    public DateTime OrderTime { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Pending";  //Pending, InProcess, Done
}
