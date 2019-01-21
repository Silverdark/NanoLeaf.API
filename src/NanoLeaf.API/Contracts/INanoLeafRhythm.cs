using NanoLeaf.API.Models;
using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafRhythm
    {
        /// <summary>
        /// Determines whether the rhythm is connected asynchronous.
        /// </summary>
        /// <returns>True, if the rhythm is connected, otherwise false.</returns>
        Task<bool> IsConnectedAsync();

        /// <summary>
        /// Determines whether the rhythm is active asynchronous.
        /// </summary>
        /// <returns>True, if the rhythm is active, otherwise false.</returns>
        Task<bool> IsActiveAsync();

        /// <summary>
        /// Gets the id of the rhythm asynchronous.
        /// </summary>
        /// <returns>The id of the rhythm.</returns>
        Task<int> GetIdAsync();

        /// <summary>
        /// Gets the hardware version of the rhythm asynchronous.
        /// </summary>
        /// <returns>The hardware version of the rhythm.</returns>
        Task<string> GetHardwareVersionAsync();

        /// <summary>
        /// Gets the firmware version of the rhythm asynchronous.
        /// </summary>
        /// <returns>The firmware version of the rhythm.</returns>
        Task<string> GetFirmwareVersionAsync();

        /// <summary>
        /// Gets the position and orientation of the rhythm asynchronous.
        /// </summary>
        /// <returns>Position and orientation of the rhythm.</returns>
        Task<PositionOrientation> GetPositionAsync();

        /// <summary>
        /// Determines whether the rhythm uses the microphone asynchronous.
        /// </summary>
        /// <returns>True, if the rhythm uses the microphone, otherwise false.</returns>
        Task<bool> UsesMicrophoneAsync();

        /// <summary>
        /// Sets the use of the microphone asynchronous.
        /// </summary>
        /// <returns>Asynchronous operation.</returns>
        Task SetUseMicrophoneAsync();

        /// <summary>
        /// Determines whether the AUX cable is available asynchronous.
        /// </summary>
        /// <returns>True, if the AUX cable is available, otherwise false.</returns>
        Task<bool> IsAuxCableAvailableAsync();

        /// <summary>
        /// Determines whether the rhythm uses the AUX cable asynchronous.
        /// </summary>
        /// <returns>True, if the rhythm uses the AUX cable, otherwise false.</returns>
        Task<bool> UsesAuxCableAsync();

        /// <summary>
        /// Sets the use of the AUX cable asynchronous.
        /// </summary>
        /// <returns>Asynchronous operation.</returns>
        Task SetUseAuxCableAsync();
    }
}