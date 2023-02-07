using System.ComponentModel.DataAnnotations;

namespace WebSecurityDay3.ViewModel
{
    public class UserVM
    {
        [Key]
        public string Email { get; set; }
    }
}
