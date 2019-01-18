using NanoLeaf.API.Models;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafPanelLayout
    {
        ValueInformation GetGlobalPanelOrientation();
        void SetGlobalPanelOrientation();

        PanelLayout GetPanelLayout();
    }
}