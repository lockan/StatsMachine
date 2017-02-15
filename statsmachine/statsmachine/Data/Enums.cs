using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statsmachine.Models
{
    public class Enums
    {
        public enum GameTitle
        {
            Warmachine
        }

        public enum WarmachineFaction
        {
            None,
            Circle,
            Convergence,
            Cryx,
            Cygnar,
            Everblight,
            Khador,
            Mercenaries,
            Minions,
            Protectorate,            
            Retribution,
            Skorne,
            Trollbloods
        }

        public enum WarmachineGameResult
        {
            Win, 
            Loss, 
            Tie
        }

        public enum WarmachineResultType
        {
            Scenario,
            Assassination,
            DeathClock
        }

    }

}