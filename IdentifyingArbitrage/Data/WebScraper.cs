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

<<<<<<< HEAD
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using static System.Net.WebRequestMethods;

public class Webscraper
{
    public Webscraper()
    {
        string source = "https://www.covers.com/sport/basketball/ncaab/odds";
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load(source);
        IEnumerable<HtmlNode> nodes =
            document.DocumentNode.Descendants(0)
                .Where(n => n.HasClass("oddsGameRow"));
        foreach (HtmlNode node in nodes)
        {
            Console.WriteLine(node);
        }
    }
}
=======
public class Webscraper
{
    private static async Task<string> CallUrl(string fullUrl)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(fullUrl);
        return response;
    }

    public IActionResult Index()
    {
        string url = "https://www.covers.com/sport/basketball/ncaab/odds";
        var response = CallUrl(url).Result;
        return View();
    }

    private List<string> ParseHtml(string html)
    {
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        var programmerLinks = htmlDoc.DocumentNode.Descendants("li")
            .Where(node => !node.GetAttributeValues("class", "").Contains("tocsection"))
            .ToList();

        List<string> coverLink = new List<string>();

        foreach (var link in programmerLinks)
        {
            if (link.FirstChild.Attributes.Count > 0)
                coverLink.Add("https://www.covers.com/sport/basketball/ncaab/odds/" +
                              link.FirstChild.Attributes[0].Value);
        }

        return coverLink;
    }

}
>>>>>>> b23436f5469b97fe862573a9c6e8433c232ff832
