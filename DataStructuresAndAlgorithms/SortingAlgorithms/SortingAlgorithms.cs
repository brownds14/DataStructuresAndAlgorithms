using System;

namespace DataStructuresAndAlgorithms.SortingAlgorithms
{
    public static class Sorting
    {
        private static Random rnd = new Random();

        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        #region Methods to create lists
        public static int[] CreateRandomList(UInt32 size, int min, int max)
        {
            int[] ret = new int[size];

            for (int i = 0; i < size; ++i)
            {
                ret[i] = rnd.Next(min, max);
            }

            return ret;
        }

        public static int[] CreateSortedList(UInt32 size, int min, int max)
        {
            int[] ret = CreateRandomList(size, min, max);
            Array.Sort(ret);
            return ret;
        }
        #endregion

        #region Sorting Algorithms
        public static void SelectionSort(int[] arr)
        {
            int min;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                Swap(ref arr[i], ref arr[min]);
            }
        }

        public static void BubbleSort(int[] arr)
        {
            Boolean swapped;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                swapped = false;
                for (int j = 0; j < arr.Length - 1; ++j)
                {
                    if (arr[j] > arr[j+1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int tmp;
            for (int i = 1; i < arr.Length; ++i)
            {
                tmp = arr[i];
                int j = i;
                while (j > 0 && arr[j - 1] > tmp)
                {
                    arr[j] = arr[j - 1];
                    --j;
                }
                arr[j] = tmp;
            }
        }

        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return;

            //Split list into two parts and recurse
            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];
            Array.Copy(arr, 0, left, 0, middle);
            Array.Copy(arr, middle, right, 0, arr.Length - middle);
            MergeSort(left);
            MergeSort(right);

            //Merge the two lists
            int leftIndex = 0;
            int rightIndex = 0;
            int index = 0;
            
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                    arr[index++] = left[leftIndex++];
                else
                    arr[index++] = right[rightIndex++];
            }

            while (leftIndex < left.Length)
                arr[index++] = left[leftIndex++];

            while (rightIndex < right.Length)
                arr[index++] = right[rightIndex++];
        }

        public static void HeapSort(int[] arr)
        {
            for (int i = arr.Length / 2; i >= 0; --i)
                Heapify(arr, i, arr.Length);
            
            for (int i = arr.Length - 1; i > 0; --i)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, 0, i);
            }
        }

        private static void Heapify(int[] arr, int index, int heapSize)
        {
            int maxNode = index;
            int leftNode = 2 * maxNode;
            int rightNode = 2 * maxNode + 1;

            if (leftNode < heapSize && arr[maxNode] < arr[leftNode])
                maxNode = leftNode;

            if (rightNode < heapSize && arr[maxNode] < arr[rightNode])
                maxNode = rightNode;

            if (maxNode != index)
            {
                Swap(ref arr[index], ref arr[maxNode]);
                Heapify(arr, maxNode, heapSize);
            }
        }
        #endregion
    }
}
