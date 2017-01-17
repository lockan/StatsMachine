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
    
    public class Warmachine {

        [Required]
        public Guid id { get; set; }

        [Required]
        public string player { get; set;  }

        [Required]
        public string faction { get; set; }

        [Required]
        public Enums.WarmachineGameResult result { get; set; }

        [Required]
        public Enums.WarmachineResultType resultType { get; set; }

        public int pointSize { get; set; }

        public string caster { get; set; }

        public string themeforce { get; set; }

        public string objective { get; set; }

        public string scenario { get; set; }

        public int controlPoints { get; set; }

        public string opponent { get; set;  }

        public string opponentCaster { get; set; }

        public int opponentPoints { get; set; }

    }

}