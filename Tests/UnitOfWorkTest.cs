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
using AutoFixture;
using AutoFixture.Kernel;

namespace Tests
{
    public class UnitOfWorkTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SciDbContext _context;
        private readonly IFixture _fixture;

        public UnitOfWorkTest()
        {
            _fixture = new Fixture();
            List<Element> elements = new List<Element>() {
            _fixture.Build<Element>().With(temp=>temp.Name, "Hydrogen")
            .With(temp=>temp.AtomicNumber,1).With(temp=>temp.AtomicMass,1.0080)
            .With(temp=>temp.Symbol,"H").Create(),  
                
                _fixture.Build<Element>().With(temp=>temp.Name, "Oxygen")
            .With(temp=>temp.AtomicNumber,8).With(temp=>temp.AtomicMass, 15.999)
            .With(temp=>temp.Symbol,"O").Create()

            };

            DbContextMock<SciDbContext> mocker= new DbContextMock<SciDbContext>(new DbContextOptionsBuilder().Options);

            _context = mocker.Object;
            mocker.CreateDbSetMock(temp => temp.Atoms, elements);
            _unitOfWork = new UnitOfWork(_context);
        }

        [Fact]
        public async Task SearchMass()
        {
            double? mass = await _unitOfWork.GetMassBySymbol("Mg");
            Assert.Equal(24.305, mass);
        }
        
    }
}
