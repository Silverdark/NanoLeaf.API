using NanoLeaf.API.Models;
using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafRhythm
    {
        Task<bool> IsConnectedAsync();
        Task<bool> IsActiveAsync();
        Task<int> GetIdAsync();
        Task<string> GetHardwareVersionAsync();
        Task<string> GetFirmwareVersionAsync();
        Task<PositionOrientation> GetPositionAsync();

        Task<bool> UsesMicrophoneAsync();
        Task SetUseMicrophoneAsync();

        Task<bool> IsAuxCableAvailableAsync();
        Task<bool> UsesAuxCableAsync();
        Task SetUseAuxCableAsync();
    }
}