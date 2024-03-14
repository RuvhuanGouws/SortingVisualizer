using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.SortingAlgorithms
{
    internal class QuickSort : ISortingAlgorithm
    {
        public int[] ArrayToSort { get; set; } = [];

        public event EventHandler OnChange;

        public void Sort(int[] array)
        {
            ArrayToSort = array;
            QuickSortArray(ArrayToSort, 0, ArrayToSort.Length - 1);            
        }

        private async void QuickSortArray(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = await Partition(array, left, right);

                if (pivot > 0)
                {
                    QuickSortArray(array, left, pivot - 1);
                }
                if (pivot +1 < right)
                {
                    QuickSortArray(array, pivot + 1, right);
                }
            }
        }
        
        private async Task<int> Partition(int[] array, int left, int right)
        {
            int pivot = array[left];

            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (array[left] == array[right]) 
                        return right;

                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    OnChange?.Invoke(this, new EventArgs());
                    await Task.Delay(25);
                }
                else
                {
                    return right;
                }
            }
            
        }
    }
}
