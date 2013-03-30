using System;

namespace DataStructures.SqrtDecomposition.RangeSumProblem
{
    public struct Request
    {
        private int from;
        public int From
        {
            get
            {
                return this.from;
            }
        }

        private int to;
        public int To
        {
            get
            {
                return this.to;
            }
        }

        public Request(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
