using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _395_e
{
    class Program
    {
        static void Main(string[] args)
        {
            nonogramrow(new int[] {}); // => []
            nonogramrow(new int[] {0,0,0,0,0}); //  => []
            nonogramrow(new int[] {1,1,1,1,1}); // => [5]
            nonogramrow(new int[] {0,1,1,1,1,1,0,1,1,1,1}); // => [5,4]
            nonogramrow(new int[] {1,1,0,1,0,0,1,1,1,0,0}); // => [2,1,3]
            nonogramrow(new int[] {0,0,0,0,1,1,0,0,1,0,1,1,1}); // => [2,1,3]
            nonogramrow(new int[] {1,0,1,0,1,0,1,0,1,0,1,0,1,0,1}); // => [1,1,1,1,1,1,1,1]
        }

        private static void nonogramrow(int[] input)
        {
            var result = new List<int>();
            var count = 0;

            foreach (var i in input)
            {
                if (i == 0)
                {
                    if (count > 0)
                    {
                        result.Add(count);
                        count = 0;
                    }
                }
                else
                    count += 1;
            }

            if (count > 0)
                result.Add(count);

            var toPrint = string.Join(",", result.Select(i => i.ToString()).ToArray());
            Console.WriteLine($"[{toPrint}]");
        }
    }
}
