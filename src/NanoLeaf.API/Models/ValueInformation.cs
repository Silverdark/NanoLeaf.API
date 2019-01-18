namespace NanoLeaf.API.Models
{
    public class ValueInformation
    {
        public ValueInformation(int currentValue, int maxValue, int minValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public int CurrentValue { get; }
        public int MaxValue { get; }
        public int MinValue { get; }
    }
}