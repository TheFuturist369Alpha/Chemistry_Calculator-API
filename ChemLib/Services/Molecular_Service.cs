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
        private Dictionary<string, double> elements;
        private double TotalPercent;

        public Molecular_Service(IUnitOfWork context)
        {
            _context = context;
            elements = new Dictionary<string, double>();
            TotalPercent = 0;
        }

        //for calculating molecular mass of molecule without a co-efficient greater than 1
        private async Task<double> processString(string a)
        {
            double val = 0.0;
            string expr = @"([A-Z][a-z]?(\d*))";

            string newStr = Regex.Replace(a, expr, "$1 ").Trim();
            string[] arr = newStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string expr0 = @"^[A-Z][a-z]?$", expr1 = @"[A-Z][a-z]?\d+", expr2 = @"\d+", expr3 = @"[a-zA-Z]+";

            foreach (var i in arr)
            {
                
                if (Regex.IsMatch(i, expr0))
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



        //for calculating molecular mass.
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
                return 0.000;
            
            }



        public async Task SetElementsForEMF(string element, double percent_compo)
        {
            if(! await _context.isElement(element))
            {
               throw new ArgumentException("Element not recognized");
            }

            elements[element] = percent_compo;
            TotalPercent = TotalPercent + percent_compo;


        }

        public async Task<string?> CalculateEMF(double? totalGrams)
        {
            if ((elements.Count == 0) || (totalGrams==0 || totalGrams==null))
            {
                return null;
            }

            if (TotalPercent != 100)
            {
                throw new Exception("Total percent composition greater than or lesser than 100.");
            }

            List<double?> MolesOfEachElement = new List<double?>();

            foreach (var percentCompo in elements) {
                double? molarMass = await _context.GetMassBySymbol(percentCompo.Key);

                double? Goe = (totalGrams * percentCompo.Value)/100, mol=Goe/molarMass;
                MolesOfEachElement.Add(mol);

            
            }

            int index = 0;
            double? min = MolesOfEachElement.Min();
            while(index < MolesOfEachElement.Count)
            {
                MolesOfEachElement[index] /= min;
                index=index + 1;
            }

            index = 0;
            string cnct = "";

            foreach(var element in elements)
            {
                cnct += element.Key + ":" + Convert.ToString(MolesOfEachElement[index])+" ";
            }

            return cnct.Trim();



        }


        }
    }

