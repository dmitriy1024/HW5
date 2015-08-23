using System;

namespace HW5.Delegates.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Func<int>[], double> func =
                delegate (Func<int>[] arr)
                {
                    double average = 0;
                    foreach (var item in arr)
                        average += item();

                    return average / arr.Length;
                };

            Func<int>[] delArray = new Func<int>[5];
            for (int i = 0; i < delArray.Length; i++)
            {
                delArray[i] = GetRandomNum;
            }

            Console.WriteLine("Average of ramdom numbers = {0}", func(delArray));

            Console.ReadKey();
        }

        static int GetRandomNum()
        {
            Random rnd = new Random();
            return rnd.Next(100);
        }

    }
}
