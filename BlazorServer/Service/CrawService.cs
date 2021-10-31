using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class CrawService
    {
        public string FromWeb(string filePath)
        {
            // From Web
            var url = filePath;
            var web = new HtmlWeb();
            var doc = web.Load(url).DocumentNode.SelectNodes("//tr[contains(@class, 'Match')]");
            return string.Join("<br/>", doc.Select(x => x.OuterHtml).ToList());
        }
    }
}
