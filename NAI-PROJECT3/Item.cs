using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAI_PROJECT3
{
   public class Item
    {
        public double Value { get; set; }
        public double Weigth { get; set; }
        public double Density { get; set; }
        public override string ToString()
        {
            return $"Value = {Value}, Weigth = {Weigth} ";
        }
    }

}
