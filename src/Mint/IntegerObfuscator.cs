using System;
using System.Globalization;
using System.Linq;
using HashidsNet;

namespace Mint
{
    internal static class IntegerObfuscator
    {
        private const string HasherPrefix = "MX";
        private static readonly int HasherPrefixLength = HasherPrefix.Length;

        private static string hasherSalt = "bdyer783djn";
        private static string hasherAlphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private static Hashids hasher = new Hashids(hasherSalt, 0, hasherAlphabet);

        public static string Obfuscate(int value)
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}{1}", HasherPrefix, hasher.Encode(value));
        }

        public static int Deobfuscate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid value provided - value cannot be empty.", nameof(value));
            }

            int number;
            if (!Int32.TryParse(value, out number))
            {
                if (value.StartsWith(HasherPrefix, StringComparison.Ordinal))
                {
                    value = value.Substring(HasherPrefixLength);
                }
                else
                {
                    throw new ArgumentException("Invalid value provided - it is not a valid representation of an obfuscated string", nameof(value));
                }

                int[] deobfuscatedValues = hasher.Decode(value);
                if (deobfuscatedValues == null || !deobfuscatedValues.Any())
                {
                    throw new ArgumentException("Invalid value provided - it is not a valid representation of an obfuscated string " +
                                                "or the obfuscation settings are different.", nameof(value));
                }

                return deobfuscatedValues.First();
            }

            return number;
        }

        public static void SetObfuscationSalt(string salt)
        {
            if (String.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(salt));
            }
            hasherSalt = salt;
            hasher = new Hashids(hasherSalt, 0, hasherAlphabet);
        }

        public static void SetObfuscationAlphabet(string alphabet)
        {
            if (String.IsNullOrWhiteSpace(alphabet))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(alphabet));
            }
            hasherAlphabet = alphabet;
            hasher = new Hashids(hasherSalt, 0, hasherAlphabet);
        }
    }
}
