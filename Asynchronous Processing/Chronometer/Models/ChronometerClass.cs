using Chronometer.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chronometer.Models
{
    public class ChronometerClass : IChronometer
    {
        private readonly Stopwatch stopwatch;
        private readonly List<string> laps;
        public ChronometerClass()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }
        public string GetTime => $"time \r\n{stopwatch.Elapsed}";

        public IReadOnlyCollection<string> Laps => laps;

        public string Lap()
        {
            TimeSpan lap = stopwatch.Elapsed;
            this.laps.Add(lap.ToString());
            return lap.ToString();
        }

        public void Reset()
        {
            this.laps.Clear();
            this.stopwatch.Reset();
        }

        public void Start()
        {
          this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
