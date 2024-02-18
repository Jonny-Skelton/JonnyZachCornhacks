using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentifyingArbitrage.Models;
public class Game
{
        public List<Team> Teams { get; set; }
        
        public DateTime dateTime { get; set; }
        public bool IsArbitrage
        {
            get
            {
                return Teams.Sum(team => team.ImpliedOdds) < 100;
            }
        }

        // Constructor to initialize the teams and odds
        public Game(List<Team> teams)
        {
            Teams = teams ?? throw new ArgumentNullException(nameof(teams));
        }

}