
using Microsoft.EntityFrameworkCore;
using ChemLib.Services;
using ChemLib.Contracts;
using Models;
using Infrastructure.Repo;
using Infrastructure;
using Xunit;

namespace Tests
{
    public class Molecular_Service_Test
    {
        private readonly IMolecular _service;
        

        public Molecular_Service_Test()
        {
            _service = new Molecular_Service(new UnitOfWork(
                new SciDbContext(new DbContextOptionsBuilder().UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Periodic Table;
                                    Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
                      Application Intent=ReadWrite;Multi Subnet Failover=False").Options)));
              
                }

        [Fact]
        public async Task Molecular_mass()
        {
            double? mass = await _service.MolecularMass("H20");
            Assert.Equal(18.015,mass);
        }


    }
}