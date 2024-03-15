using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RealTimeDeviceSystem
{
    public class Vision
    {
        public static string[] StatusList = { "Работает", "Выключен", "Объект_найден" };
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public Location Location { get; set; }

        public int ObjectQuantity{ get; set; }
        public string Status { get; set; }

        public void FillRobot(string name, string description, string model, int robotNumber, int coord)
        {
            this.Name = name;
            this.Description = description;
            this.Model = model;
            Location loc = new Location();
            loc.FillLocation(robotNumber, coord);
            this.Location = loc;
        }

        public void ChangeRobotState()
        {
            Random random = new Random();
            this.ObjectQuantity = random.Next(0, 11);
            this.Status = StatusList[random.Next(0, 3)];
        }
    }

    public class Location
    {
        public int RobotNumber { get; set; }
        public int Coord { get; set; }
        public int ObjectType { get; set; }

        public void FillLocation(int robotNumber, int coord)
        {
            this.RobotNumber = robotNumber;
            this.Coord = coord;
        }
    }
}
