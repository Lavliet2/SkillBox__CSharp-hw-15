using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Homework_15
{
    class Program
    {

        private static void ThreadMethod(Thread[] threads)
        {
            Random rnd = new Random();

            for (int i = 0; i < threads.Length; i++)
            {
                int threadIndex = i;

                threads[i] = new Thread(() =>
                {
                    int delay = rnd.Next(1, 6);
                    Thread.Sleep(delay * 1000);
                    Thread.CurrentThread.Name = threadIndex.ToString();
                    Console.WriteLine($"Поток: {Thread.CurrentThread.Name} - {Thread.CurrentThread.GetHashCode} c задержкой: {delay} секунды");
                });
                threads[i].Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Начало...MainThread");
            int count = 5;
            Thread[] threads = new Thread[count];
            ThreadMethod(threads);
            Console.WriteLine("\nОкончание...MainThread");
        }
    }
}
