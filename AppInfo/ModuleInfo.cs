using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppInfo
{
    public class ModuleInfo: IComparable<ModuleInfo>
    {
        // Реализуем тут интерфейсы перечислителя и сравнения
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string Description { get; set; }
        public int MemorySize { get; set; }        

        public ModuleInfo() { }

        public ModuleInfo (string name, string fullPath, string desc, int size)
        {
            Name = name;
            FullPath = fullPath;
            Description = desc;
            MemorySize = size;
        }
        
        // Реализация IComparable<>
        public int CompareTo(ModuleInfo other)
        {
            if (this.MemorySize > other.MemorySize)
                return 1;
            if (this.MemorySize < other.MemorySize)
                return -1;
            else
                return 0;
        }
        // Перегрузка операций сравнения
        public static bool operator <(ModuleInfo m1, ModuleInfo m2) => m1.CompareTo(m2) < 0;
        public static bool operator >(ModuleInfo m1, ModuleInfo m2) => m1.CompareTo(m2) > 0;
        public static bool operator <=(ModuleInfo m1, ModuleInfo m2) => m1.CompareTo(m2) <= 0;
        public static bool operator >=(ModuleInfo m1, ModuleInfo m2) => m1.CompareTo(m2) >= 0;
    }
}
