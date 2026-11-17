namespace SmartHome.Models
{
    public class SmartSpeaker : SmartDevice
    {
        public int Volume { get; private set; }

        public SmartSpeaker(string name, int volume, double powerWatts = 25) : base(name, powerWatts)
        {
            Volume = volume;
        }

        public override string GetStatus() => $"{Name} — {(IsOn ? "вкл" : "выкл")}, громкость {Volume}%";
    }
}
