
using Microsoft.EntityFrameworkCore;
using ChemLib.Services;
using ChemLib.Contracts;
using Models;
using Infrastructure.Repo;
using Infrastructure;
using Xunit;
using AutoFixture;
using EntityFrameworkCoreMock;

namespace Tests
{
    public class Molecular_Service_Test
    {
        private readonly IMolecular _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFixture _fixture;
        private readonly SciDbContext _context;
        

        public Molecular_Service_Test()
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

            DbContextMock<SciDbContext> mocker = new DbContextMock<SciDbContext>(new DbContextOptionsBuilder().Options);

            _context = mocker.Object;
            mocker.CreateDbSetMock(temp => temp.Atoms, elements);
            _unitOfWork = new UnitOfWork(_context);


            _service = new Molecular_Service(_unitOfWork);
              
                }

        [Fact]
        public async Task Molecular_mass()
        {
            double? mass = await _service.MolecularMass("H2O");
            Assert.Equal(18.015,mass);
        }


    }
}