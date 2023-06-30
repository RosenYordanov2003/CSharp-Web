namespace Chronometer.Contracts
{
    using System.Collections.Generic;
    public interface IChronometer
    {
        public string GetTime { get; }
        public IReadOnlyCollection<string> Laps { get; }
        void Start();
        void Stop();
        string Lap();
        void Reset();
    }
}
