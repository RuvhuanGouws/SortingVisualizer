using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.SortingAlgorithms
{
    internal class SelectionSort : ISortingAlgorithm
    {
        public int[] ArrayToSort { get; set; } = [];

        public event EventHandler OnChange;

        public async void Sort(int[] array)
        {
            ArrayToSort = array;
            for (int i = 0; i < ArrayToSort.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (ArrayToSort[j - 1] > ArrayToSort[j])
                    {
                        int temp = ArrayToSort[j - 1];
                        ArrayToSort[j - 1] = ArrayToSort[j];
                        ArrayToSort[j] = temp;
                        OnChange?.Invoke(this, new EventArgs());
                        await Task.Delay(20);
                    }
                }
            }
        }
    }
}
