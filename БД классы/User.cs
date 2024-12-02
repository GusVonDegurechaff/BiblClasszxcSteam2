using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ihatedthiswork
{
    public partial class User
    {
        public User()
        {
            Friends = new HashSet<Friend>();
            Profiles = new HashSet<Profile>();
            UserGames = new HashSet<UserGame>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? ProfilePicture { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<UserGame> UserGames { get; set; }
    }

}
