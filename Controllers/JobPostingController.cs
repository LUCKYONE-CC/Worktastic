using Microsoft.AspNetCore.Mvc;
using Worktastic.Models;

namespace Worktastic.Controllers
{
    public class JobPostingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEditJobPosting(int id)
        {
            return View();
        }

        public IActionResult CreateEditJob(JobPosting jobPosting)
        {
            //Write jobposting to database

            return RedirectToAction("Index"); //navigate to public IActionResult Index()
        }
    }
}
