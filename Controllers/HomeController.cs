using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSecurityDay3.Models;
using WebSecurityDay3.Data;

namespace WebSecurityDay3.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Home page.
        public IActionResult Index()
        {
            return View("Index");
        }

        

    }
}