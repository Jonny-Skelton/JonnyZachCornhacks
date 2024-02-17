namespace IdentifyingArbitrage.Data;

public class DataManager
{
    //this is going to call the webscraper data into the dataModel
    private Webscraper _webscraper = new Webscraper();
    public void GetData()
    {
        _webscraper.ScrapeData();
    }
}