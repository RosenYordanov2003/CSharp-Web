using System;
using System.Threading.Tasks;

namespace Sum_Evens_in_Background
{
    public class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            Task task = Task.Run(() =>
            {
                for (int i = 1; i <= int.MaxValue; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
            });
            while (true)
            {
                string cmd = Console.ReadLine();
                if(cmd == "exit")
                {
                    return;
                }
                else if(cmd == "show")
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
