using System;

namespace GameGraphics
{
    public class RunResults
    {
        public RunResults(string description, TimeSpan time, double framesPerSecond, double cpuSelf, double cpuDwm)
        {
            Description = description;
            Time = string.Format("{0:n1} s", time.TotalSeconds);
            FramesPerSecond = framesPerSecond.ToString("n1");
            CpuSelf = string.Format("{0:n1}%", cpuSelf);
            CpuDwm = string.Format("{0:n1}%", cpuDwm);
            CpuTotal = string.Format("{0:n1}%", cpuSelf + cpuDwm);
        }

        public string CpuDwm { get; private set; }
        public string CpuSelf { get; private set; }
        public string CpuTotal { get; private set; }
        public string Description { get; private set; }
        public string FramesPerSecond { get; private set; }
        public string Time { get; private set; }
    }
}