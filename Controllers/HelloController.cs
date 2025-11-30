using Microsoft.AspNetCore.Mvc;

namespace DockerWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // 回傳簡單的訊息與當前主機名稱 (確認是由哪個 Container 回應)
            var message = new 
            { 
                Status = "Success", 
                Message = "Hello Docker from .NET 8", 
                Host = System.Environment.MachineName 
            };
            
            return Ok(message);
        }
    }
}