using NanoLeaf.API.Models;
using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafPanelLayout
    {
        Task<ValueInformation> GetGlobalPanelOrientationAsync();
        Task SetGlobalPanelOrientationAsync(int globalOrientation);

        Task<PanelLayout> GetPanelLayoutAsync();
    }
}