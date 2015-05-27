using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _214i
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> dimensions = ReadIntLine();
            List<List<int>> papers = new List<List<int>>();

            List<int> paper = ReadIntLine();
            while (paper.Count() != 0)
            {
                papers.Add(paper);
                paper = ReadIntLine();
            }

            int[,] board = new int[dimensions[0], dimensions[1]];

            foreach (var item in papers)
            {
                PlacePaper(board, item);
            }

            SortedDictionary<int, int> counts = CountPaperAreas(board);

            foreach (var items in counts)
            {
                Console.WriteLine(items.Key + ": " + items.Value);
            }

            Console.ReadLine();
        }

        static List<int> ReadIntLine()
        {
            List<int> items = new List<int>();
            string line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                line.Split(' ').ToList().ForEach(item => items.Add(int.Parse(item)));
            }

            return items;
        }

        static void PlacePaper(int[,] board, List<int> inputs)
        {
            int paperNumber = inputs[0];
            int x = inputs[1];
            int y = inputs[2];
            int xMax = x + inputs[3];
            int yMax = y + inputs[4];

            for (int i = x; i < xMax; i++)
            {
                for (int j = y; j < yMax; j++)
                {
                    board[i, j] = paperNumber;
                }
            }
        }

        public static SortedDictionary<int, int> CountPaperAreas(int[,] board)
        {
            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    int paper = board[i, j];

                    if (counts.ContainsKey(paper))
                    {
                        counts[paper]++;
                    }
                    else
                    {
                        counts.Add(paper, 1);
                    }
                }
            }

            return counts;
        }
    }
}
