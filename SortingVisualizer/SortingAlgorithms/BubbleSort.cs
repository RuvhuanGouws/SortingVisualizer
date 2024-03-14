using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.SortingAlgorithms
{
    internal class BubbleSort : ISortingAlgorithm
    {
        public int[] ArrayToSort { get; set; } = [];

        public event EventHandler OnChange;

        public async void Sort(int[] array)
        {
            ArrayToSort = array;
            int n = ArrayToSort.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ArrayToSort[j] > ArrayToSort[j + 1])
                    {
                        int temp = ArrayToSort[j];
                        ArrayToSort[j] = ArrayToSort[j + 1];
                        ArrayToSort[j + 1] = temp;
                        OnChange?.Invoke(this, new EventArgs());
                        await Task.Delay(10);
                    }
                }
            }
        }
    }
}
