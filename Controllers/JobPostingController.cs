using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using Worktastic.Data;
using Worktastic.Models;

namespace Worktastic.Controllers
{
    public class JobPostingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JobPostingController(ApplicationDbContext context) //Dependency Injection
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEditJobPosting(int id)
        {
            return View();
        }

        public IActionResult CreateEditJob(JobPosting jobPosting, IFormFile file)
        {
            if(file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var bytes = ms.ToArray();
                    jobPosting.CompanyImage = bytes;
                }
            }

            //Write jobposting to database

            //Add new job if not editing
            if(jobPosting.Id == 0)
            {
                _context.JobPostings.Add(jobPosting);

                _context.SaveChanges();
            }else
            {
                var jobFromDb = _context.JobPostings.SingleOrDefault(x => x.Id == jobPosting.Id);

                if(jobFromDb == null)
                {
                    return NotFound();
                }

                jobFromDb.JobTitle = jobPosting.JobTitle;
                jobFromDb.JobLocation = jobPosting.JobLocation;
                jobFromDb.Salary = jobPosting.Salary;
                jobFromDb.StartDate = jobPosting.StartDate;
                jobFromDb.CompanyName = jobPosting.CompanyName;
                jobFromDb.ContactWebsite = jobPosting.ContactWebsite;
                jobFromDb.ContactPhone = jobPosting.ContactPhone;
                jobFromDb.ContactMail = jobPosting.ContactMail;
                jobFromDb.Description = jobPosting.Description;
                jobFromDb.CompanyImage = jobPosting.CompanyImage;

                //(_context.JobPostings.Update(jobPosting);) Kurze Schreibweise
            }

            return RedirectToAction("Index"); //navigate to public IActionResult Index()
        }
    }
}
