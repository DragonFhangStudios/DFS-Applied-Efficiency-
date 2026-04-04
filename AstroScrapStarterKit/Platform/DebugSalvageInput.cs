using AstroScrap.Core;
using UnityEngine;

namespace AstroScrap.Platform
{
    /// <summary>Prototype-only: press a key to fire a Cut intent for a fixed LinkId.</summary>
    public sealed class DebugSalvageInput : MonoBehaviour, IGameInput
    {
        [SerializeField] KeyCode cutKey = KeyCode.Space;
        [SerializeField] LinkId debugTargetLink = new(0);

        public bool PollPrimaryInteract(out LinkId targetLink)
        {
            if (Input.GetKeyDown(cutKey))
            {
                targetLink = debugTargetLink;
                return true;
            }

            targetLink = default;
            return false;
        }
    }
}
