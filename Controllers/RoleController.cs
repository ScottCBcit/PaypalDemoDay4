using Microsoft.AspNetCore.Mvc;
using WebSecurityDay3.Data;
using WebSecurityDay3.Repositories;
using WebSecurityDay3.ViewModel;

namespace WebSecurityDay3.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Role
        public ActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_context);
            return View(roleRepo.GetAllRoles());
        }

        [HttpGet]
        public ActionResult Create()
        {
            RoleRepo roleRepo = new RoleRepo(_context);
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoleVM roleVM)
        {
            RoleRepo roleRepo = new RoleRepo(_context);

            try
            {
                roleRepo.CreateRole(roleVM.RoleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");

        }

    }

}
