using HotelManagementSystem.Dtos;

namespace HotelManagementSystem.IAppService
{
    public interface ITableAppService
    {
        Task<Response> GetAllTablesAsync();
        Task<Response> GetTableByIdAsync(int id);
        Task<Response> CreateTableAsync(TableDTO input);
        Task<Response> UpdateTableAsync(int id, TableDTO input);
        Task<Response> DeleteTableAsync(int id);
    }
}
