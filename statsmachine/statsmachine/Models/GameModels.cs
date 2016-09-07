using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statsmachine.Models
{

    public class Game
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }

    public class UserGame
    {
        [Key]
        [Column(Order = 0)]
        public string userid { get; set; }
        [Key]
        [Column(Order = 1)]
        public Guid gameid { get; set; }
    }

    /*
    public class GameLog.Warmachine { 

    }
    */

}