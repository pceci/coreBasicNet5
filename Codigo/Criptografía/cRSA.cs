using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace coreBasicNet5.Codigo.Criptografía
{
    public class cRSA
    {
        public static RSACryptoServiceProvider _RSAService { get; set; }
        public static RSACryptoServiceProvider RSAService
        {
            get
            {
                if (_RSAService == null)
                    _RSAService = new RSACryptoServiceProvider(3072);//1024
                return _RSAService;
            }
        }

        public static byte[] CreatePublicKey()
        {
            string xmlPublicKey = RSAService.ToXmlString(false);
            return Encoding.UTF8.GetBytes(xmlPublicKey);
        }
        public static byte[] CreatePrivateKey()
        {
            string xmlPrivateKey = RSAService.ToXmlString(true);
            return Encoding.UTF8.GetBytes(xmlPrivateKey);
        }
        public static byte[] EncrytText(byte[] pValor, string xmlKey)
        {
            RSACryptoServiceProvider RSA = RSAService;
            RSA.FromXmlString(xmlKey);
            byte[] encrypteData = RSA.Encrypt(pValor, false);
            return encrypteData;
        }
        public static byte[] DecryptText(byte[] pValor, string xmlKey)
        {
            RSACryptoServiceProvider RSA = RSAService;
            RSA.FromXmlString(xmlKey);
            byte[] decryptData = RSA.Decrypt(pValor, false);
            return decryptData;
        }

        public static byte[] createSignaturesRSA(byte[] datosHash, string clavesXML)
        {
            RSACryptoServiceProvider RSA = RSAService;
            // Asignamos las claves indicadas
            RSA.FromXmlString(clavesXML);

            return RSA.SignData(datosHash, "SHA1");
        }

        public static bool isVerifySignaturesDSA(string clavePublica, byte[] firma, byte[] datosHash)
        {
            RSACryptoServiceProvider RSA = RSAService;
            // Asignamos las claves indicadas
            RSA.FromXmlString(clavePublica);
            // El tipo de algoritmo hash a usar

            // Devolver un valor boolean si la firma es correcta
            return RSA.VerifyData(datosHash, "SHA1", firma);
        }

    }
}
