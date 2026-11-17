using System;

namespace SmartHome.Models
{
    public abstract class SmartDevice : IEnergyConsumer
    {
        public string Name { get; private set; }
        public bool IsOn { get; protected set; }
        public double BasePowerWatts { get; private set; }

        protected SmartDevice(string name, double basePowerWatts)
        {
            Name = name;
            BasePowerWatts = basePowerWatts;
        }

        public virtual void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name}: включён");
        }

        public virtual void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name}: выключен");
        }

        public virtual double GetPowerConsumption() => IsOn ? BasePowerWatts : 0;

        public abstract string GetStatus();
    }
}
