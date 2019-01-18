using System;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeaf : IDisposable
    {
        bool IsConnected { get; }
        INanoLeafState State { get; }
        INanoLeafEffects Effects { get; }
        INanoLeafPanelLayout PanelLayout { get; }
        INanoLeafRhythm Rhythm { get; }

        string GetDeviceInformation();
        void RevokeAuthorizationToken();

        void IdentityPanel();
    }
}