
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.IO;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using Microsoft.Playwright;

namespace Infrastructure
{
    public class SciDbContext:DbContext
    {
        public SciDbContext(DbContextOptions opts) : base(opts)
        {

        }

        public virtual DbSet<Element> Atoms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Element>().ToTable("Atoms");

            /* string txtfile = File.ReadAllText("Atoms.json");
             List<Element>? atoms = JsonSerializer.Deserialize<List<Element>>(txtfile);

             foreach(var atom in atoms)
             {
                 modelBuilder.Entity<Element>().HasData(atom);
             }
            

            string url = "https://pubchem.ncbi.nlm.nih.gov/periodic-table/", 
            url1= "https://pubchem.ncbi.nlm.nih.gov/periodic-table/#view=list";

            HttpClient client = new HttpClient(), client1=new HttpClient();
            var html =client.GetStringAsync(url).Result;
            var html1=client.GetStringAsync(url1).Result;
            HtmlDocument document = new HtmlDocument();
            HtmlDocument document1 = new HtmlDocument();
            document.LoadHtml(html);
            document1.LoadHtml(html1);

            var Symbols = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"font-medium text-3xs xxs:text-2xs
                     xs:text-sm sm:text-base md:text-lg lg:text-xl print:lg:text-2xl xl:text-2xl print:font-bold"))
                .ToList();

            var Mass_Numbers = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"hidden xl:block text-2xs py-1  truncate"))
                .ToList();

            var Atomic_Numbers = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"text-center xl:text-left font-medium text-3xs xs:text-xs xl:text-sm 2xl:text-base xl:flex-1 xl:pr-1"))
                .ToList();

            var Names = document1.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"text-2xl"))
                .ToList();

            List<Element> element= new List<Element>();

            for(int i=0; i<Symbols.Count; i++)
            {
                element.Add(new Element()
                {
                    Symbol = Symbols[i].InnerText.Trim(),
                    Name = Names[i].InnerText.Trim(),
                    AtomicMass = Convert.ToDouble(Mass_Numbers[i].InnerText.Trim()),
                    AtomicNumber = Convert.ToInt32(Atomic_Numbers[i].InnerText.Trim()),
                    Id = new Guid(),
                    ElectroValency=0
                    


                });
            }

            foreach (var atom in element)
            {
                modelBuilder.Entity<Element>().HasData(atom);
            }*/


        }

        public async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using(var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SciDbContext>();
                if (!context.Atoms.Any())
                {
                    var elements = await Scrape();

                    foreach (var atom in elements)
                    {
                        context.Atoms.Add(atom);
                    }
                    await context.SaveChangesAsync();


                }
            }

        }
        private async Task<List<Element>> Scrape()
        {
            Program.Main(new string[] { "install" });
            var playwrite= await Playwright.CreateAsync();

            var browser = await playwrite.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = true });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://pubchem.ncbi.nlm.nih.gov/periodic-table/");
            var html = await page.ContentAsync();
            await page.GotoAsync("https://pubchem.ncbi.nlm.nih.gov/periodic-table/#view=list");
            var html1= await page.ContentAsync();
            HtmlDocument document = new HtmlDocument();
            HtmlDocument document1 = new HtmlDocument();
            document.LoadHtml(html);
            document1.LoadHtml(html1);

            var Symbols = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"font-medium text-3xs xxs:text-2xs xs:text-sm sm:text-base md:text-lg lg:text-xl print:lg:text-2xl xl:text-2xl print:font-bold"))
                .ToList();
            Symbols.RemoveAt(0);

            var Mass_Numbers = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"hidden xl:block text-2xs py-1  truncate"))
                .ToList();

            var Atomic_Numbers = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"text-center xl:text-left font-medium text-3xs xs:text-xs xl:text-sm 2xl:text-base xl:flex-1 xl:pr-1"))
                .ToList();
            Atomic_Numbers.RemoveAt(0);

            var Names = document1.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains(@"text-2xl"))
                .ToList();

            List<Element> element = new List<Element>();

            for (int i = 0; i < 118; i++)
            {
                element.Add(new Element()
                {
                    Symbol = Symbols[i].InnerText.Trim(),
                    Name = Names[i].InnerText.Trim(),
                    AtomicMass = Convert.ToDouble(Mass_Numbers[i].InnerText.Trim()),
                    AtomicNumber = Convert.ToInt32(Atomic_Numbers[i].InnerText.Trim()),
                    Id = new Guid(),
                    ElectroValency = 0



                });
            }
            return element;

        }

    }
}