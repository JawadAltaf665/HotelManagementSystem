using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.IAppService
{
    public interface IOrderAppService
    {
        public Task<Response> GetAllOrdersAsync();
        public Task<Response> GetOrderByIdAsync(int id);
        public Task<Response> CreateOrderAsync(OrderDTO input);
        public Task<Response> UpdateOrderAsync(int id, OrderDTO input);
        public Task<Response> DeleteOrderAsync(int id);
    }
}
