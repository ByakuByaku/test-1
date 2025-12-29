using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    internal interface IsortStrategy
    {
        void Sort(List<int> list);
    }

    public class quickSort : IsortStrategy
    {
        public void Sort(List<int> list)
        {
            list.Sort();
            Console.WriteLine("QuickSorted list");
        }
    }

    public class bubbleSort : IsortStrategy
    {
        public void Sort(List<int> list)
        {
            
            var n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                // Внутренний цикл - сравнение соседних элементов
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Если текущий элемент больше следующего, меняем их местами
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("BubbleSorted list");
        }
    }

}
