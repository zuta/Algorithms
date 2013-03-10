using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSumProblem
{
    class Program
    {
        private static int[] array;
        private static List<Request> requests;

        private static TextReader GetFileTextReader()
        {
            return File.OpenText(@"../../input.txt");
        }

        private static TextWriter GetFileTextWriter()
        {
            return File.CreateText(@"../../output.txt");
        }

        static void Main(string[] args)
        {
            using (TextReader reader = GetFileTextReader())
            {
                int n = int.Parse(reader.ReadLine());
                array = new int[n];

                string[] line = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(line[i]);
                }

                requests = new List<Request>();

                int m = int.Parse(reader.ReadLine());  // number of requests
                for (int i = 0; i < m; i++)
                {
                    line = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int l = int.Parse(line[0]);
                    int r = int.Parse(line[1]);

                    requests.Add(new Request(l, r));
                }
            }

            IRangeSumSolver solver = new SimpleRangeSumSolver();

            WriteResultsToFile(solver.Solve(array, requests));
        }

        private static void WriteResultsToFile(List<int> results)
        {
            using (TextWriter writer = GetFileTextWriter())
            {
                foreach (int value in results)
                {
                    writer.WriteLine(value);
                }
            }
        }
    }
}
