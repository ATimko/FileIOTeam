using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileIOTeam
{
    class EncDecHandler
    {
        public static string EncryptString(string ClearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            MemoryStream ms = new MemoryStream();

            string key1 = "aaaaaaaaaaaaaaaa";
            string key2 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            byte[] rgbIV = Encoding.ASCII.GetBytes(key1);
            byte[] key = Encoding.ASCII.GetBytes(key2);
            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);
            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DecryptString(string EncryptText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(EncryptText);
            MemoryStream ms = new MemoryStream();
            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();

            string key1 = "aaaaaaaaaaaaaaaa";
            string key2 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            byte[] rgbIV = Encoding.ASCII.GetBytes(key1);
            byte[] key = Encoding.ASCII.GetBytes(key2);
            CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV), CryptoStreamMode.Write);
            cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}