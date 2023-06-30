using Chronometer.Models;
using System;
using System.Threading.Tasks;

namespace ChronometerTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChronometerClass chronometer = new ChronometerClass();
            string line = Console.ReadLine();
            while (line != "exit")
            {
                if(line == "start")
                {
                    Task.Run(() => chronometer.Start());
                }
                else if(line == "stop")
                {
                    chronometer.Stop();
                }
                else if(line == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if(line == "laps")
                {
                    if(chronometer.Laps.Count > 0)
                    {
                        Console.WriteLine("Laps:");
                        int counter = 0;
                        foreach (string lap in chronometer.Laps)
                        {
                            Console.WriteLine($"{counter++} {lap}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                }
                else
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                line = Console.ReadLine();
            }
            chronometer.Stop();
        }
    }
}
