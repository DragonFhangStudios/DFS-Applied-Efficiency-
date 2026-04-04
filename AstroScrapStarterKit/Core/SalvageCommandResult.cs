namespace AstroScrap.Core
{
    public enum SalvageRejectReason
    {
        None = 0,
        InvalidIntent = 1,
        UnknownLink = 2,
        AlreadyCut = 3,
        NotAuthorized,
    }

    public readonly struct SalvageCommandResult
    {
        public readonly bool Accepted;
        public readonly SalvageRejectReason Reason;

        SalvageCommandResult(bool accepted, SalvageRejectReason reason)
        {
            Accepted = accepted;
            Reason = reason;
        }

        public static SalvageCommandResult Ok() => new(true, SalvageRejectReason.None);

        public static SalvageCommandResult Reject(SalvageRejectReason reason) =>
            new(false, reason);
    }
}
