using WebSecurityDay3.Data;
using WebSecurityDay3.Models;


namespace WebSecurityDay3.Repositories
{
    public class MyRegisteredUserRepo
    {
        ApplicationDbContext _context;

        public MyRegisteredUserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MyRegisteredUser> GetAll()
        {
            IEnumerable<MyRegisteredUser> users =
                _context.MyRegisteredUsers.ToList();
            return users;
        }

        public MyRegisteredUser Get(string email)
        {
            MyRegisteredUser user = _context.MyRegisteredUsers.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public void CreateUser (string firstName, string lastName, string email)
        {
            MyRegisteredUser registerUser = new MyRegisteredUser()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };
            _context.MyRegisteredUsers.Add(registerUser);
            _context.SaveChanges();
        }
    }
}
