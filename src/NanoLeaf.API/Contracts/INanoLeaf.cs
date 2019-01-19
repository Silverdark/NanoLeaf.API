using NanoLeaf.API.Models;
using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeaf
    {
        string AuthorizationToken { get; }

        INanoLeafState State { get; }
        INanoLeafEffects Effects { get; }
        INanoLeafPanelLayout PanelLayout { get; }
        INanoLeafRhythm Rhythm { get; }

        Task<ControllerInfo> GetDeviceInformationAsync();
        Task RevokeAuthorizationTokenAsync();

        Task IdentifyPanelAsync();
    }
}