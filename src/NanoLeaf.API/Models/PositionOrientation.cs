namespace NanoLeaf.API.Models
{
    public class PositionOrientation
    {
        public PositionOrientation(int x, int y, int orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public int X { get; }
        public int Y { get; }
        public int Orientation { get; }
    }
}