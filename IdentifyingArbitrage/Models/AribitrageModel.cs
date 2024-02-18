namespace IdentifyingArbitrage.Models;

public class ArbitrageModel
{
    public Game GameModel { get; set; }

    public double HomeTeamStake { get; set; }
    
    public double AwayTeamStake { get; set; }
    
    public double Payout { get; set; }
    
    public double ROI { get; set; }

    public ArbitrageModel(Game gameModel, double totalStake)
    {
        GameModel = gameModel;
        GetStakes(totalStake);
        GetPayout();
        ROI = Payout / totalStake;
    }
    
    public void GetStakes(double totalStakes)
    {
        AwayTeamStake = (GameModel.Teams[0].ImpliedOdds / 100) * totalStakes;
        HomeTeamStake = totalStakes - AwayTeamStake;
    }

    public void GetPayout()
    {
        if (GameModel.Teams[0].BestOdds > 0)
        {
            Payout = ((GameModel.Teams[0].BestOdds + 100) / 100) * AwayTeamStake;
        }
        else
        {
            Payout = ((100/GameModel.Teams[0].BestOdds) + 1) * AwayTeamStake;
        }
    }
    
}