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
        public Process Proc { get; set; }
        public string ProcName { get; set; }
        public DateTime StartTime { get; set; }
        public ModuleInfo[] Modules { get; set; }       
        
        private int mCount;
        private ProcessModuleCollection tempArr;

        public ProcStat() { }
        public ProcStat(int pid)
        {
            Proc = Process.GetProcessById(pid);
            ProcName = Proc.ProcessName;
            StartTime = Proc.StartTime;
            tempArr = Proc.Modules;
            mCount = tempArr.Count;

            Modules = new ModuleInfo[mCount];

            // Заполним массив объектов ModuleInfo
            for (int i = 0; i <= mCount; i++)
            {
                if (string.Equals(tempArr[i].FileVersionInfo.FileDescription, "win32 Emulation on NT64",
                            StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n********************************************************************************************************************");
                    Console.WriteLine($"Процесс {ProcName} является 32-ух разрядным," +
                        $" пожалуйста используйете 32-ух разрядную версию приложения AppInfo");
                    Console.WriteLine("********************************************************************************************************************");
                    break;
                }                
                    Modules[i] = new ModuleInfo(tempArr[i].ModuleName, tempArr[i].FileName,
                             tempArr[i].FileVersionInfo.FileDescription, tempArr[i].ModuleMemorySize / 1024);                    
            }   
        } 
        
        // Отсортируем массив по убыванию
        public ModuleInfo[] SortByMemory(ModuleInfo[] modules)
        {
            ModuleInfo[] sortedArr = new ModuleInfo[modules.Length];
            int maxvalue = modules[0].MemorySize;
            for (int i = 0; i < sortedArr.Length; i++)
            {
                for (int j = 0; j < modules.Length; j++)
                {
                    if (modules[j+1].MemorySize > maxvalue)
                        maxvalue = modules[j=1].MemorySize;
                }
                //sortedArr[i] =  до лучших времен
                               
            }
            return sortedArr;
        }
    }
}
