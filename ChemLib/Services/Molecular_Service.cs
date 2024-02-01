using ChemLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repo;
using System.Text.RegularExpressions;

namespace ChemLib.Services
{
    public class Molecular_Service : IMolecular
    {
        private readonly IUnitOfWork _context;

        public Molecular_Service(IUnitOfWork context)
        {
            _context = context;

        }

        private async Task<double> processString(string a)
        {
            double val = 0.0;
            string expr = @"([A-Z][a-z]?(\d*))";

            string newStr = Regex.Replace(a, expr, "$1 ").Trim();
            string[] arr = newStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string expr0 = @"^[A-Z][a-z]?$";
            string expr1 = @"[A-Z][a-z]?\d+";
            string expr2 = @"\d+";
            string expr3 = @"[a-zA-Z]+";
            foreach (var i in arr)
            {
                bool ask = Regex.IsMatch(i, expr0);
                if (ask)
                {
                    val += await _context.GetMassBySymbol(i);
                }
                else if(Regex.IsMatch(i, expr1))
                {
                    double vlu = 0;
                    string str = Regex.Replace(i, expr2, "");

                    vlu += await _context.GetMassBySymbol(str);

                    int num = Convert.ToInt32(Regex.Replace(i,expr3 , ""));
                    vlu *= num;
                    
                    val+=vlu;

                }


            }
            return val;
        }




        public async Task<double> MolecularMass(string molecularFormula)
        {
            string compr0 = @"[(a-z)?A-Z(\d)?]+";

            if (Regex.IsMatch(molecularFormula, compr0))
            {
                string compr1 = @"^\d+[(a-z)?A-Z(\d)?]+";
               

                if (Regex.IsMatch(molecularFormula, compr1))
                {

                    int firstc=Convert.ToInt32(Regex.Replace(molecularFormula, @"(^\d+).*", "$1"));

                    return (await processString(Regex.Replace(molecularFormula, @"^\d+", ""))) * firstc;



                }

                return await processString(molecularFormula);
            }

            else
            {
                return 0.000;
            }


           
            }
        }
    }

