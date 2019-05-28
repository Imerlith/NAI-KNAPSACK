using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAI_PROJECT3
{
    class Knapsack
    {
        public Item[] Items { get; set; }
        public int Capacity { get; set; }
      
        public double Timer;

        public ICollection<Item> FindWithBruteForce()
        {
            var result = new List<Item>();
            var bestValue = 0d;
            var bestPosition = 0;
            var size = Items.Length;
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var numberOfSets = (long)Math.Pow(2, size);
            for (int i = 0; i < numberOfSets; i++)
            {
                var value = 0d;
                var weight = 0d;
                for (int j = 0; j < size; j++)
                {
                    if (((i >> j) & 1) != 1) continue;

                    value += Items[j].Value;
                    weight += Items[j].Weigth;

                }

                if(weight <= Capacity && value > bestValue)
                {
                    bestPosition = i;
                    bestValue = value;
                }

            }
            for (int i = 0; i < size; i++)
            {
                if (((bestPosition >> i) & 1) == 1)
                {
                    result.Add(Items[i]);
                }
            }

            stopWatch.Stop();
            Timer = stopWatch.Elapsed.TotalSeconds;
            return result;
        }

        public ICollection<Item> FindWithGreedy()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = new List<Item>();
            var temp = new List<Item>();
            foreach(var item in Items)
            {
                item.Density = item.Value / item.Weigth;
                temp.Add(item);
            }
            temp.OrderByDescending(item => item.Density);

            var currentWeigth = 0d;
            foreach(var item in temp)
            {
                if(currentWeigth + item.Weigth <= Capacity)
                {
                    result.Add(item);
                    currentWeigth += item.Weigth;
                }
            }
            stopWatch.Stop();
            Timer = stopWatch.Elapsed.TotalSeconds;
            return result;
        }
       
    }
}
