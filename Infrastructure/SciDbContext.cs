
using Microsoft.EntityFrameworkCore;
using Models;
using System.IO;
using System.Text.Json;

namespace Infrastructure
{
    public class SciDbContext:DbContext
    {
        public SciDbContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<Element> Atoms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Element>().ToTable("Atoms");

            string txtfile = File.ReadAllText("Atoms.json");
            List<Element>? atoms = JsonSerializer.Deserialize<List<Element>>(txtfile);

            foreach(var atom in atoms)
            {
                modelBuilder.Entity<Element>().HasData(atom);
            }

        }
      
    }
}