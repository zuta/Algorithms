using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeSumProblem
{
    public class SimpleRangeSumSolver : IRangeSumSolver
    {
        /// <summary>
        /// Solves a range sum problem.
        /// Complexity of algorithm - O(M*N)
        ///     where   N - the length of array
        ///             M - the number of requests
        /// </summary>
        /// <param name="array">an array of integer numbers</param>
        /// <param name="requests">a list of requests</param>
        /// <returns>a list of responses for each request</returns>
        public List<int> Solve(int[] array, List<Request> requests)
        {
            List<int> results = new List<int>();

            foreach (Request request in requests)
            {
                results.Add(
                    array
                    .Skip(request.From - 1)
                    .Take(request.To - request.From + 1)
                    .Sum());
                // or 
                //int sum = 0;
                //for (int i = request.From - 1; i < request.To; i++)
                //{
                //    sum += array[i];
                //}

                //results.Add(sum);
            }

            return results;
        }
    }
}
