using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructures.SqrtDecomposition.RangeSumProblem
{
    public class SqrtDecompositionRangeSumSolver : IRangeSumSolver
    {
        public List<int> Solve(int[] array, List<Request> requests)
        {
            List<int> results = new List<int>();

            int numbersInOneDecomposedPosition;
            int[] decomposedArray = DecomposeArray(array, out numbersInOneDecomposedPosition);

            int n = array.Length;
            int k = decomposedArray.Length;

            foreach (Request request in requests)
            {
                results.Add(ComputeSum(array, decomposedArray, request.From - 1, request.To - 1, numbersInOneDecomposedPosition));
            }

            return results;
        }

        private int ComputeSum(int[] array, int[] decomposedArray, int l, int r, int numbersInOneDecomposedPosition)
        {
            int sum = 0;

            int lDPosition = l / numbersInOneDecomposedPosition;
            int rDPosition = r / numbersInOneDecomposedPosition;

            if (lDPosition == rDPosition)
            {
                sum = array.Skip(l).Take(r - l + 1).Sum();
            }
            else
            {
                for (int i = l ; i < (lDPosition + 1) * numbersInOneDecomposedPosition; i++)
                {
                    sum += array[i];
                }

                for (int i = lDPosition + 1; i < rDPosition; i++)
                {
                    sum += decomposedArray[i];
                }

                for (int i = rDPosition * numbersInOneDecomposedPosition; i <= r; i++)
                {
                    sum += array[i];
                }
            }

            return sum;
        }

        private int[] DecomposeArray(int[] array, out int numbersInOneDecomposedPosition)
        {
            int n = array.Length;

            numbersInOneDecomposedPosition = (int)Math.Sqrt(n) + 1;

            int k = n / numbersInOneDecomposedPosition;
            if (n % numbersInOneDecomposedPosition != 0)
                k++;

            int[] result = new int[k];

            for (int i = 0, j = -1; i < n; i++)
            {
                if (i % numbersInOneDecomposedPosition == 0)
                    j++;

                result[j] += array[i];
            }

            return result;
        }
    }
}
