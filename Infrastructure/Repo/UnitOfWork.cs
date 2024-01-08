using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SciDbContext _context;

        public UnitOfWork(SciDbContext context) { 
         _context = context;
        
        }
        public async Task AddElement(Element atom)
        {
            if (atom == null)
            {
                throw new ArgumentNullException();
            }

          await  _context.Atoms.AddAsync(atom);
           await _context.SaveChangesAsync();
        }

        public async Task<List<Element>>GetAllElements()
        {
            if(await _context.Atoms.CountAsync() == 0)
            {
                return null;
            }
            return await _context.Atoms.ToListAsync();
        }

        public async Task<Element> GetElementByAtomicNum(int atomicNum)
        {
            Element? atom=await _context.Atoms.FirstOrDefaultAsync(obj=>obj.AtomicNumber == atomicNum);
            return atom;

        }

        public async Task<double?> GetMassBySymbol(string symbol)
        {
            if (symbol == null)
            {
                return null;
            }
            Element i=await _context.Atoms.FirstOrDefaultAsync(obj=>obj.Symbol== symbol);
            if (i != null)
            {
                return i.AtomicMass;
            }
            return null;
        }
    }
}
