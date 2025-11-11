using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Algo;

public static class InsertionSort
{
    public static int[] InsertionSortAsc(this int[] arr)
    {

        for(int i = 0;i<arr.Length;i++)
        {
            int key = arr[i];
            int j = i - 1;

            //if unsorted 
            while (j >= 0 && arr[j]> key)
            {
                arr[j+1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
              
        return arr;
    }

    public static int[] InsertionSortDesc(this int[] arr)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            int key = arr[i];

            int j = i - 1;

            //if unsorted 
            while (j >= 0 && arr[j] < key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }

        return arr;
    }
}


    
