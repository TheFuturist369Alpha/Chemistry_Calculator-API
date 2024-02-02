
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
            .With(temp=>temp.AtomicNumber,1).With(temp=>temp.AtomicMass,1.00794)
            .With(temp=>temp.Symbol,"H").Create(),

                _fixture.Build<Element>().With(temp=>temp.Name, "Oxygen")
            .With(temp=>temp.AtomicNumber,8).With(temp=>temp.AtomicMass, 15.9994)
            .With(temp=>temp.Symbol,"O").Create(),

                 _fixture.Build<Element>().With(temp=>temp.Name, "Magnesium")
            .With(temp=>temp.AtomicNumber,12).With(temp=>temp.AtomicMass, 24.3050)
            .With(temp=>temp.Symbol,"Mg").Create(),

                   _fixture.Build<Element>().With(temp=>temp.Name, "Sodium")
            .With(temp=>temp.AtomicNumber,11).With(temp=>temp.AtomicMass, 22.990)
            .With(temp=>temp.Symbol,"Na").Create(),


                   _fixture.Build<Element>().With(temp=>temp.Name, "Carbon")
            .With(temp=>temp.AtomicNumber,6).With(temp=>temp.AtomicMass, 12.011)
            .With(temp=>temp.Symbol,"C").Create(),

                   _fixture.Build<Element>().With(temp=>temp.Name, "Sulphur")
            .With(temp=>temp.AtomicNumber,16).With(temp=>temp.AtomicMass, 32.06)
            .With(temp=>temp.Symbol,"S").Create(),


                   _fixture.Build<Element>().With(temp=>temp.Name, "Nitrogen")
            .With(temp=>temp.AtomicNumber,7).With(temp=>temp.AtomicMass, 14.007)
            .With(temp=>temp.Symbol,"N").Create()

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
            double mass = Math.Round(await _service.MolecularMass("NaOH"),2);
            Assert.Equal(40.00, mass);
            
        }

        [Fact]
        public async Task EmpiricalFormula()
        {
            await _service.SetElementsForEMF("C", 38.8);
            await _service.SetElementsForEMF("H", 16.2);
            await _service.SetElementsForEMF("N", 45.1);
            //await _service.SetElementsForEMF("Mg", 23.3);
            //await _service.SetElementsForEMF("S", 30.7);
            //await _service.SetElementsForEMF("O", 46.0);
            string? act=await _service.CalculateEMF();
            Assert.Equal("O:1 H:1", act);
        }


    }
}