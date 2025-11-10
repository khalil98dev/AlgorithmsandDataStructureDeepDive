using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algo;

public static class SelectedSort
{
    public static int[] SortDesc(this int[] result)
    {
        //Here => /-\_/-\_/ => 

        int lenght = result.Length;


        for (int i = 0; i < lenght; i++)
        {
            int indexMinValue = i; 

            for (int j =i+1; j < lenght; j++)
            {
                if (result[j] < result[indexMinValue])
                    indexMinValue = j;    
            }

            //swap 
            (result[i], result[indexMinValue]) = (result[indexMinValue], result[i]);


        }


        return result;

    }

    public static int[] SortAsc(this int[] result)
    {
        //Here => /-\_/-\_/ => 

        int lenght = result.Length;


        for (int i = 0; i < lenght; i++)
        {
            int indexMaxValue = i;

            for (int j = i + 1; j < lenght; j++)
            {
                if (result[j] > result[indexMaxValue])
                    indexMaxValue = j;
            }

            //swap 
            (result[i], result[indexMaxValue]) = (result[indexMaxValue], result[i]);


        }


        return result;

    }


    public static void Print(this int[] result)
    {
        for (int i=0;i<result.Length;i++)
        {
            Console.WriteLine($"Element [{i}]: {result[i]}");
        }

    }

}
