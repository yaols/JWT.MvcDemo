using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace JWT.MvcDemo.Help
{

    public class DESCryption
    {

        /// <summary>
        /// //注意了，是8个字符，64位
        /// </summary>
        private static string PrivateRsa = ConfigurationManager.AppSettings["PrivateRsa"];

        /// <summary>
        /// //注意了，是8个字符，64位
        /// </summary>
        private static string PublicRsa = ConfigurationManager.AppSettings["PublicRsa"];

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {
            byte[] byKey = Encoding.ASCII.GetBytes(PrivateRsa);
            byte[] byIV = Encoding.ASCII.GetBytes(PublicRsa);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {
            byte[] byKey = Encoding.ASCII.GetBytes(PrivateRsa);
            byte[] byIV = Encoding.ASCII.GetBytes(PublicRsa);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

    }
}
