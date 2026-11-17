using System;

namespace SmartHome.Models
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; }

        public SmartLight(string name, int brightness, double powerWatts = 12) : base(name, powerWatts)
        {
            Brightness = brightness;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Яркость: {Brightness}%");
        }

        public void SetBrightness(int level)
        {
            Brightness = Math.Clamp(level, 0, 100);
            Console.WriteLine($"{Name}: установлена яркость {Brightness}%");
        }

        public void SetBrightness(string preset)
        {
            switch (preset.ToLower())
            {
                case "night": Brightness = 15; break;
                case "evening": Brightness = 40; break;
                case "day": Brightness = 100; break;
                default:
                    Console.WriteLine($"{Name}: неизвестный пресет \"{preset}\"");
                    return;
            }
            Console.WriteLine($"{Name}: применён пресет \"{preset}\" ({Brightness}%)");
        }

        public override double GetPowerConsumption() => IsOn ? BasePowerWatts * (Brightness / 100.0) : 0;

        public override string GetStatus() => $"{Name} — {(IsOn ? "вкл" : "выкл")}, яркость {Brightness}%";
    }
}
