using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace coreBasicNet5.Codigo.Criptografía
{
    public class cAES
    {
        private static Rijndael _rijndael { get; set; }
        private static Rijndael rijndael
        {
            get
            {
                if (_rijndael == null)
                    _rijndael = Rijndael.Create();
                return _rijndael;
            }
        }
        public static byte[] GetKey()
        {
            rijndael.GenerateKey();
            return rijndael.Key;
        }
        public static byte[] GetIV()
        {
            rijndael.GenerateIV();
            return rijndael.IV;
        }


        public static byte[] encryptString(byte[] plainMessageBytes, byte[] Key, byte[] IV)
        {
            // Crear una instancia del algoritmo de Rijndael
            Rijndael RijndaelAlg = Rijndael.Create();

            // Establecer un flujo en memoria para el cifrado
            MemoryStream memoryStream = new MemoryStream();

            // Crear un flujo de cifrado basado en el flujo de los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateEncryptor(Key, IV),
                                                         CryptoStreamMode.Write);

            // Obtener la representación en bytes de la información a cifrar
            //byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(plainMessage);

            // Cifrar los datos enviándolos al flujo de cifrado
            cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);

            cryptoStream.FlushFinalBlock();

            // Obtener los datos datos cifrados como un arreglo de bytes
            byte[] cipherMessageBytes = memoryStream.ToArray();

            // Cerrar los flujos utilizados
            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos cifrados
            return cipherMessageBytes;
        }
        public static byte[] decryptString(byte[] cipherTextBytes, byte[] Key, byte[] IV)
        {
            // Obtener la representación en bytes del texto cifrado
            //byte[] cipherTextBytes = Convert.FromBase64String(encryptedMessage);

            // Crear un arreglo de bytes para almacenar los datos descifrados
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Crear una instancia del algoritmo de Rijndael
            Rijndael RijndaelAlg = Rijndael.Create();

            // Crear un flujo en memoria con la representación de bytes de la información cifrada
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Crear un flujo de descifrado basado en el flujo de los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateDecryptor(Key, IV),
                                                         CryptoStreamMode.Read);

            // Obtener los datos descifrados obteniéndolos del flujo de descifrado
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Cerrar los flujos utilizados
            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos descifrados
            //return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainTextBytes.Take(decryptedByteCount).ToArray();// decryptedByteCount);
        }


    }
}