using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterLib
{
    public class Sorter
    {
        public static int[] SortOnUp(int[] mas)
        {
            int timeVal;        
            for (int j = 0; j < mas.Length - 1; j++)
            {
                for (int i = j; i < mas.Length; i++)
                {
                    if (mas[j] > mas[i])
                    {
                        timeVal = mas[j];
                        mas[j] = mas[i];
                        mas[i] = timeVal;
                    }
                }
            }
            return mas;
        }
    }
}
