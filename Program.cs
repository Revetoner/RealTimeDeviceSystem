using System;
using System.Collections.Generic;

namespace RealTimeDeviceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vision> fdList = new List<Vision>();
            for (int i=0; i<10; i++)
            {
                Random random = new Random();
                Vision fd = new Vision();
                fd.FillRobot($"Датчик#{i}", "", "КЗ1", i, random.Next(0, 100));
                fdList.Add(fd);
            }

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(2);

            var timer = new System.Threading.Timer((e) =>
            {
                foreach(var fd in fdList)
                {
                    fd.ChangeRobotState();
                    Console.WriteLine($"Состояние датчика {fd.Name} - Статус: {fd.Status}, Кол-во Объектов - {fd.ObjectQuantity}");
                }
            }, null, startTimeSpan, periodTimeSpan);

            Console.ReadKey();
        }
    }
}
