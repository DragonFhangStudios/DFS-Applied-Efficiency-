namespace AstroScrap.Core
{
    /// <summary>Player-issued commands. Keep payloads small for future multiplayer replication.</summary>
    public enum SalvageIntentKind
    {
        None = 0,
        CutLink = 1,
    }

    public readonly struct SalvageIntent
    {
        public readonly SalvageIntentKind Kind;
        public readonly LinkId TargetLink;

        public static SalvageIntent Cut(LinkId link) => new(SalvageIntentKind.CutLink, link);

        SalvageIntent(SalvageIntentKind kind, LinkId targetLink)
        {
            Kind = kind;
            TargetLink = targetLink;
        }
    }
}
