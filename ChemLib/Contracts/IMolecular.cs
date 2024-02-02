using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemLib.Contracts
{
    public interface IMolecular
    {
        public Task<double> MolecularMass(string molecule);
        public Task SetElementsForEMF(string element, double percent_compo);
        public Task<string?> CalculateEMF(double? totalGrams);


    }
}
