using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemLib.Contracts
{
    public interface IMolar
    {
        public double NumOfMole(double Given_mass, double Molar_mass);
        public double GivenMass(double NumOfMole, double Molar_mass);
        public double MolarMass(double Given_Mass, double NumOfmole);
    }
}
