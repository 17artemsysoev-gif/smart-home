namespace SmartHome.Models
{
    public interface IEnergyConsumer
    {
        double GetPowerConsumption();
    }

    public interface IRecordable
    {
        void StartRecording();
        void StopRecording();
    }
}
