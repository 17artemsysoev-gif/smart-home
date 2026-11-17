using System;

namespace SmartHome.Models
{
    public sealed class SmartKettle : SmartDevice
    {
        public int WaterTemperature { get; private set; }

        public SmartKettle(string name, int waterTemperature, double powerWatts = 2000) : base(name, powerWatts)
        {
            WaterTemperature = waterTemperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Нагрев воды до {WaterTemperature}°C");
        }

        public override string GetStatus() => $"{Name} — {(IsOn ? "вкл" : "выкл")}, нагрев до {WaterTemperature}°C";
    }
}
