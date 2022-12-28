using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicious_Scraper
{
    internal class DataPointDictionary : SortedDictionary<decimal, List<DataPoint>>
    {
        public void Add(decimal key, DataPoint value)
        {
            if (this.ContainsKey(key))
            {
                List<DataPoint> list = this[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<DataPoint> list = new List<DataPoint>();
                list.Add(value);
                this.Add(key, list);
            }
        }

        public void Sort(decimal key)
        {
            this[key].Sort();
        }

        public void SortAll()
        {
            foreach (decimal key in this.Keys)
            {
                this.Sort(key);
            }
        }

        public decimal this[int index1, int index2]
        {
            get
            {
                List<decimal> keys = this.Keys.ToList();
                return this[keys[index1]][index2].val;
            }
        }
    }
}
