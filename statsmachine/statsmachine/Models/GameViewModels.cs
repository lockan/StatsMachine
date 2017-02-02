using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace statsmachine.Models
{
    public class WarmachineGameViewModel
    {
        
        [Required]
        public string UserId { get; set; }

        [Required]
        public Enums.WarmachineFaction faction { get; set; }

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

        public string opponent { get; set; }

        public Enums.WarmachineFaction opponentFaction { get; set; }

        public string opponentCaster { get; set; }

        public int opponentPoints { get; set; }
    }
}