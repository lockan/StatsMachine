using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace statsmachine.Models
{

    public class GameSystem
    {
        public string id { get; set; }
    }

    public class UserGame
    {
        [Key]
        [Column(Order = 0)]
        public string userid { get; set; }

        [Key]
        [Column(Order = 1)]
        public string gameid { get; set; }

    }

    /*
    public class GameLog.Warmachine { 
        
        public string faction { get; set; }

    }
    */

}