using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExternalSorting
{
    public class StreamPointer : IDisposable
    {
        private StreamReader streamReader;
        private int value;

        public StreamPointer(string file)
        {
            streamReader = File.OpenText(file);
        }

        public bool Finished
        {
            get;
            private set;
        }

        public bool Next()
        {
            if (!streamReader.EndOfStream)
                this.value = int.Parse(streamReader.ReadLine());
            else
                Finished = true;

            return !streamReader.EndOfStream;
        }

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public void Dispose()
        {
            if (streamReader != null)
            {
                streamReader.Close(); // and dispose
            }
        }
    }
}
