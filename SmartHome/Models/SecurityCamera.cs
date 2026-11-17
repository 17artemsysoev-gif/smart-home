using System;

namespace SmartHome.Models
{
    public class SecurityCamera : SmartDevice, IRecordable
    {
        public bool IsRecording { get; private set; }

        public SecurityCamera(string name, double powerWatts = 10) : base(name, powerWatts) { }

        public override void TurnOn()
        {
            base.TurnOn();
            StartRecording();
        }

        public override void TurnOff()
        {
            StopRecording();
            base.TurnOff();
        }

        public void StartRecording()
        {
            IsRecording = true;
            Console.WriteLine($"  {Name}: видеозапись начата");
        }

        public void StopRecording()
        {
            IsRecording = false;
            Console.WriteLine($"  {Name}: видеозапись остановлена");
        }

        public override string GetStatus() => $"{Name} — {(IsOn ? "вкл" : "выкл")}, запись: {(IsRecording ? "идёт" : "нет")}";
    }
}
