using System;

namespace Mint
{
    public partial struct MaskableInt32 : IEquatable<int>, IEquatable<MaskableInt32>
    {
        public bool Equals(int other)
        {
            return Val == other;
        }

        public bool Equals(MaskableInt32 other)
        {
            return Val == other.Val;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MaskableInt32 && Equals((MaskableInt32) obj);
        }

        public override int GetHashCode()
        {
            return this.Val;
        }
    }
}