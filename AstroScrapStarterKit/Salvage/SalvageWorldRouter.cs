using System.Collections.Generic;
using AstroScrap.Core;
using UnityEngine;

namespace AstroScrap.Salvage
{
    /// <summary>Maps LinkId -> link behaviour. Register links at runtime or via editor wiring.</summary>
    public sealed class SalvageWorldRouter : MonoBehaviour, ISalvageCommandSink
    {
        [SerializeField] List<CuttablePhysicsLink> links = new();

        readonly Dictionary<LinkId, CuttablePhysicsLink> _map = new();

        void Awake()
        {
            RebuildMap();
        }

        public void Register(CuttablePhysicsLink link)
        {
            if (link == null) return;
            _map[link.LinkId] = link;
        }

        public void Unregister(CuttablePhysicsLink link)
        {
            if (link == null) return;
            _map.Remove(link.LinkId);
        }

        public void RebuildMap()
        {
            _map.Clear();
            foreach (var link in links)
            {
                if (link != null)
                    _map[link.LinkId] = link;
            }
        }

        public SalvageCommandResult TryApply(in SalvageIntent intent)
        {
            switch (intent.Kind)
            {
                case SalvageIntentKind.None:
                    return SalvageCommandResult.Reject(SalvageRejectReason.InvalidIntent);

                case SalvageIntentKind.CutLink:
                    if (!_map.TryGetValue(intent.TargetLink, out var cuttable))
                        return SalvageCommandResult.Reject(SalvageRejectReason.UnknownLink);
                    return cuttable.TryCut();

                default:
                    return SalvageCommandResult.Reject(SalvageRejectReason.InvalidIntent);
            }
        }
    }
}
