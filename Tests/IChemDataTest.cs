using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ChemLib.Services;

namespace Tests
{
    public class IChemDataTest
    {
        [Fact]
        public async Task Checktexts()
        {
            string? a = await new ChemData().GetPeriodicTable();
            Assert.Equal(" ", a);
        }

    }
}
