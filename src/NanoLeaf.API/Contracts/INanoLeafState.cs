using NanoLeaf.API.Models;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafState
    {
        bool GetPowerState();
        void SetPowerState(bool state);

        ValueInformation GetBrightness();
        void SetBrightness(int brightness, int duration = -1);

        ValueInformation GetHue();
        void SetHue(int hue);

        ValueInformation GetSaturation();
        void SetSaturation(int saturation);

        ValueInformation GetColorTemperature();
        void SetColorTemperature(int colorTemperature);

        string GetColorMode();
    }
}