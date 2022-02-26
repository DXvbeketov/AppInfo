using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppInfo
{
    // Класс представляет статистические данные об определенном процессе
    class ProcStat
    {
        Process proc { get; set; }
        string procName { get; set; }
        DateTime startTime { get; set; }

        public ProcStat() { }
        public ProcStat(int pid)
        {
            proc = Process.GetProcessById(pid);
            procName = proc.ProcessName;
            startTime = proc.StartTime;
        }
        
    }
}
