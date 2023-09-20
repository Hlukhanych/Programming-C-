using System;

namespace lab1
{
    class Program
    {

        public static double ArithmeticMeanPar(Queue<int> queue)
        {
            double a = 0;
            int count = 0;
            int[] arr = new int[queue.Count];
            queue.CopyTo(arr, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    a += arr[i];
                    count++;
                }
            }
            return a / count;
        }

        public static double ArithmeticMeanNePar(Queue<int> queue)
        {
            double a = 0;
            int count = 0;
            int[] arr = new int[queue.Count];
            queue.CopyTo(arr, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 != 0)
                {
                    a += arr[i];
                    count++;
                }
            }
            return a / count;
        }
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            Console.Write("count: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write("elem: ");
                queue.Enqueue(Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine(ArithmeticMeanPar(queue));
            Console.WriteLine(ArithmeticMeanNePar(queue));
        }
    }
}