using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _215e
{
    class Program
    {
        // See http://www.reddit.com/r/dailyprogrammer/comments/36cyxf/20150518_challenge_215_easy_sad_cycles/

        static void Main(string[] args)
        {
            int b = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> sad = new Dictionary<string, int>();

            int sum = n;

            while (true)
            {
                sum = SumPoweredDigits(b, sum);
                string s = sum.ToString();

                if (sad.ContainsKey(s))
                {
                    if (sad[s] >= 1)
                    {
                        break;
                    }
                    else
                    {
                        sad[s]++;
                    }
                }
                else
                {
                    sad.Add(s, 0);
                }
            }

            var cycle = from c in sad
                        where c.Value > 0
                        select c.Key;

            Console.WriteLine(string.Join(", ", cycle));
            Console.ReadLine();

        }

        static int SumPoweredDigits(int power, int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int temp = number % 10;
                sum += (int) Math.Pow(temp, power);
                number /= 10;
            }

            return sum;
        }
    }
}
