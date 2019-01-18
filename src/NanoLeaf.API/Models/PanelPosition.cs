namespace NanoLeaf.API.Models
{
    public class PanelPosition
    {
        public PanelPosition(int panelId, int x, int y, int orientation)
        {
            PanelId = panelId;
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public int PanelId { get; }
        public int X { get; }
        public int Y { get; }
        public int Orientation { get; }
    }
}