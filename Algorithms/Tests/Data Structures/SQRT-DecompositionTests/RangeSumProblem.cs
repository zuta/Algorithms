using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.SqrtDecomposition.RangeSumProblem;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace SQRT_DecompositionTests
{
    [TestClass]
    public class RangeSumProblem
    {
        private IRangeSumSolver trustSolver;

        [TestInitialize]
        public void Initialize()
        {
            this.trustSolver = new SimpleRangeSumSolver();
        }

        [TestMethod]
        public void SmallRandomTest()
        {
            // arrange
            Random r = new Random();
            int n = 100 + r.Next(100);
            int m = 200 + r.Next(100);

            IRangeSumSolver solver = new SqrtDecompositionRangeSumSolver();
            TestData testData = CreateRandomTest(n, m);
            // act
            List<int> expected = trustSolver.Solve(testData.Array, testData.Requests);
            List<int> actual = solver.Solve(testData.Array, testData.Requests);
            // assert
            Assert.IsTrue(expected.Except(actual).Count() == 0);
            Assert.IsTrue(actual.Except(expected).Count() == 0);
        }

        [TestMethod]
        public void LargeRandomTest()
        {
            IRangeSumSolver solver = new SqrtDecompositionRangeSumSolver();
            TestData testData = CreateRandomTest(100000, 100000);
            // act
            //List<int> expected = trustSolver.Solve(testData.Array, testData.Requests);
            List<int> actual = solver.Solve(testData.Array, testData.Requests);
            // assert
            //Assert.IsTrue(expected.Except(actual).Count() == 0);
            //Assert.IsTrue(actual.Except(expected).Count() == 0);
        }

        private TestData CreateRandomTest(int n, int m)
        {
            Random r = new Random();

            TestData result = new TestData();
            result.Array = Enumerable.Range(0, n).OrderBy(x => r.NextDouble()).ToArray();
            result.Requests = new List<Request>();

            for (int i = 0; i < m; i++)
            {
                int from = r.Next(n - 1) + 1;
                int to = from + r.Next(n - from);

                result.Requests.Add(new Request(from, to));
            }

            return result;
        }

        private class TestData
        {
            public int[] Array { get; set; }

            public List<Request> Requests { get; set; }
        }
    }
}
