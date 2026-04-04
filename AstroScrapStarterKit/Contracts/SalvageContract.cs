using UnityEngine;

namespace AstroScrap.Contracts
{
    [CreateAssetMenu(fileName = "SalvageContract", menuName = "Astro-Scrap/Salvage Contract")]
    public sealed class SalvageContract : ScriptableObject
    {
        [TextArea(2, 6)] public string briefing;
        public string internalName;

        /// <summary>Scene to load for this contract (addressables later if you want).</summary>
        public string sceneName;

        /// <summary>One-line mechanical clause for Phase-1+ (e.g. black box zone).</summary>
        [TextArea(1, 3)] public string mechanicalClause;
    }
}
