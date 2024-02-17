using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentifyingArbitrage.Models;
public class Game
{
        private List<Team> Teams { get; set; }

        public bool IsArbitrage
        {
            get
            {
                // Your logic to determine if it's an arbitrage
                // For example, checking if the sum of odds is less than 1
                return CalculateTotalOdds() < 1;
            }
        }

        // Constructor to initialize the teams and odds
        public Game(List<Team> teams)
        {
            Teams = teams ?? throw new ArgumentNullException(nameof(teams));
        }

        // Method to calculate the total odds for all teams
        private double CalculateTotalOdds()
        {
            //TODO calculate here
            return 1;
        }
}