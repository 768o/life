using System;

namespace Floyd
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] G = new double[,] {
                { 0, 5, 12, Floyd.INFINITE },
                { 10, 0, 5, Floyd.INFINITE },
                { Floyd.INFINITE, Floyd.INFINITE, 0, 3 },
                { Floyd.INFINITE, 5, 12, 0 }
            };
            var D = Floyd.GetFloyd(G);
            var count = 0;
            foreach (var item in D)
            {
                Console.Write(item.length);
                Console.Write(" ");
                count++;
                if (count % D.GetLength(1) == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("V3到V2最短距离:" + D[3, 2].length);

            Console.WriteLine();
            int start = 3, end = 2;
            Console.WriteLine("V3到V2最短距离的路径:");
            Console.Write(start);
            while (D[start, end].pre != start) {
                Console.Write("->" + D[start, end].pre);
                start = D[start, end].pre;
            }
            Console.Write("->" + end);
        }
    }
}
