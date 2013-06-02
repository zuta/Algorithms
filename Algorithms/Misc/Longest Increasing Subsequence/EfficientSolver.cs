using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Longest_Increasing_Subsequence
{
    /// <summary>
    /// Complexity : O(N * log N)
    /// Aux. Memory : O(N)
    /// 
    /// Aux.arrays :
    /// M[j] — stores the position k of the smallest value X[k] such that there is an increasing subsequence of length j ending at X[k]
    /// P[k] — stores the position of the predecessor of X[k] in the longest increasing subsequence ending at X[k].
    /// </summary>
    class EfficientSolver : ISolver
    {
        public int GetLengthOfLongestIncreasingSubSequence(int[] array)
        {
            int n = array.Length;

            int[] M = new int[n + 1];
            int[] P = new int[n];

            int max = 0;

            M[0] = -1;

            for (int i = 0; i < n; i++)
            {
                int j = FindTheBest(array, M, max, i);
                P[i] = M[j];

                if (max == j || array[i] < array[M[j + 1]])
                {
                    M[j + 1] = i;

                    if (j + 1 > max) max = j + 1;
                }
            }

            return max;
        }

        private int FindTheBest(int[] array, int[] M, int max, int i)
        {
            int l = 1;
            int r = max;

            while (l < r)
            {
                int mid = l + (r - l + 1) / 2;

                if (array[i] <= array[M[mid]])
                    r = mid - 1;
                else
                    l = mid;
            }

            if (array[i] > array[M[l]]) return l;

            return 0;
        }
    }
}
