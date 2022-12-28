using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicious_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            VS_Scaper scraper = new VS_Scaper();
            scraper.Scrape();
        }
    }
}
