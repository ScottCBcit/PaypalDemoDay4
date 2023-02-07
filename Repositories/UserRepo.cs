using Microsoft.EntityFrameworkCore;
using WebSecurityDay3.Data;
using WebSecurityDay3.ViewModel;

namespace WebSecurityDay3.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<UserVM> GetAllUsers()
        {
            IEnumerable<UserVM> users =
            _context.Users.Select(u => new UserVM()
            {
                Email = u.Email,
            });

            return users;
        }
    }
}
