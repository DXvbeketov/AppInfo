using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

// Приложение AppInfo_х32 получает PID процесса и выводит информацию о процессе разрядности х32

namespace AppInfo_x32
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.WriteLine("\t****** Добро пожаловать в приложение AppInfo_х32! ******\n");
            Console.WriteLine("Приложение AppInfo отображает различные данные о интересующем x32 процессе");
            do
            {
                Console.WriteLine("\nХотите ли Вы получить данные о процессе? [да / нет]");
                string answear = Console.ReadLine();
                if (string.Equals(answear, "нет", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Cпасибо за использование данной программы!");
                    break;
                }
                if (!answear.Equals("нет", StringComparison.OrdinalIgnoreCase)
                    && !answear.Equals("да", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Введены некорректные данные, пожалуйста повторите ввод");
                    continue;
                }
                bool isCorrect = false;
                do
                {
                    Console.Write("Введите идентификатор(PID) процесса: ");
                    try
                    {
                        int PID = Convert.ToInt32(Console.ReadLine());
                        GetProccessInfo(PID);
                        isCorrect = true;
                    } 
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные, пожалуйста повторите ввод");
                    }
                } while (isCorrect == false);
            } while (true);
        }
        static void GetProccessInfo(int pid)
        {
            try
            {
                Process proc = Process.GetProcessById(pid);
                // bool is64Bit = false;
                Console.WriteLine($"\nПроцесс {proc.ProcessName} стартовал {proc.StartTime}");
                Console.WriteLine($"Максимальный объем потребляемой памяти в момент времени: " +
                                  $"{proc.PeakWorkingSet / 1_000_000} Мбайт");                                

                ProcessModuleCollection modules = proc.Modules;
                Console.WriteLine("Использует следующие ресурсы(модули):\n");
                Console.WriteLine("№  Модуль " + "Путь".PadLeft(30));
                int count = 0;
                foreach (ProcessModule pm in modules)
                {
                    count++;
                    Console.WriteLine($"{count} {pm.ModuleName}".PadRight(27) + $"{pm.FileName}".PadRight(45) +
                                $"{pm.FileVersionInfo.FileDescription}");
                }                
                Console.WriteLine();
            } 
            catch (Exception ex)
            {                
                Console.WriteLine("\n**************** АХТУНГ! ЕРРОРР!!!!11 *******************");
                Console.WriteLine("Описание ошибки: {0}", ex.Message);
                if (ex.Message.Contains("32") || ex.Message.Contains("64"))
                {
                    Console.WriteLine("Пожалуйста используйете 64-ех разрядную версию приложения AppInfo");
                    Console.WriteLine("***********************************************************");
                    return;
                }
                Console.WriteLine("Стек вызовов: {0}", ex.StackTrace);
                Console.WriteLine("Метод вызвавший исключение: {0}", ex.TargetSite);
                Console.WriteLine("Источник исключения: {0}", ex.GetBaseException().GetType().Name);
                Console.WriteLine("***********************************************************");
            }
        }
    }
}
