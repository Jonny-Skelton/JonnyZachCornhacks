using IdentifyingArbitrage.Models;

namespace IdentifyingArbitrage.Data;

public class DataHelper
{

    public static Game DataModelToGame(DataModel dm)
    {
        List<Team> teams = new List<Team>
        {
            new Team(dm.AwayTeam, dm.AwayMoneyLine, dm.AwayMoneylines),
            new Team(dm.HomeTeam, dm.HomeMoneyLine, dm.HomeMoneylines)
        };

        teams[0].ImgUrl = dm.AwayImgUrl;
        teams[1].ImgUrl = dm.HomeImgUrl;
        
        return new Game
        {
            Teams = teams,
            Date = dm.Date,
            Time = dm.Time
        };
    }
}