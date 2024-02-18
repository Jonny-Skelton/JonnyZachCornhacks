using IdentifyingArbitrage.Models;

namespace IdentifyingArbitrage.Data;

public class DataManager
{
    //this is going to call the webscraper data into the dataModel
    private Webscraper _webscraper = new Webscraper();
    public List<Game> GetData()
    {
        List<Game> gameData = new List<Game>();
        List<DataModel> results = new List<DataModel>();
        results = _webscraper.ScrapeData();
        
        foreach (DataModel dm in results)
        {
            Game game = DataHelper.DataModelToGame(dm);
            gameData.Add(game);
        }
        
        return gameData;
    }
}