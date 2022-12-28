using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicious_Scraper
{
    internal class DataPoint : IComparable
    {
        internal decimal val;
        internal decimal x;
        internal decimal y;

        public DataPoint(decimal val, decimal x, decimal y)
        {
            this.val = val;
            this.x = x;
            this.y = y;
        }

        public int CompareTo(object obj)
        {
            DataPoint dp = (DataPoint)obj;

            if (this.y > dp.y)
                return 1;
            else if (this.y < dp.y)
                return -1;
            else
                return 0;
        }
    }
}
