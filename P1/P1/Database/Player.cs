using System;
using System.Collections.Generic;

#nullable disable

namespace Database
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string PlayerFname { get; set; }
        public string PlayerLname { get; set; }
        public int? PlayerAge { get; set; }
    }
}
