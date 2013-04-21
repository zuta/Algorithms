using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTests
{
    public abstract class BaseQuadraticSortTest : BaseSortTest
    {
        protected override int GetAmountOfNumbersForLargeTest()
        {
            Random r = new Random();

            return (r.Next(250) + 1) * (r.Next(250) + 1);
        }
    }
}
