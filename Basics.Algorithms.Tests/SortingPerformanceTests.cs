using System;
using System.Diagnostics;
using System.Linq;
using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class SortingPerformanceTests
    {
        private const int size = 1000000;

        private class SortInfo
        {
            public string Name { get; set; }
            public Action<int[]> Act { get; set; }
            public bool Enabled { get; set; }
        }

        [TestMethod]
        public void SortingPerformanceTest()
        {
            var stopwatch = new Stopwatch();
            var sortedArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                sortedArray[i] = i;
            }
            var sorts = new SortInfo[]
            {
                new SortInfo { Name = "Selection Sort", Act = array => Selection.Sort(array), Enabled = false },
                new SortInfo { Name = "Insertion Sort", Act = array => Insertion.Sort(array), Enabled = false },
                new SortInfo { Name = "Shell Sort", Act = array => Shell.Sort(array), Enabled = false },
                new SortInfo { Name = "Mergesort", Act = array => Merge.Sort(array), Enabled = true },
                new SortInfo { Name = "Quicksort", Act = array => Quick.Sort(array), Enabled = true }
            };

            foreach (var sort in sorts.Where(s => s.Enabled))
            {
                sortedArray.Shuffle();
                stopwatch.Restart();
                sort.Act(sortedArray);
                stopwatch.Stop();
                Console.WriteLine("{0}:\t{1}", sort.Name, stopwatch.ElapsedTicks);
            }
        }
    }
}
