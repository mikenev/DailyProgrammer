using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _214e
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new List<int>();
            Console.ReadLine().Split(' ').ToList().ForEach(item => items.Add(int.Parse(item)));
            int sum = items.Sum();
            double median = items.Average();
            List<double> stdevs = new List<double>();
            items.ForEach(item => stdevs.Add(Math.Pow(item - median, 2)));
            double stdev = Math.Sqrt(stdevs.Sum() / items.Count());

            Console.WriteLine("Stdev: " + stdev);
            Console.ReadLine();
        }
    }
}
