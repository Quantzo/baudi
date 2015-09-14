using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Baudi.Client.Helpers
{
    /// <summary>
    /// Security helper
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// Returns hash from password and salt
        /// </summary>
        /// <param name="passwordSalt">Salt</param>
        /// <param name="password">Password</param>
        /// <returns>Hash</returns>
        public static string ComputeHash(string passwordSalt, SecureString password)
        {


            string computedHash;
            using (var hash = new SHA512Managed())
            {
                foreach (var character in passwordSalt)
                {
                    password.AppendChar(character);
                }

                computedHash =
                    Convert.ToBase64String(hash.ComputeHash(GetBytesFromSecureString(password)));
            }
            return computedHash;
        }

        /// <summary>
        /// Generaters salt
        /// </summary>
        /// <returns>Salt</returns>
        public static string GeneratePasswordSalt()
        {
            byte[] salt = new byte[4096];
            using (var rngSaltProvider = new RNGCryptoServiceProvider())
            {
                rngSaltProvider.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);

        }

        /// <summary>
        /// Get bytes from secure string
        /// </summary>
        /// <param name="password">Secure string with password</param>
        /// <returns>Password in byte form</returns>
        public unsafe static byte[] GetBytesFromSecureString(SecureString password)
        {
            byte[] bValue;

            IntPtr unmanagedBytes = Marshal.SecureStringToGlobalAllocAnsi(password);
            try
            {
                byte* byteArray = (byte*)unmanagedBytes.ToPointer();

                byte* pEnd = byteArray;
                while (*pEnd++ != 0) { }
                int length = (int)((pEnd - byteArray) - 1);
                bValue = new byte[length];
                for (int i = 0; i < length; ++i)
                {
                    bValue[i] = *(byteArray + i);
                }
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocAnsi(unmanagedBytes);
            }
            return bValue;
        }

    }
}