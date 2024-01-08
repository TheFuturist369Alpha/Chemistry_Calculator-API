using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repo;
using Infrastructure;
using EntityFrameworkCoreMock;
using Moq;
using Models;

namespace Tests
{
    public class UnitOfWorkTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SciDbContext _context;

        public UnitOfWorkTest()
        {
            List<Element> elements = new List<Element>() { };

            DbContextMock<SciDbContext> mocker= new DbContextMock<SciDbContext>(new DbContextOptionsBuilder().Options);

            _context = mocker.Object;
            mocker.CreateDbSetMock(temp => temp.Atoms, elements);
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
