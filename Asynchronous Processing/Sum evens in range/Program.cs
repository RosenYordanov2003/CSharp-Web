using System;
using System.Threading.Tasks;

namespace Sum_evens_in_range
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string cmd = Console.ReadLine();
            while (true)
            {
                if (cmd == "show")
                {
                    int sum = await SumEvenSumAsync(1, int.MaxValue);
                    Console.WriteLine(sum);
                    
                }
                cmd = Console.ReadLine();
            }
        }

        private static async Task<int> SumEvenSumAsync(int start, int end)
        {
            return await Task.Run(() =>
            {
                int sum = 0;
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
                return sum;
            });
        }
    }
}
