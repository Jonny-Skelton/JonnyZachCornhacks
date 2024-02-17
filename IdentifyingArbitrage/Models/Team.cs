namespace IdentifyingArbitrage.Models;

public class Team
{
    public string Name { get; set; }
    public int AmericanOdds { get; set; }

    public double ImpliedOdds
    {
        get
        {
            return CalculateImplied();
        }
    }

    // public Team(string name, int americanOdds)
    // {
    //     // Corrected assignments
    //     Name = name;
    //     AmericanOdds = americanOdds;
    // }

    private double CalculateImplied()
    {
        double implied = 0;
        if (AmericanOdds > 0)
        {
            implied = 100 / (((double)AmericanOdds / 100) + 1);
        }else
        {
            implied = 100 / ((100/(double)AmericanOdds) + 1);
        }
        return implied;
    }
}