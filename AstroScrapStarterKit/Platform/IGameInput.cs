using AstroScrap.Core;

namespace AstroScrap.Platform
{
    /// <summary>Abstract input for KB/M, gamepad, touch. Implement with Input System when ready.</summary>
    public interface IGameInput
    {
        bool PollPrimaryInteract(out LinkId targetLink);
    }
}
