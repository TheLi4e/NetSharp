using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSharp
{
    internal class Lesson2
    {
        public static int _sum1 = 0;
        public static int _sum2 = 0;

        public static int[] _arr1 = { 1, 5, 8, 8, 7, 1, 7, 6, 4 };
        public static int[] _arr2 = { 1, 9, 2, 3, 1, 4, 6, 4, 4 };

        public static void Task1(object? arr)
        {
            _sum1 = _arr1.Sum();
        }
        public static void Task2(object? arr)
        {
            _sum2 = _arr2.Sum();
        }
    }





}
