using HotelManagementSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.IAppService
{
    public interface IMenuAppService
    {
        Task<Response> GetAllMenusAsync();
        Task<Response> GetMenuByIdAsync(int id);
        Task<Response> UploadImageAsync(IFormFile file);
        Task<Response> CreateMenuAsync(MenuItemDTO input);
        Task<Response> UpdateMenuAsync(MenuItemDTO input);
        Task<Response> DeleteMenuAsync(int id);
    }
}
