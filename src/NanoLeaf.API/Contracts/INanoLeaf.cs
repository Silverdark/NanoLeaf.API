using NanoLeaf.API.Models;
using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeaf
    {
        /// <summary>
        /// Gets the authorization token which is used to authenticate with the NanoLeaf controller.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        string AuthorizationToken { get; }

        /// <summary>
        /// Gets an instance for NanoLeaf state values.
        /// </summary>
        /// <value>
        /// The state of the NanoLeaf.
        /// </value>
        INanoLeafState State { get; }

        /// <summary>
        /// Gets an instance for NanoLeaf effect values.
        /// </summary>
        /// <value>
        /// The effects of the NanoLeaf.
        /// </value>
        INanoLeafEffects Effects { get; }

        /// <summary>
        /// Gets an instance for NanoLeaf panel layout values.
        /// </summary>
        /// <value>
        /// The panel layout of the NanoLeaf.
        /// </value>
        INanoLeafPanelLayout PanelLayout { get; }

        /// <summary>
        /// Gets an instance for NanoLeaf rhythm values.
        /// </summary>
        /// <value>
        /// The rhythm of the NanoLeaf.
        /// </value>
        INanoLeafRhythm Rhythm { get; }

        /// <summary>
        /// Gets the device information asynchronous.
        /// </summary>
        /// <returns>The device information of the NanoLeaf controller.</returns>
        Task<ControllerInfo> GetDeviceInformationAsync();

        /// <summary>
        /// Revokes the authorization token asynchronous.
        /// </summary>
        /// <returns>Asynchronous operation.</returns>
        Task RevokeAuthorizationTokenAsync();

        /// <summary>
        /// Identifies the panel by flashing lights asynchronous.
        /// </summary>
        /// <returns>Asynchronous operation.</returns>
        Task IdentifyPanelAsync();
    }
}