using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace Mint
{
    public partial struct MaskableInt32 : IFormattable
    {
        [Pure]
        public string ToString(string format)
        {
            return Val.ToString(format, NumberFormatInfo.CurrentInfo);
        }

        [Pure]
        public string ToString(IFormatProvider provider)
        {
            return Val.ToString(NumberFormatInfo.GetInstance(provider));
        }

        [Pure]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Val.ToString(format, NumberFormatInfo.GetInstance(formatProvider));
        }
    }
}