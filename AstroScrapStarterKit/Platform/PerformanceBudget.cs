using UnityEngine;

namespace AstroScrap.Platform
{
    [CreateAssetMenu(fileName = "PerformanceBudget", menuName = "Astro-Scrap/Performance Budget")]
    public sealed class PerformanceBudget : ScriptableObject
    {
        [Header("Tuning (apply from bootstrap or settings UI)")]
        public int maxActiveRigidbodies = 96;
        public int maxDebrisPieces = 64;
        public float debrisLifetimeSeconds = 12f;

        [Header("URP / quality hooks (wire to your pipeline asset swaps)")]
        public int shadowDistance = 40;
        public int msaaSampleCount = 2;
    }
}
