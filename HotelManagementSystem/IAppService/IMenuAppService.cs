using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.IAppService
{
    public interface IMenuAppService
    {
        Task<Response> GetAllMenusAsync();
        Task<Response> GetMenuByIdAsync(int id);
        Task<Response> CreateMenuAsync(MenuItemDTO input);
        Task<Response> UpdateMenuAsync(int id, MenuItemDTO input);
        Task<Response> DeleteMenuAsync(int id);
    }
}
