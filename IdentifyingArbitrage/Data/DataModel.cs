namespace IdentifyingArbitrage.Data;

public class DataModel
{
    public string AwayTeam { get; set; }
    public string HomeTeam { get; set; }
    public string AwayMoneyLine { get; set; }
    public string HomeMoneyLine { get; set; }
    public string Time { get; set; }
    public string Date { get; set; }
    
    public Dictionary<string, int> AwayMoneylines { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, int> HomeMoneylines { get; set; } = new Dictionary<string, int>();
}