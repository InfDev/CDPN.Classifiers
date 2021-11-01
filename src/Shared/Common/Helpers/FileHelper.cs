using System;
using System.IO;
using System.Security.Cryptography;

namespace CDPN.Common.Helpers
{
    public static class FileHelper
    {
        public static string GetFileHashByMD5(string fileName)
        {
            using (var hashAlgorithm = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
#pragma warning disable CA1308 // Нормализуйте строки до прописных букв
                    return BitConverter.ToString(hashAlgorithm.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
#pragma warning restore CA1308 // Нормализуйте строки до прописных букв
                }
            }
        }

        public static string GetFileHashBySHA256(string fileName)
        {
            using (var hashAlgorithm = SHA256.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
#pragma warning disable CA1308 // Нормализуйте строки до прописных букв
                    return BitConverter.ToString(hashAlgorithm.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
#pragma warning restore CA1308 // Нормализуйте строки до прописных букв
                }
            }
        }
    }
}
