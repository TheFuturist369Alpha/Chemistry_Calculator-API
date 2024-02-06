using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemLib.Contracts;
using HtmlAgilityPack;

namespace ChemLib.Services
{
    public class ChemData : IChemData
    {
        public async Task<string?> GetPeriodicTable()
        {
            string url = "https://ptable.com/?lang=en#Properties";
            HttpClient client = new HttpClient();
            var html = await client.GetStringAsync(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            var PTElement = document.DocumentNode.SelectSingleNode(@"//li[@class='Alkaline s Solid']");
            string texts = PTElement.InnerText.Trim();

            return texts;

        }
    }
}
