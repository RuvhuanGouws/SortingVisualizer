using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.SortingAlgorithms
{
    internal interface ISortingAlgorithm
    {
        event EventHandler OnChange;
        void Sort(int[] array);
        int[] ArrayToSort { get; set; }
    }
}
