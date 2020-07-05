using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class FundelsGame
    {
        private static List<int> taliaGracz = new List<int>();
        private static List<int> taliaSi = new List<int>();

        static public void InicjowanieTalli()
        {
            
        }

        static public void Tasowanie()
        { 
        }

        static bool Result(int liczbaPocztkowa, int liczbaZKarty, int test)
        {

            if(liczbaPocztkowa < test)
            {
                return true;
            }

            return false;
        }
    }
}
