using AstroScrap.Core;
using AstroScrap.Platform;
using UnityEngine;

namespace AstroScrap.Gameplay
{
    /// <summary>Wires IGameInput → SalvageSessionController (swap implementation later).</summary>
    public sealed class SalvageInputDriver : MonoBehaviour
    {
        [SerializeField] SalvageSessionController session;
        [SerializeField] MonoBehaviour inputBehaviour;

        IGameInput _input;

        void Awake()
        {
            _input = inputBehaviour as IGameInput;
        }

        void Update()
        {
            if (_input == null || session == null)
                return;

            if (_input.PollPrimaryInteract(out var link))
            {
                session.Request(SalvageIntent.Cut(link));
            }
        }
    }
}
