using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Mint
{
    /// <inheritdoc cref="IComparable"/>
    /// <summary>
    /// Represents a 32-bit signed integer that provides obfuscation capabilities and behaves as a regular Integer (Int32).
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(MaskableInt32TypeConverter))]
    [JsonConverter(typeof(MaskableInt32JsonConverter))]
    public partial struct MaskableInt32
    {
        internal int Val;
        
        public const int MaxValue = 0x7fffffff;
        public const int MinValue = unchecked((int)0x80000000);

        /// <summary>
        /// Gets a masked (obfuscated) representation of the underlying MaskableInt32 value.
        /// The masking process occurs according the default obfuscation settings (salt, alphabet) 
        /// which can be overriden at a global level by calling the methods <see cref="SetObfuscationSalt"/>, <see cref="SetObfuscationAlphabet"/>
        /// </summary>
        /// <returns>Masked value as string</returns>
        [Pure]
        public string GetMaskedValue()
        {
            return IntegerObfuscator.Obfuscate(this.Val);
        }

        /// <summary>
        /// Gets the MaskableInt32 value associated with the provided masked representation.
        /// </summary>
        /// <param name="value">A valid masked representation of an integer</param>
        /// <returns>Integer value as MaskableInt32</returns>
        /// <remarks>
        /// The value provided must be a valid representation of a previously masked integer.
        /// </remarks>
        [Pure]
        public static MaskableInt32 GetUnmaskedValue(string value)
        {
            int deobfuscatedValue = IntegerObfuscator.Deobfuscate(value);
            return deobfuscatedValue;
        }

        /// <summary>
        /// Sets the salt value used for obfuscating (masking) the underlying integer value of the MaskableInt32
        /// </summary>
        /// <param name="salt"></param>
        public static void SetObfuscationSalt(string salt)
        {
            IntegerObfuscator.SetObfuscationSalt(salt);
        }

        /// <summary>
        /// Sets the alphabet used for obfuscating (masking) the underlying integer value of the MaskableInt32.
        /// </summary>
        /// <param name="alphabet"></param>
        public static void SetObfuscationAlphabet(string alphabet)
        {
            IntegerObfuscator.SetObfuscationAlphabet(alphabet);
        }

        public override string ToString()
        {
            return Val.ToString(NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Parses an integer from a String
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <returns>Parsed value as integer</returns>
        [Pure]
        public static int Parse(string value)
        {
            return Int32.Parse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Parses an integer from a String in the given style. 
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in 'value'</param>
        /// <returns>Parsed value as integer</returns>
        [Pure]
        public static int Parse(string value, NumberStyles style)
        {
            return Int32.Parse(value, style, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Parses an integer from a String in the given style. 
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="provider">An object that specifies culture-specific formatting information about 'value'</param>
        /// <returns>Parsed value as integer</returns>
        [Pure]
        public static int Parse(string value, IFormatProvider provider)
        {
            return Int32.Parse(value, NumberStyles.Integer, NumberFormatInfo.GetInstance(provider));
        }

        /// <summary>
        /// Parses an integer from a String in the given style.  If
        /// a NumberFormatInfo isn't specified, the current culture's 
        /// NumberFormatInfo is assumed.
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in 'value'</param>
        /// <param name="provider">An object that specifies culture-specific formatting information about 'value'</param>
        /// <returns>Parsed value as integer</returns>
        [Pure]
        public static int Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            return Int32.Parse(value, style, NumberFormatInfo.GetInstance(provider));
        }

        /// <summary>
        /// Parses an integer from a String. Returns false rather
        /// than throwing exceptin if input is invalid
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="result">The value resulted in case the conversion succeeded</param>
        /// <returns>A boolean value indicating if the parsing succeeded</returns>
        [Pure]
        public static bool TryParse(string value, out Int32 result)
        {
            return Int32.TryParse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
        }

        /// <summary>
        /// Parses an integer from a String in the given style. Returns false rather
        /// than throwing exceptin if input is invalid
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in 'value'</param>
        /// <param name="provider">An object that specifies culture-specific formatting information about 'value'</param>
        /// <param name="result">The value resulted in case the conversion succeeded</param>
        /// <returns>A boolean value indicating if the parsing succeeded</returns>
        [Pure]
        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out Int32 result)
        {
            return Int32.TryParse(value, style, NumberFormatInfo.GetInstance(provider), out result);
        }
    }
}