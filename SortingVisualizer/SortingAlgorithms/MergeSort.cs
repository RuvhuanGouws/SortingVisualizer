using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.SortingAlgorithms
{
    internal class MergeSort : ISortingAlgorithm
    {
        public int[] ArrayToSort { get; set; } = [];

        public event EventHandler OnChange;

        public void Sort(int[] array)
        {
            ArrayToSort = MergeSortArray(array);
            OnChange?.Invoke(this, new EventArgs());
        }

        private int[] MergeSortArray(int[] array)
        {
            //ArrayToSort = array;
            if (array.Length <= 1)
                return array;

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            OnChange?.Invoke(this, new EventArgs());
            Task.Delay(20);
            left = MergeSortArray(left);
            right = MergeSortArray(right);

            int[] temp = Merge(left, right);

            return temp;
        }

        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] result = new int[leftArray.Length + rightArray.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            int leftLength = leftArray.Length, rightLength = rightArray.Length;

            while (leftIndex < leftLength && rightIndex < rightLength)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                    result[resultIndex++] = leftArray[leftIndex++];
                else
                    result[resultIndex++] = rightArray[rightIndex++];
            }

            while (leftIndex < leftLength)
                result[resultIndex++] = leftArray[leftIndex++];

            while (rightIndex < rightLength)
                result[resultIndex++] = rightArray[rightIndex++];

            return result;
        }
    }
}
