using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExternalSorting
{
    class Program
    {
        private const string INPUT_FILE = @"..\..\input.txt";
        private const string OUTPUT_FILE = @"..\..\output.txt";

        private const int CHUNK_COUNT = 500;

        private static int[] array = new int[CHUNK_COUNT];

        private static List<string> tempFiles = new List<string>();
        private static List<StreamPointer> streamPointers = new List<StreamPointer>();

        static void Main(string[] args)
        {
            //WriteRandomNumbersToInputFile();

            ProcessInput();

            CreateStreamPointers();

            Merge();

            Dispose();
        }

        private static void Dispose()
        {
            // dispose stream readers
            foreach (StreamPointer sp in streamPointers)
            {
                sp.Dispose();
            }

            // delete temp files
            foreach (string tempFile in tempFiles)
            {
                File.Delete(tempFile);
            }
        }

        private static void CreateStreamPointers()
        {
            foreach (string tempFile in tempFiles)
            {
                streamPointers.Add(new StreamPointer(tempFile));
            }
        }

        private static void Merge()
        {
            foreach(StreamPointer sp in streamPointers)
            {
                sp.Next();
            }

            int actualSize = 0;

            using (StreamWriter sw = File.CreateText(OUTPUT_FILE))
            {
                bool hasNumbers = true;
                while (hasNumbers)
                {
                    hasNumbers = false;

                    int imin = -1;
                    for (int i = 0; i < streamPointers.Count;i++ )
                    {
                        if (streamPointers[i].Finished) continue;

                        if (imin == -1 || streamPointers[imin].Value > streamPointers[i].Value) imin = i;

                        hasNumbers = true;
                    }

                    if (hasNumbers)
                    {
                        array[actualSize++] = streamPointers[imin].Value;
                        streamPointers[imin].Next();

                        if (actualSize == CHUNK_COUNT)
                        {
                            WriteArrayToFile(array, actualSize, sw);
                            actualSize = 0;
                        }
                    }
                    else
                    {
                        WriteArrayToFile(array, actualSize, sw);
                    }
                }
            }
        }

        private static void ProcessInput()
        {
            using (StreamReader sr = File.OpenText(INPUT_FILE))
            {
                int actualSize = 0;

                while (!sr.EndOfStream)
                {
                    int i = 0;
                    for (; i < CHUNK_COUNT && !sr.EndOfStream; i++)
                    {
                        array[i] = int.Parse(sr.ReadLine());
                    }

                    actualSize = Math.Min(CHUNK_COUNT, i);

                    Sort(array, 0, actualSize - 1);

                    string tmp = string.Format(@"..\..\{0}", Guid.NewGuid());

                    using (StreamWriter sw = File.CreateText(tmp))
                    {
                        WriteArrayToFile(array, actualSize, sw);
                    }

                    tempFiles.Add(tmp);
                }
            }
        }

        private static void WriteArrayToFile(int[] array, int actualSize, StreamWriter sw)
        {
            for (int i = 0; i < actualSize; i++)
            {
                sw.WriteLine(array[i]);
            }
        }

        private static void WriteRandomNumbersToInputFile()
        {
            using (StreamWriter sw = File.CreateText(INPUT_FILE))
            {
                Random r = new Random();
                for (int i = 0; i < 100000; i++)
                {
                    sw.WriteLine(r.Next(int.MaxValue) - r.Next(int.MaxValue));
                    //sw.WriteLine(r.Next(20));
                }
            }
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (right > left)
            {
                int l = left;
                int r = right;
                int m = array[l + (r - l) / 2];

                while (l < r)
                {
                    while (array[l] < m) l++;
                    while (array[r] > m) r--;

                    if (l <= r)
                    {
                        int tmp = array[l];
                        array[l++] = array[r];
                        array[r--] = tmp;
                    }
                }

                Sort(array, left, r);
                Sort(array, l, right);
            }
        }
    }
}
