using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Worktastic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiJobPostingController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Hallo Welt!");
        }
    }
}
