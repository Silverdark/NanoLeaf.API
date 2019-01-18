using NanoLeaf.API.Models;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafRhythm
    {
        bool IsConnected();
        bool IsActive();
        int GetId();
        string GetHardwareVersion();
        string GetFirmwareVersion();
        PositionOrientation GetPosition();

        bool UsesMicrophone();
        void SetUseMicrophone();

        bool IsAuxCableAvailable();
        bool UsesAuxCable();
        void SetUseAuxCable();
    }
}