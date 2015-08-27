using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Baudi.Client.Helpers
{
    public static class SecurityHelper
    {
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

        public static string GeneratePasswordSalt()
        {
            byte[] salt = new byte[4096];
            using (var rngSaltProvider = new RNGCryptoServiceProvider())
            {
                rngSaltProvider.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);

        }

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