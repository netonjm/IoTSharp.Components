namespace IoTSharp.Components
{
    public interface IIoTRfTransmitter : IIoTComponent
    {
        IIoTRfSample Sample { get; }
        void Load (string file);
        void Transmit (IIoTRfSample sample);
        void Transmit ();
    }
}
