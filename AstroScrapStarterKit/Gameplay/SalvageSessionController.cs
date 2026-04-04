using AstroScrap.Core;
using AstroScrap.Salvage;
using UnityEngine;

namespace AstroScrap.Gameplay
{
    /// <summary>Thin façade: input/UI call here instead of poking physics directly.</summary>
    public sealed class SalvageSessionController : MonoBehaviour
    {
        [SerializeField] SalvageWorldRouter world;

        void Reset()
        {
            world = GetComponent<SalvageWorldRouter>();
            if (world == null)
                world = FindFirstObjectByType<SalvageWorldRouter>();
        }

        public SalvageCommandResult Request(in SalvageIntent intent)
        {
            if (world == null)
                return SalvageCommandResult.Reject(SalvageRejectReason.NotAuthorized);

            return world.TryApply(intent);
        }
    }
}
