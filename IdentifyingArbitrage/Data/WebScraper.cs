namespace IdentifyingArbitrage.Data;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

public class Webscraper
{
    public void ScrapeData()
    {
        // Replace this link with the actual link you want to scrape
        string url = "https://www.covers.com/sport/basketball/ncaab/odds";

        // Make an HTTP request to the webpage
        //string htmlContent = ;

        // Load the HTML document
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(GetHtmlContent(url));

        // Select the rows with the 'oddsGameRow' class
        var gameRows = doc.DocumentNode.SelectNodes("//tr[@class='oddsGameRow']");

        if (gameRows != null)
        {
            foreach (var row in gameRows)
            {
                // Extract date and time
                var dateTimeNode = row.SelectSingleNode(".//div[@class='td-cell game-time']/span[2]");
                string dateTime = dateTimeNode != null ? dateTimeNode.InnerText.Trim() : "";

                // Extract team names
                var teamNodes = row.SelectNodes(".//div[@class='div-cell teams-div']//a/strong");
                string awayTeam = teamNodes != null && teamNodes.Count > 0 ? teamNodes[0].InnerText.Trim() : "";
                string homeTeam = teamNodes != null && teamNodes.Count > 1 ? teamNodes[1].InnerText.Trim() : "";

                // Extract moneylines
                var moneylineNodes = row.SelectNodes(".//span[@class='American __american']");
                string awayMoneyline = moneylineNodes != null && moneylineNodes.Count > 0 ? moneylineNodes[0].InnerText.Trim() : "";
                string homeMoneyline = moneylineNodes != null && moneylineNodes.Count > 1 ? moneylineNodes[1].InnerText.Trim() : "";

                // Print or process the collected data
                Console.WriteLine($"Date/Time: {dateTime}");
                Console.WriteLine($"Away Team: {awayTeam}, Moneyline: {awayMoneyline}");
                Console.WriteLine($"Home Team: {homeTeam}, Moneyline: {homeMoneyline}");
                Console.WriteLine();
            }
        }
    }

    static string GetHtmlContent(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return client.GetStringAsync(url).Result;
        }
    }
}
//     
//     private List<string> ParseHtml(string html)
//     {
//         HtmlDocument htmlDoc = new HtmlDocument();
//         htmlDoc.LoadHtml(html);
//     
//         var programmerLinks = htmlDoc.DocumentNode.Descendants("li")
//             .Where(node => !node.GetAttributeValues("class", "").Contains("tocsection"))
//             .ToList();
//     
//         List<string> coverLink = new List<string>();
//     
//         foreach (var link in programmerLinks)
//         {
//             if (link.FirstChild.Attributes.Count > 0)
//                 coverLink.Add("https://www.covers.com/sport/basketball/ncaab/odds/" +
//                               link.FirstChild.Attributes[0].Value);
//         }
//     
//         return coverLink;
//     }
//}
