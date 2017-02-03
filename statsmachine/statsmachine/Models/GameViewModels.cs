using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace statsmachine.Models
{
    public class WarmachineGameLimitedViewModel
    {
        public string gameid { get; set; }

        public string UserId { get; set; }

        public string playername { get; set; }

        public Enums.WarmachineFaction faction { get; set; }

        public string armyicon { get; set; }

        public string opponentId { get; set; }

        public string opponentname { get; set; }

        public Enums.WarmachineFaction opponentFaction { get; set; }

        public string enemyicon { get; set; }

        public Enums.WarmachineGameResult result { get; set; }

    }

    public class WarmachineGameViewModel
    {
        public string gameid { get; set; }

        public string UserId { get; set; }
        
        public string playername { get; set; }

        public Enums.WarmachineFaction faction { get; set; }

        public string armyicon { get; set; }

        public string opponentId { get; set; }

        public string opponentname { get; set; }

        public Enums.WarmachineFaction opponentFaction { get; set; }

        public string enemyicon { get; set; }

        public int? pointSize { get; set; }

        public Enums.WarmachineGameResult result { get; set; }

        public Enums.WarmachineResultType resultType { get; set; }

        public string scenario { get; set; }

        public int? controlPoints { get; set; }

        public string opponentCaster { get; set; }

        public int? opponentPoints { get; set; }
    }
}