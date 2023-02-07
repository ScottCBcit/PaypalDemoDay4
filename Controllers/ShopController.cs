using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSecurityDay3.Models;
using WebSecurityDay3.Data;
using WebSecurityDay3.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace WebSecurityDay3.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ProductRepo productRepo = new(_context);
            var products = productRepo.GetAllProducts();
            return View(products);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        [Authorize(Roles = "Manager")]
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;



            return View(items);
        }

        // This method receives and stores
        // the Paypal transaction details.
        [HttpPost]
        public JsonResult PaySuccess([FromBody] IPN ipn)
        {
            try
            {
                _context.IPNs.Add(ipn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(ipn);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Confirmation(string confirmationId)
        {
            IPN transaction =
            _context.IPNs.FirstOrDefault(t => t.paymentID == confirmationId);

            return View("Confirmation", transaction);
        }
    }
}
