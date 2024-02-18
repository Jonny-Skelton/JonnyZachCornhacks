namespace IdentifyingArbitrage.Models;

public class Team
{
    public string Name { get; set; }
    public string AmericanOdds { get; set; }
    public string BestBook { get; set; }
    public double BestOdds { get; set; }

    public Team(string name, Dictionary<string, int> moneylines)
    {
        Name = name;
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
    public double ImpliedOdds
    {
        get
        {
            return CalculateImplied();
        }
    }

    private double CalculateImplied()
    {
        double implied = 0;
        if (BestOdds > 0)
        {
            implied = 100 / ((BestOdds / 100) + 1);
        }else
        {
            implied = 100 / ((100/BestOdds) + 1);
        }
        return implied;
    }
}