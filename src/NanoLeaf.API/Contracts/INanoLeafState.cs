using System.Threading.Tasks;
using NanoLeaf.API.Models;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafState
    {
        Task<bool> GetPowerStateAsync();
        Task SetPowerStateAsync(bool state);

        Task<ValueInformation> GetBrightnessAsync();
        Task SetBrightnessAsync(int brightness, int duration = -1);

        Task<ValueInformation> GetHueAsync();
        Task SetHueAsync(int hue);

        Task<ValueInformation> GetSaturationAsync();
        Task SetSaturationAsync(int saturation);

        Task<ValueInformation> GetColorTemperatureAsync();
        Task SetColorTemperatureAsync(int colorTemperature);

        Task<string> GetColorModeAsync();
    }
}