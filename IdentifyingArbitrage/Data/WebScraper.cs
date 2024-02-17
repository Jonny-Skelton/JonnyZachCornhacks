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