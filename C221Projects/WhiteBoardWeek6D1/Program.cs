using System;

namespace WhiteBoardWeek6D1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 1, 0, 3, 12};
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {

                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    if (arr[j] == 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    
                }

            }

            foreach (var number in arr)
            {
                Console.WriteLine(number.ToString());
            }
            Console.ReadLine();
        }
    }
}
