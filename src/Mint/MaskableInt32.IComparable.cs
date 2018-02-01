using System;

namespace Mint
{
    public partial struct MaskableInt32 : IComparable, IComparable<int>, IComparable<MaskableInt32>
    {
        public int CompareTo(object obj)
        {
            if (!(obj is MaskableInt32) && !(obj is Int32))
            {
                throw new ArgumentException("Invalid value provided.", nameof(obj));
            }

            return CompareTo((int)obj);
        }

        public int CompareTo(int other)
        {
            // Need to use compare because subtraction will wrap
            // to positive for very large neg numbers, etc.
            if (Val < other)
            {
                return -1;
            }

            if (Val > other)
            {
                return 1;
            }

            return 0;
        }

        public int CompareTo(MaskableInt32 other)
        {
            return Val.CompareTo(other.Val);
        }
    }
}