using System;

namespace SmartHome.Models
{
    public class RobotVacuum : SmartDevice
    {
        public int BatteryLevel { get; private set; }

        public RobotVacuum(string name, int batteryLevel, double powerWatts = 45) : base(name, powerWatts)
        {
            BatteryLevel = batteryLevel;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Уровень заряда: {BatteryLevel}%");
        }

        public void Clean() => Console.WriteLine($"{Name}: запущена стандартная уборка всей квартиры");
        public void Clean(int rooms) => Console.WriteLine($"{Name}: запущена уборка комнат ({rooms})");

        public override string GetStatus() => $"{Name} — {(IsOn ? "вкл" : "выкл")}, заряд {BatteryLevel}%";
    }
}
