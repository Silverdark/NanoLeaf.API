using NanoLeaf.API.Models;
using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafPanelLayout
    {
        /// <summary>
        /// Gets the global panel orientation asynchronous.
        /// </summary>
        /// <returns>The global orientation.</returns>
        Task<ValueInformation> GetGlobalPanelOrientationAsync();

        /// <summary>
        /// Sets the global panel orientation asynchronous.
        /// </summary>
        /// <param name="globalOrientation">The global orientation.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetGlobalPanelOrientationAsync(int globalOrientation);

        /// <summary>
        /// Gets the panel layout asynchronous.
        /// </summary>
        /// <returns>The panel layout.</returns>
        Task<PanelLayout> GetPanelLayoutAsync();
    }
}