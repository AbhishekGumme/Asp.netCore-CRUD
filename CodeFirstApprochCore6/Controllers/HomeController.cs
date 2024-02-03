using CodeFirstApprochCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstApprochCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studebtDb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDBContext studebtDb)
        {
            this.studebtDb = studebtDb;
        }
        public IActionResult Index()
        {
            var setData = studebtDb.Students.ToList();
            return View(setData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if(ModelState.IsValid)
            {
                studebtDb.Students.Add(std);
                studebtDb.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Edit(int ? id)
        {
            var setData = await studebtDb.Students.FindAsync(id);
            return View(setData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}