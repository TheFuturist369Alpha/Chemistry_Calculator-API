using ChemLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repo;

namespace ChemLib.Services
{
    public class Molecular_Service : IMolecular
    {
        private readonly IUnitOfWork _context;

        public Molecular_Service(IUnitOfWork context)
        {
            _context = context;

        }
        public async Task<double?> MolecularMass(string molecularFormula)
        {
            double? mass=null;
            string molecule_number = "";
            string numat = "";
            double? sum = 0;
            bool firstCount = true;
            bool secondcount = false;
            string concatSymbol = "";

                if (molecularFormula == null)
                {
                    throw new ArgumentNullException();
                }
                //looping through each character in the "molecularformula" string
                foreach (char i in molecularFormula)
                {
                     //if first character is a digit
                    if (char.IsDigit(i) && firstCount==true)
                {
                    //append digit to "molecule_number"
                    molecule_number += i;
                    continue;
                    
                    
                }
                    //if first character is a letter
                else if(char.IsLetter(i) && firstCount == true) 
                {
                    //if "molecule_number" is empty
                    if (string.IsNullOrEmpty(molecule_number))
                        //assign 1
                    molecule_number = "1";

                    firstCount = false;
                    
                    
                }
                    //if letter is or is not the first character
                if (char.IsLetter(i))
                {
                    //if there is intermediate number between two elements
                    if (!string.IsNullOrEmpty(numat))
                    {
                        mass = await _context.GetMassBySymbol(concatSymbol);
                        mass*=int.Parse(numat);
                        numat = "";

                    }
                    //if letter is uppercase
                    if (char.IsUpper(i))
                    {
                        if (secondcount == true && !string.IsNullOrEmpty(concatSymbol))
                        {
                            mass = await _context.GetMassBySymbol(concatSymbol);
                            sum += mass;
                        }

                        concatSymbol = i.ToString();
                        secondcount = true;
                        continue;
                    }
                    else if(char.IsLower(i))
                    {
                        concatSymbol += i.ToString();
                        secondcount = false;
                        continue;
                    }
                    
                    
                    

                }

                else if (char.IsDigit(i))
                {
                    numat += i.ToString();
                    continue;

                }
                sum += mass;

                

                
               
                
            }
            return sum;
            }
        }
    }

