using HotelManagementSystem.Dtos;
using HotelManagementSystem.IAppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuAppService _menuAppService;

        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        [HttpGet("GetAllMenusAsync")]
        public async Task<Response> GetAllMenusAsync()
        {
            return await _menuAppService.GetAllMenusAsync();
        }

        [HttpGet("GetMenuByIdAsync/{id}")]
        public async Task<Response> GetMenuByIdAsync(int id)
        {
            return await _menuAppService.GetMenuByIdAsync(id);
        }

        [HttpPost("CreateMenuAsync")]
        public async Task<Response> CreateMenuAsync([FromBody] MenuItemDTO input)
        {
            return await _menuAppService.CreateMenuAsync(input);
        }

        [HttpPut("UpdateMenuAsync")]
        public async Task<Response> UpdateMenuAsync([FromBody] MenuItemDTO input)
        {
            return await _menuAppService.UpdateMenuAsync(input);
        }

        [HttpDelete("DeleteMenuAsync/{id}")]
        public async Task<Response> DeleteMenuAsync(int id)
        {
            return await _menuAppService.DeleteMenuAsync(id);
        }
    }
}
