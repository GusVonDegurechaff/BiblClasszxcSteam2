using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ihatedthiswork
{
    public class Game
    {
        public Game()
        {
            Profiles = new HashSet<Profile>();
            UserGames = new HashSet<UserGame>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? CoverImage { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<UserGame> UserGames { get; set; }
    }
