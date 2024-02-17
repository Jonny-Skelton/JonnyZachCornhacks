namespace IdentifyingArbitrage.Models;

public class Team
{
    public string Name { get; set; }
    public int Odds { get; set; }

    public Team(string name, int odds)
    {
        // Corrected assignments
        Name = name;
        Odds = odds;
    }
}