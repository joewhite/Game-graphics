using System;
using System.Diagnostics;
using System.ComponentModel;

namespace GameGraphics.Core
{
    public class ProcessCpuUsage
    {
        private bool _initialized;
        private double _initialProcessorTime;
        private Process _process;
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
                    return double.NaN;
                try
                {
                    return _process.TotalProcessorTime.TotalSeconds / _processorCount;
                }
                catch (Win32Exception)
                {
                    _process = null;
                    return double.NaN;
                }
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