using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemLib.Contracts
{
    public interface IChemData
    {
        public Task<string?> GetPeriodicTable();
    }
}
