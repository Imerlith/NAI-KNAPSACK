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
        public List<Item> Items { get; set; }
        public int Capacity { get; set; }
      
        public double Timer;

        public List<Item> FindWithBruteForce()
        {

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var bestSubset = new List<Item>();
            var bestValue = 0d;
            foreach (var subset in Subsets(Items))
            {
                double weight = GetWeigth(subset);
                if (weight <= Capacity)
                {
                    double value = GetValue(subset);
                    if (value > bestValue)
                    {
                        bestValue = value;
                        bestSubset = subset;
                    }
                }
            }
            
            stopWatch.Stop();
            Timer = stopWatch.Elapsed.TotalSeconds;
            return bestSubset;
        }

        private double GetValue(List<Item> subset)
        {
            double value = 0;
            foreach (Item item in subset)
            {
                value += item.Value;
            }
            return value;
        }

        private double GetWeigth(List<Item> subset)
        {
            double weight = 0;
            foreach(Item item in subset)
            {
                weight += item.Weigth;
            }
            return weight;
        }

        private List<List<Item>> Subsets(List<Item> items)
        {
            var subsets = new List<List<Item>>();
            if (!items.Any())
            {
                subsets.Add(new List<Item>());
                return subsets;
            }
            var first = items.First();
            var sub = items.GetRange(1, items.Count-1);
            var subsubsets = Subsets(sub);
            foreach(var subset in subsubsets)
            {
                subsets.Add(subset);
                var augmentd = new List<Item>();
                augmentd.AddRange(subset);
                augmentd.Insert(0, first);
                subsets.Add(augmentd);
            }
            return subsets;
           
            
        }

        public List<Item> FindWithGreedy()
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
                if (currentWeigth == Capacity)
                {
                    break;
                }
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
