using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.SqrtDecomposition.RangeSumProblem
{
    public interface IRangeSumSolver
    {
        List<int> Solve(int[] array, List<Request> requests);
    }
}
