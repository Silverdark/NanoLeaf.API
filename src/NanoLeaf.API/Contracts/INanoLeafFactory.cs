using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafFactory
    {
        Task<INanoLeaf> CreateNanoLeafAsync();
        INanoLeaf CreateNanoLeaf(string authorizationToken);
    }
}