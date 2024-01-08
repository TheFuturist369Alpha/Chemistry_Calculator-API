using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repo;
using Infrastructure;

namespace Tests
{
    public class UnitOfWorkTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SciDbContext _context;

        public UnitOfWorkTest()
        {
            _context = new SciDbContext(
                new DbContextOptionsBuilder().UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Periodic Table;
                                    Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
                      Application Intent=ReadWrite;Multi Subnet Failover=False").Options

                );
            _unitOfWork = new UnitOfWork(_context);
        }

        [Fact]
        public async Task SearchMass()
        {
            double? mass = await _unitOfWork.GetMassBySymbol("Na");
            Assert.Equal(22.990, mass);
        }
        
    }
}
