using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafEffects
    {
        Task<string> GetCurrentEffectAsync();
        Task SetEffectAsync(string effectName);

        Task<string[]> GetEffectListAsync();

        // TODO: Write command has many different calls. See 3.3 Effect commands of the API documentation
    }
}