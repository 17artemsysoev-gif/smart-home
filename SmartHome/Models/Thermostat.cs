using System;

namespace SmartHome.Models
{
    public class Thermostat : SmartDevice
    {
        public double TargetTemperature { get; private set; }

        public Thermostat(string name, double temperature, double powerWatts = 1500) : base(name, powerWatts)
        {
            TargetTemperature = temperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Целевая температура: {TargetTemperature}°C");
        }

        public override string GetStatus() => $"{Name} — {(IsOn ? "вкл" : "выкл")}, цель {TargetTemperature}°C";
    }
}
