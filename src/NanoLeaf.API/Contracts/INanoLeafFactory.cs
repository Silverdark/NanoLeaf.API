using System.Threading.Tasks;

namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafFactory
    {
        /// <summary>
        /// Creates an instance for a NanoLeaf asynchronous.
        /// 
        /// With this call, the authorization token will be generated.
        /// The user have to press the "On / Off"-Button for 5-7 seconds until the LED is flashing before executing
        /// this command.
        /// </summary>
        /// <returns>A NanoLeaf instance with a valid authorization token.</returns>
        Task<INanoLeaf> CreateNanoLeafAsync();

        /// <summary>
        /// Creates an instance for a NanoLeaf with a valid authorization token.
        /// </summary>
        /// <param name="authorizationToken">The authorization token.</param>
        /// <returns>A NanoLeaf instance.</returns>
        INanoLeaf CreateNanoLeaf(string authorizationToken);
    }
}