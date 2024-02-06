using ChemLib.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Chemistry_Calculator_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MolecularController : ControllerBase
    {
        private readonly IMolecular _moleService;
        public MolecularController(IMolecular moleService)
        {
            _moleService = moleService;
        }

        [HttpPost("/molecular mass/{formula}")]
        public async Task<ActionResult<double>> Calculate_Molecular_Mass(string formula)
        {
            if(string.IsNullOrWhiteSpace(formula))
            {
                return BadRequest("Input for 'Calculate_Molecular_Mass' is null or empty");
            }

         return await _moleService.MolecularMass(formula);

        }

        [HttpPost("/Empirical Formula/")]
        public async Task<ActionResult<string?>> Calculate_Empirical_Formula(List<Empirical> emp)
        {
            if (!(emp.Count == 0))
            {
                foreach(var i in emp)
                {
                    await _moleService.SetElementsForEMF(i.Name, i.percent);
                }

                return await _moleService.CalculateEMF();
            }
            return BadRequest();
        }

    }
}
