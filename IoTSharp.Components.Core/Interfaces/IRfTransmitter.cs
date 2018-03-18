namespace IoTSharp.Components
{
    public interface IRfTransmitter : IIoTComponent
    {
        IRfSample Sample { get; }
        void Load (string file);
        void Transmit (IRfSample sample);
        void Transmit ();
    }
}
