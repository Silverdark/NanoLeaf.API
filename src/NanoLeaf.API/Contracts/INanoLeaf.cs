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

        // TODO: More complex structure
        Task<string> GetDeviceInformationAsync();
        Task RevokeAuthorizationTokenAsync();

        Task IdentifyPanelAsync();
    }
}