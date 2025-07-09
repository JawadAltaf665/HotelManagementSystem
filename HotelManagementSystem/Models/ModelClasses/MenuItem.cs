using HotelManagementSystem.Models.Common;

public class MenuItem: BaseEntity
{
    public int Id { get; set; }

    public string MenuItemName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? Category { get; set; }  // Optional: Drinks, Appetizer, etc.

}
