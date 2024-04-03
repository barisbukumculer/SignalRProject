using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableApiController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableApiController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("MenuTableCount")]   
        public IActionResult MenuTableCount() 
        {
        return Ok(_menuTableService.TMenuTableCount()); 
        }
    }
}
