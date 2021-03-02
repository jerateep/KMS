using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace KMS.Web.Extensions
{
    public class HashPasswordAuth
    {
        public static string EncryptString(string InputText)
        {
            string Password = "IS@d1234#@%@#^SDSdffsdS";
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] bytes1 = Encoding.Unicode.GetBytes(InputText);
            byte[] bytes2 = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Password, bytes2);
            ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(passwordDeriveBytes.GetBytes(16), passwordDeriveBytes.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(bytes1, 0, bytes1.Length);
            cryptoStream.FlushFinalBlock();
            byte[] array = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string InputText)
        {
            string Password = "IS@d1234#@%@#^SDSdffsdS";
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] buffer = Convert.FromBase64String(InputText);
            byte[] bytes = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Password, bytes);
            ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(passwordDeriveBytes.GetBytes(16), passwordDeriveBytes.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(buffer);
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] numArray = new byte[buffer.Length];
            int count = cryptoStream.Read(numArray, 0, numArray.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.Unicode.GetString(numArray, 0, count);
        }
    }
}