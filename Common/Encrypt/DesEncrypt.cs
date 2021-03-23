using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Encrypt
{
    /// <summary>
    /// DES加密、解密帮助类
    /// </summary>
    public static class DesEncrypt
    {   
        private static string DESKey = "wangyilei_desencrypt_2021";

        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            return Encrypt(text, DESKey);
        }

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string text, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(text);
            des.Key = Encoding.ASCII.GetBytes(Md5.Hash(sKey).Substring(0, 8));
            des.IV = Encoding.ASCII.GetBytes(Md5.Hash(sKey).Substring(0, 8));
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }

            return ret.ToString();
        }

        #endregion

        #region ========解密========

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            return !string.IsNullOrEmpty(text) ? Decrypt(text, DESKey) : "";
        }

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string text, string sKey)
        {
            var des = new DESCryptoServiceProvider();
            var len = text.Length / 2;
            byte[] inputByteArray = new byte[len];
            for (int x = 0; x < len; x++)
            {
                var i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte) i;
            }

            des.Key = Encoding.ASCII.GetBytes( Md5.Hash(sKey).Substring(0, 8));
            des.IV = Encoding.ASCII.GetBytes(Md5.Hash(sKey).Substring(0, 8));
            using var ms = new System.IO.MemoryStream();
            using var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
    }
}