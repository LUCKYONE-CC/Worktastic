using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Worktastic.Data;

namespace Worktastic.Controllers
{
    [Route("api/jobposting")]
    [ApiController]
    public class ApiJobPostingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ApiJobPostingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var allJobPostings = _context.JobPostings.ToArray();

            return Ok(allJobPostings);
        }
    }
}
