using Xunit;
using DataStructuresAndAlgorithms.SortingAlgorithms;

namespace DataStructuresAndAlgorithms.Tests
{
    public class SortingTests
    {
        private bool IsSorted(int[] list)
        {
            bool ret = true;

            for(int i = 0; i < list.Length - 1; ++i)
                if (list[i] > list[i + 1])
                {
                    ret = false;
                    break;
                }

            return ret;
        }

        [Fact]
        public void GenerateRandomList()
        {
            bool success = true;
            int min = 0, max = 1000;
            int[] list = Sorting.CreateRandomList(1000, min, max);

            for (int i = 0; i < list.Length; ++i)
                if (list[i] < min || list[i] > max)
                {
                    success = false;
                    break;
                }

            Assert.True(success);
        }

        [Fact]
        public void GenerateSortedList()
        {
            int[] list = Sorting.CreateSortedList(1000, 0, 1000);

            Assert.True(IsSorted(list));
        }

        [Fact]
        public void SelectionSortTest()
        {
            int[] list = Sorting.CreateRandomList(1000, 0, 1000);

            Sorting.SelectionSort(list);

            Assert.True(IsSorted(list));
        }

        [Fact]
        public void BubbleSortTest()
        {
            int[] list = Sorting.CreateRandomList(1000, 0, 1000);

            Sorting.BubbleSort(list);

            Assert.True(IsSorted(list));
        }

        [Fact]
        public void InsertionSortTest()
        {
            int[] list = Sorting.CreateRandomList(1000, 0, 1000);

            Sorting.InsertionSort(list);

            Assert.True(IsSorted(list));
        }

        [Fact]
        public void MergeSortTest()
        {
            int[] list = Sorting.CreateRandomList(1000, 0, 1000);

            Sorting.MergeSort(list);

            Assert.True(IsSorted(list));
        }

        [Fact]
        public void HeapSortTest()
        {
            int[] list = Sorting.CreateRandomList(1000, 0, 1000);

            Sorting.HeapSort(list);

            Assert.True(IsSorted(list));
        }
    }
}
