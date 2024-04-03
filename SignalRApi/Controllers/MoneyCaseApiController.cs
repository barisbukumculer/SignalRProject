using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseApiController : ControllerBase
    {
        private readonly IMoneyCasesService _moneyCasesService;

        public MoneyCaseApiController(IMoneyCasesService moneyCasesService)
        {
            _moneyCasesService = moneyCasesService;
        }
        [HttpGet("TotalMoneyCaseAmount")]
        public IActionResult TotalMoneyCaseAmount() 
        {
            return Ok(_moneyCasesService.TTotalMoneyCaseAmount());
        }
    }
}
