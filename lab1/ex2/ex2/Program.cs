using System;

namespace lab1
{
    class Program
    {

        public static double ArithmeticMeanPar(Queue<int> numbers)
        {
            double sum = 0;
            int count = 0;
            bool isEvenPosition = false;

            foreach (int number in numbers)
            {
                if (isEvenPosition)
                {
                    sum += number;
                    count++;
                }
                isEvenPosition = !isEvenPosition;
            }

            return sum / count;
        }
        public static double ArithmeticMeanNePar(Queue<int> numbers)
        {
            double sum = 0;
            int count = 0;
            bool isOddPosition = true;

            foreach (int number in numbers)
            {
                if (isOddPosition)
                {
                    sum += number;
                    count++;
                }
                isOddPosition = !isOddPosition;
            }

            return sum / count;
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