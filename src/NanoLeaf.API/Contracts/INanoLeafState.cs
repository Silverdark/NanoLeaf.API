using System.Threading.Tasks;
using NanoLeaf.API.Models;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafState
    {
        /// <summary>
        /// Gets the power state asynchronous.
        /// </summary>
        /// <returns>True, if the NanoLeaf is powered on, otherwise false.</returns>
        Task<bool> GetPowerStateAsync();

        /// <summary>
        /// Sets the power state asynchronous.
        /// </summary>
        /// <param name="state">if set to <c>true</c> the NanoLeaf is powered on, otherwise it's powered off.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetPowerStateAsync(bool state);

        /// <summary>
        /// Gets the brightness asynchronous.
        /// </summary>
        /// <returns>The brightness values.</returns>
        Task<ValueInformation> GetBrightnessAsync();

        /// <summary>
        /// Sets the brightness asynchronous.
        /// </summary>
        /// <param name="brightness">The brightness.</param>
        /// <param name="duration">The duration.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetBrightnessAsync(int brightness, int duration = -1);

        /// <summary>
        /// Gets the hue asynchronous.
        /// </summary>
        /// <returns>The hue values.</returns>
        Task<ValueInformation> GetHueAsync();

        /// <summary>
        /// Sets the hue asynchronous.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetHueAsync(int hue);

        /// <summary>
        /// Gets the saturation asynchronous.
        /// </summary>
        /// <returns>The saturation values.</returns>
        Task<ValueInformation> GetSaturationAsync();

        /// <summary>
        /// Sets the saturation asynchronous.
        /// </summary>
        /// <param name="saturation">The saturation.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetSaturationAsync(int saturation);

        /// <summary>
        /// Gets the color temperature asynchronous.
        /// </summary>
        /// <returns>The color temperature values.</returns>
        Task<ValueInformation> GetColorTemperatureAsync();

        /// <summary>
        /// Sets the color temperature asynchronous.
        /// </summary>
        /// <param name="colorTemperature">The color temperature.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetColorTemperatureAsync(int colorTemperature);

        /// <summary>
        /// Gets the color mode asynchronous.
        /// </summary>
        /// <returns>The color mode.</returns>
        Task<string> GetColorModeAsync();
    }
}