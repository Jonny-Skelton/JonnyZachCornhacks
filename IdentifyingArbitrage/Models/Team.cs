namespace IdentifyingArbitrage.Models;

public class Team
{
    public string Name { get; set; }
    public string AmericanOdds { get; set; }
    public string BestBook { get; set; }
    public double BestOdds { get; set; }
    
    public double ImpliedOdds
    {
        get
        {
            return CalculateImplied();
        }
    }

    public Team(string name, string americanOdds, Dictionary<string, int> moneylines)
    {
        Name = name;
        AmericanOdds = americanOdds;
        SetBestBookAndOdds(moneylines);
    }

    private void SetBestBookAndOdds(Dictionary<string, int> moneylines)
    {
        if (moneylines.Count > 0)
        {
            var bestBookLine = moneylines.OrderByDescending(kv => Math.Abs(kv.Value)).First();
            BestBook = bestBookLine.Key;
            BestOdds = bestBookLine.Value;
        }
        else
        {
            BestBook = null;
            BestOdds = 0;
        }
    }

    private double CalculateImplied()
    {
        double implied = 0;
        string temp = AmericanOdds.Replace("+", "");
        double odds = Int32.Parse(temp);
        if (odds > 0)
        {
            implied = 100 / ((odds / 100) + 1);
        }else
        {
            implied = 100 / ((100/odds) + 1);
        }
        return implied;
    }
}