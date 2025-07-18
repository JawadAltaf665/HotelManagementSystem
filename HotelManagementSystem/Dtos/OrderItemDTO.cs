﻿namespace HotelManagementSystem.Dtos
{
    public class OrderItemDTO
    {
        public int MenuItemId { get; set; }

        public string MenuItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

}
