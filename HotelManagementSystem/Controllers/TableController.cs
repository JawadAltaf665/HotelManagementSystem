using HotelManagementSystem.Dtos;
using HotelManagementSystem.IAppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableAppService _tableAppService;
        public TableController(ITableAppService tableAppService)
        {
            _tableAppService = tableAppService;
        }

        [HttpGet("GetAllTables")]
        public async Task<Response> GetAllTablesAsync()
        {
            return await _tableAppService.GetAllTablesAsync();
        }
        [HttpGet("GetTableById/{id}")]
        public async Task<Response> GetTablesAsync(int id)
        {
            return await _tableAppService.GetTableByIdAsync(id);
        }

        [HttpPost("CreateTable")]
        public async Task<Response> CreateTableAsync(TableDTO input)
        {
            return await _tableAppService.CreateTableAsync(input);
        }

        [HttpPut("UpdateTable")]
        public async Task<Response > UpdateTableAsync(TableDTO input) 
        {
            return await _tableAppService.UpdateTableAsync(input.Id, input);
        }

        [HttpDelete("DeleteTable/{id}")]
        public async Task<Response> DeleteTableAsync(int id)
        {
            return await _tableAppService.DeleteTableAsync(id);
        }

    }
}
