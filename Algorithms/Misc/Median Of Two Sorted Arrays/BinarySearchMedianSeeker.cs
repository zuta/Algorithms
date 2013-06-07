using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc.Median_Of_Two_Sorted_Arrays
{
    public class BinarySearchMedianSeeker : IMedianSeeker
    {
        public int FindMedian(int[] a, int[] b)
        {
            int n = a.Length;
            int m = b.Length;

            int underMedian = (n + m) >> 1;

            int median = 0;

            int m1 = FindMedianViaBinarySearch(a, b, n, m, underMedian);

            if (m1 >= 0) return median = a[m1];
            else
            {
                int m2 = FindMedianViaBinarySearch(b, a, m, n, underMedian);
                median = b[m2];
            }

            return median;
        }

        private int FindMedianViaBinarySearch(int[] a, int[] b, int n, int m, int underMendian)
        {
            int l = 0;
            int r = n - 1;
            int j;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                
                j = Math.Max(0, underMendian - mid);

                if (j == 0)
                {
                    if (a[mid] <= b[j]) return mid;

                    r = mid;
                }
                else if (j == m)
                {
                    if (b[j - 1] <= a[mid]) return mid;

                    l = mid + 1;
                }
                else
                {
                    if (b[j - 1] <= a[mid] && a[mid] <= b[j]) return mid;

                    if (a[mid] > b[j])
                        r = mid;
                    else
                        l = mid + 1;
                }
            }

            j = Math.Max(0, underMendian - l);

            if ((j == 0 && a[l] <= b[j]) ||
                (j == m && b[j - 1] <= a[l]) ||
                (j > 0 && b[j - 1] <= a[l] && a[l] <= b[j])) return l;

            return -1;
        }
    }
}
