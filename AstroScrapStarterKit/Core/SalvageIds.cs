using System;

namespace AstroScrap.Core
{
    /// <summary>Stable id for gameplay graph nodes (supports future save/net sync).</summary>
    public readonly struct NodeId : IEquatable<NodeId>
    {
        public readonly int Value;

        public NodeId(int value) => Value = value;

        public bool Equals(NodeId other) => Value == other.Value;
        public override bool Equals(object obj) => obj is NodeId other && Equals(other);
        public override int GetHashCode() => Value;
        public static bool operator ==(NodeId a, NodeId b) => a.Equals(b);
        public static bool operator !=(NodeId a, NodeId b) => !a.Equals(b);
    }

    /// <summary>Identifies a cuttable connection between physics bodies.</summary>
    public readonly struct LinkId : IEquatable<LinkId>
    {
        public readonly int Value;

        public LinkId(int value) => Value = value;

        public bool Equals(LinkId other) => Value == other.Value;
        public override bool Equals(object obj) => obj is LinkId other && Equals(other);
        public override int GetHashCode() => Value;
        public static bool operator ==(LinkId a, LinkId b) => a.Equals(b);
        public static bool operator !=(LinkId a, LinkId b) => !a.Equals(b);
    }
}
