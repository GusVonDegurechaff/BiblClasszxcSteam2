﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ihatedthiswork
{
    public partial class UserGame
    {
        public int UserGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }

}
