using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Infrastructure.Repo
{
    public interface IUnitOfWork
    {
        public Task<Element> GetElementByAtomicNum(int atomicNum);
        public Task AddElement(Element atom);
        public Task<List<Element>> GetAllElements();
        public Task<double> GetMassBySymbol(string symbol);
    }
}
