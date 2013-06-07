using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc.Median_Of_Two_Sorted_Arrays
{
    public class BruteForceMedianSeeker : IMedianSeeker
    {
        public int FindMedian(int[] a, int[] b)
        {
            int[] merged = Merge(a, b);

            return merged[merged.Length >> 1];
        }

        private int[] Merge(int[] a, int[] b)
        {
            int n = a.Length;
            int m = b.Length;

            int[] result = new int[n + m];

            for (int p = 0, i = 0, j = 0; i < n || j < m; p++)
            {
                if (i == n)
                {
                    Array.Copy(b, j, result, p, m - j);
                    break;
                }

                if (j == m)
                {
                    Array.Copy(a, i, result, p, n - i);
                    break;
                }

                if (a[i] < b[j])
                {
                    result[p] = a[i++];
                }
                else
                {
                    result[p] = b[j++];
                }
            }

            return result;
        }
    }
}
