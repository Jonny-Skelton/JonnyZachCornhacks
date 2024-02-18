using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentifyingArbitrage.Models;
public class Game
{
        public List<Team> Teams { get; set; }
        
        public string Date { get; set; }
        public string Time { get; set; }

        public bool IsArbitrage
        {
            get
            {
                return Teams.Sum(team => team.ImpliedOdds) < 100;
            }
        }

}