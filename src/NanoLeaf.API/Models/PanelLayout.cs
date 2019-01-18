namespace NanoLeaf.API.Models
{
    public class PanelLayout
    {
        public PanelLayout(int numberOfPanels, int sideLength, PanelPosition[] panelPositions)
        {
            NumberOfPanels = numberOfPanels;
            SideLength = sideLength;
            PanelPositions = panelPositions;
        }

        public int NumberOfPanels { get; }
        public int SideLength { get; }
        public PanelPosition[] PanelPositions { get; }
    }
}