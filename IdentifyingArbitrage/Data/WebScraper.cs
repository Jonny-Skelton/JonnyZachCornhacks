using System.Net;
using IdentifyingArbitrage.Models;

namespace IdentifyingArbitrage.Data;
using HtmlAgilityPack;
using System.Net.Http;


public class Webscraper
{
    public List<DataModel> ScrapeData()
    {
        string url = "https://www.covers.com/sport/basketball/ncaab/odds";

        HtmlDocument doc = new HtmlDocument();

        string htmlContent = GetHtmlContent(url);
        doc.LoadHtml(htmlContent);

        // Select the rows with the 'oddsGameRow' class
        var gameRows = doc.DocumentNode.SelectNodes("(//tr[@class='oddsGameRow'])[position() <= 25]");
        
        List<DataModel> dataModels = new List<DataModel>();
        if (gameRows != null)
        {
            foreach (var row in gameRows)
            {
                // Extract date and time
                //var dateTimeNode = row.SelectSingleNode(".//div[@class='td-cell game-time']/span[2]");
                var dateTimeNode = row.SelectNodes(".//div[@class='td-cell game-time']/span");
                string date = dateTimeNode != null ? dateTimeNode[0].InnerText.Trim() : "";
                date = date.Replace(",&nbsp;", "");
                string time = dateTimeNode != null ? dateTimeNode[1].InnerText.Trim() : "";
                
                // Extract team names
                var teamNodes = row.SelectNodes(".//div[@class='div-cell teams-div']//a/strong");
                string awayTeam = teamNodes != null && teamNodes.Count > 0 ? teamNodes[0].InnerText.Trim() : "";
                string homeTeam = teamNodes != null && teamNodes.Count > 1 ? teamNodes[1].InnerText.Trim() : "";

                // Extract moneylines
                var moneylineNodes = row.SelectNodes(".//span[@class='American __american']");

                string awayMoneyline = moneylineNodes != null && moneylineNodes.Count > 0
                    ? WebUtility.HtmlDecode(moneylineNodes[0].InnerText.Trim())
                    : "";

                string homeMoneyline = moneylineNodes != null && moneylineNodes.Count > 1
                    ? WebUtility.HtmlDecode(moneylineNodes[1].InnerText.Trim())
                    : "";
                
                //individual book line
                
                DataModel dataModel = new DataModel
                {
                    AwayTeam = awayTeam,
                    HomeTeam = homeTeam,
                    AwayMoneyLine = awayMoneyline,
                    HomeMoneyLine = homeMoneyline,
                    Time = time,
                    Date = date
                };

                // Extract individual sportsbook moneylines
                var bookNodes = row.SelectNodes(".//td[contains(@class, 'covers-CoversMatchups-centerAlignHelper')]");
                if (bookNodes != null)
                {
                    foreach (var bookNode in bookNodes)
                    {
                        var bookName = bookNode.SelectSingleNode(".//img")?.Attributes["alt"]?.Value;
                        var awayBookMoneyline = bookNode.SelectSingleNode(".//div[@class='td-cell away-cell']//a[contains(@class, 'moneyline')]/span[@class='American __american']");
                        var homeBookMoneyline = bookNode.SelectSingleNode(".//div[@class='td-cell home-cell']//a[contains(@class, 'moneyline')]/span[@class='American __american']");

                        if (!string.IsNullOrEmpty(bookName) && awayBookMoneyline != null && homeBookMoneyline != null)
                        {
                            string awayLine = WebUtility.HtmlDecode(awayBookMoneyline.InnerText.Trim());
                            string homeLine = WebUtility.HtmlDecode(homeBookMoneyline.InnerText.Trim());
                            
                            //remove '+"
                            awayLine = awayLine.Replace("+", "");
                            homeLine = homeLine.Replace("+", "");

                            dataModel.AwayMoneylines[bookName] = Int32.Parse(awayLine);
                            dataModel.HomeMoneylines[bookName] = Int32.Parse(homeLine);
                        }
                    }
                }
                
                dataModels.Add(dataModel);
                }
            }
        return dataModels;
    }
    static string GetHtmlContent(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return client.GetStringAsync(url).Result;
        }
    }
}
