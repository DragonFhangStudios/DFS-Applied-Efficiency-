using AstroScrap.Core;

namespace AstroScrap.Salvage
{
    /// <summary>Host-side entry point. Later: server validates; clients only propose intents.</summary>
    public interface ISalvageCommandSink
    {
        SalvageCommandResult TryApply(in SalvageIntent intent);
    }
}
