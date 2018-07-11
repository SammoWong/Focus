using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Focus.Infrastructure
{
    public static class PasswordHelper
    {
        private const int SaltByteSize = 24;
        public static string GenerateSalt(int size = SaltByteSize)
        {
            using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[size];
                saltGenerator.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        public static string ComputeHash(string plainText, string salt)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var plainTextWithSaltBytes = new List<byte>(plainTextBytes.Length + saltBytes.Length);
            plainTextWithSaltBytes.AddRange(plainTextBytes);
            plainTextWithSaltBytes.AddRange(saltBytes);

            HashAlgorithm algorithm = new SHA256Managed();
            var byteHash = algorithm.ComputeHash(plainTextWithSaltBytes.ToArray());
            return Convert.ToBase64String(byteHash);
        }
    }
}
