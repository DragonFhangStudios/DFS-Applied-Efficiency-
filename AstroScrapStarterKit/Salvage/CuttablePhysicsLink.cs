using AstroScrap.Core;
using UnityEngine;

namespace AstroScrap.Salvage
{
    /// <summary>Phase-1 primitive: one joint/link that can be destroyed on Cut.</summary>
    [DisallowMultipleComponent]
    public sealed class CuttablePhysicsLink : MonoBehaviour
    {
        [SerializeField] LinkId linkId;
        [SerializeField] Joint joint;
        [SerializeField] bool cutDestroysGameObject = true;

        public LinkId LinkId => linkId;
        public bool IsCut { get; private set; }

        public void AssignId(LinkId id) => linkId = id;

        void Reset()
        {
            joint = GetComponent<Joint>();
        }

        public SalvageCommandResult TryCut()
        {
            if (IsCut)
                return SalvageCommandResult.Reject(SalvageRejectReason.AlreadyCut);

            IsCut = true;

            if (joint != null)
            {
                Destroy(joint);
            }

            if (cutDestroysGameObject)
            {
                Destroy(gameObject);
            }

            return SalvageCommandResult.Ok();
        }
    }
}
