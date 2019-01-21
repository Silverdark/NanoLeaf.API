using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafEffects
    {
        /// <summary>
        /// Gets the current effect asynchronous.
        /// </summary>
        /// <returns>Current effect</returns>
        Task<string> GetCurrentEffectAsync();

        /// <summary>
        /// Sets the effect asynchronous.
        /// </summary>
        /// <param name="effectName">Name of the effect.</param>
        /// <returns>Asynchronous operation.</returns>
        Task SetEffectAsync(string effectName);

        /// <summary>
        /// Gets the effect list from the NanoLeaf controller asynchronous.
        /// </summary>
        /// <returns>List of all effects on the NanoLeaf controller.</returns>
        Task<string[]> GetEffectListAsync();

        // TODO: Write command has many different calls. See 3.3 Effect commands of the API documentation
    }
}