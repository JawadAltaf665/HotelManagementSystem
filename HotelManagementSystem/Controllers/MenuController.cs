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

        //[HttpGet("GetAllMenus")]
        //public async Task<Response> GetAllMenusAsync()
        //{
        //    return await _menuAppService.GetAllMenusAsync();
        //}
    }
}
