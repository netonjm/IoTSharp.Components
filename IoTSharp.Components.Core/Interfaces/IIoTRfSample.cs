namespace IoTSharp.Components
{
    public interface IIoTRfSample
    {
        int Length { get; }
        double Duration { get; }
        double GetData (int index);
        void Save (string file);
        void Read (string file);
    }
}
