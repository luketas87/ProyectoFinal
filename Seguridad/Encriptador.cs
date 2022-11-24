using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

namespace Seguridad
{
    public class Encriptador
    {
#pragma warning disable CS0169 // El campo 'Encriptador.cipherData' nunca se usa
        readonly string cipherData;
#pragma warning restore CS0169 // El campo 'Encriptador.cipherData' nunca se usa
#pragma warning disable CS0169 // El campo 'Encriptador.cipherBytes' nunca se usa
        readonly byte[] cipherBytes;
#pragma warning restore CS0169 // El campo 'Encriptador.cipherBytes' nunca se usa
#pragma warning disable CS0169 // El campo 'Encriptador.plainBytes' nunca se usa
        readonly byte[] plainBytes;
#pragma warning restore CS0169 // El campo 'Encriptador.plainBytes' nunca se usa
#pragma warning disable CS0169 // El campo 'Encriptador.plainKey' nunca se usa
        readonly byte[] plainKey;
#pragma warning restore CS0169 // El campo 'Encriptador.plainKey' nunca se usa

#pragma warning disable CS0169 // El campo 'Encriptador.sha' nunca se usa
        HashAlgorithm sha;
#pragma warning restore CS0169 // El campo 'Encriptador.sha' nunca se usa
#pragma warning disable CS0169 // El campo 'Encriptador.desObj' nunca se usa
        SymmetricAlgorithm desObj;
#pragma warning restore CS0169 // El campo 'Encriptador.desObj' nunca se usa
        public Encriptador()
        {

        }
        private string _encriptarIrreversible(string pCadena)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pCadena));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public string EncriptarIrreversible(string pCadena)
        {
            return _encriptarIrreversible(pCadena);
        }

        public string EncriptarReversible(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;
            string clave = "Patitas2022";
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(clave);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public string Desencriptar(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            string clave = "Patitas2022";
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(clave);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
