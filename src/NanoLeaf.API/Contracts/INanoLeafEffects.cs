namespace NanoLeaf.API.Contracts
{
    public interface INanoLeafEffects
    {
        string GetCurrentEffect();
        void SetEffect(string effectName);

        string[] GetEffectList();

        // TODO: Write command has many different calls. See 3.3 Effect commands of the API documentation
    }
}