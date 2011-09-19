using System;
using System.Diagnostics;

namespace GameGraphics.Core
{
    public class ProcessCpuUsage
    {
        private bool _initialized;
        private double _initialProcessorTime;
        private readonly Process _process;
        private readonly int _processorCount;
        private Stopwatch _stopwatch;

        public ProcessCpuUsage(Process process)
        {
            _process = process;
            _processorCount = Environment.ProcessorCount;
        }

        public double Cpu
        {
            get
            {
                if (!_initialized)
                    return 0;
                return (CurrentProcessorTime - _initialProcessorTime) / _stopwatch.Elapsed.TotalSeconds * 100;
            }
        }
        private double CurrentProcessorTime
        {
            get
            {
                if (_process == null)
                    return 0;
                return _process.TotalProcessorTime.TotalSeconds / _processorCount;
            }
        }

        public void Initialize()
        {
            if (_initialized)
                return;
            _initialProcessorTime = CurrentProcessorTime;
            _stopwatch = Stopwatch.StartNew();
            _initialized = true;
        }
        public override string ToString()
        {
            return string.Format("{0:n1}%", Cpu);
        }
    }
}