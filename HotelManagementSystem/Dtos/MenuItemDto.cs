﻿namespace HotelManagementSystem.Dtos
{
    public class MenuItemDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public string? Category { get; set; } 
    }

}
