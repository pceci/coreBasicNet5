using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace coreBasicNet5.Codigo.Criptografía
{
    public class cPasosSeguridad
    {
        public static void test()
        {
            cSegUsuario oUserA;
            cSegUsuario oUserB;
            cSessionSeg oSession;
            oUserA = new cSegUsuario();
            oUserB = new cSegUsuario();
            RSACryptoServiceProvider RSAServiceA = new RSACryptoServiceProvider(3072);
            oUserA.keyPrivate = RSAServiceA.ToXmlString(true);
            oUserA.keyPublic = RSAServiceA.ToXmlString(false);
            RSACryptoServiceProvider RSAServiceB = new RSACryptoServiceProvider(3072);
            oUserB.keyPrivate = RSAServiceB.ToXmlString(true);
            oUserB.keyPublic = RSAServiceB.ToXmlString(false);
            IFormatter formatter = new BinaryFormatter();

            /*
            FileStream s = new FileStream("userA.txt", FileMode.Create);
            formatter.Serialize(s, oUserA);
            s.Close();

            FileStream sB = new FileStream("userB.txt", FileMode.Create);
            formatter.Serialize(sB, oUserA);
            sB.Close();
            */
            Random rdo = new Random(DateTime.Now.Millisecond);
            oSession = new cSessionSeg(Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString() + " : " + rdo.Next(DateTime.Now.Millisecond).ToString() + " : " + DateTime.Now.Millisecond.ToString()));

            cReturnValue oReturnValue = cPasosSeguridad.Encriptar_class(Encoding.UTF8.GetBytes("Hola Mundo"), oUserA, oUserB, oSession);
            byte[] oReturnValue_Desencriptar = cPasosSeguridad.Desencriptar_class(oReturnValue, oUserA, oUserB);
            //byte[] Desencriptar_class
            var resultado_Encriptar = System.Text.Encoding.Default.GetString(oReturnValue.msg);

            var resultado_Desencriptar = System.Text.Encoding.Default.GetString(oReturnValue_Desencriptar);
        }
        public static void test_2()
        {
            cSegUsuario oUserA;
            cSegUsuario oUserB;
            cSessionSeg oSession;
            oUserA = new cSegUsuario();
            oUserB = new cSegUsuario();
            RSACryptoServiceProvider RSAServiceA = new RSACryptoServiceProvider(3072);
            oUserA.keyPrivate = RSAServiceA.ToXmlString(true);
            oUserA.keyPublic = RSAServiceA.ToXmlString(false);
            RSACryptoServiceProvider RSAServiceB = new RSACryptoServiceProvider(3072);
            oUserB.keyPrivate = RSAServiceB.ToXmlString(true);
            oUserB.keyPublic = RSAServiceB.ToXmlString(false);
            IFormatter formatter = new BinaryFormatter();

            /*
            FileStream s = new FileStream("userA.txt", FileMode.Create);
            formatter.Serialize(s, oUserA);
            s.Close();

            FileStream sB = new FileStream("userB.txt", FileMode.Create);
            formatter.Serialize(sB, oUserA);
            sB.Close();
            */
            Random rdo = new Random(DateTime.Now.Millisecond);
            oSession = new cSessionSeg(Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString() + " : " + rdo.Next(DateTime.Now.Millisecond).ToString() + " : " + DateTime.Now.Millisecond.ToString()));

            String oReturnValue = cPasosSeguridad.EncriptarJson(Encoding.UTF8.GetBytes("Hola Mundo"), oUserA, oUserB, oSession);
            byte[] oReturnValue_Desencriptar = cPasosSeguridad.DesencriptarJson(oReturnValue, oUserA, oUserB);
            //byte[] Desencriptar_class
            var resultado_Encriptar = oReturnValue;

            var resultado_Desencriptar = System.Text.Encoding.Default.GetString(oReturnValue_Desencriptar);
        }
        /*public static byte[] Encriptar(byte[] pValue, cSegUsuario pUserA, cSegUsuario pUserB, cSessionSeg pSession)
        {
            byte[] result = null;
            cReturnValue objReturnValue = new cReturnValue();
            byte[] hash = cSHA1.claveSHA1(pValue);
            byte[] hashSignature = cRSA.createSignaturesRSA(hash, pUserA.keyPrivate);
            objReturnValue.msg = cAES.encryptString(pValue, pSession.Key, pSession.IV);
            objReturnValue.Key_RSA = cRSA.EncrytText(pSession.Key, pUserB.keyPublic);
            objReturnValue.IV_RSA = cRSA.EncrytText(pSession.IV, pUserB.keyPublic);
            objReturnValue.HashValidate_RSA = hashSignature;
            result = cSerialization.ToByteArray(objReturnValue);
            return result;
        }

        public static byte[] Desencriptar(byte[] pValue, cSegUsuario pUserA, cSegUsuario pUserB)
        {
            byte[] result = null;
            var ReturnValueByteArrayToObject = cSerialization.ByteArrayToObject(pValue);
            cReturnValue objReturnValue = (cReturnValue)ReturnValueByteArrayToObject;
            byte[] objReturnValueHidden_Key = cRSA.DecryptText(objReturnValue.Key_RSA, pUserB.keyPrivate);
            byte[] objReturnValueHidden_IV = cRSA.DecryptText(objReturnValue.IV_RSA, pUserB.keyPrivate);
            byte[] objReturnValueHidden_HashValidate = objReturnValue.HashValidate_RSA;
            objReturnValue.msg = cAES.decryptString(objReturnValue.msg, objReturnValueHidden_Key, objReturnValueHidden_IV);
            byte[] hash = cSHA1.claveSHA1(objReturnValue.msg);
            bool isValidate = cRSA.isVerifySignaturesDSA(pUserA.keyPublic, objReturnValueHidden_HashValidate, hash);
            if (isValidate)
                result = objReturnValue.msg;
            return result;
        }*/
        public static String EncriptarJson(byte[] pValue, cSegUsuario pUserA, cSegUsuario pUserB, cSessionSeg pSession)
        {
            String result = null;
            cReturnValue objReturnValue = new cReturnValue();
            byte[] hash = cSHA1.claveSHA1(pValue);
            byte[] hashSignature = cRSA.createSignaturesRSA(hash, pUserA.keyPrivate);
            objReturnValue.msg = cAES.encryptString(pValue, pSession.Key, pSession.IV);
            objReturnValue.Key_RSA = cRSA.EncrytText(pSession.Key, pUserB.keyPublic);
            objReturnValue.IV_RSA = cRSA.EncrytText(pSession.IV, pUserB.keyPublic);
            objReturnValue.HashValidate_RSA = hashSignature;
            result = coreBasicNet5.Codigo.Serializador.SerializarAJson(objReturnValue);
            return result;
        }

        public static byte[] DesencriptarJson(String pValue, cSegUsuario pUserA, cSegUsuario pUserB)
        {
            byte[] result = null;
            cReturnValue objReturnValue = coreBasicNet5.Codigo.Serializador.DeserializarJson<cReturnValue>(pValue);
            byte[] objReturnValueHidden_Key = cRSA.DecryptText(objReturnValue.Key_RSA, pUserB.keyPrivate);
            byte[] objReturnValueHidden_IV = cRSA.DecryptText(objReturnValue.IV_RSA, pUserB.keyPrivate);
            byte[] objReturnValueHidden_HashValidate = objReturnValue.HashValidate_RSA;
            objReturnValue.msg = cAES.decryptString(objReturnValue.msg, objReturnValueHidden_Key, objReturnValueHidden_IV);
            byte[] hash = cSHA1.claveSHA1(objReturnValue.msg);
            bool isValidate = cRSA.isVerifySignaturesDSA(pUserA.keyPublic, objReturnValueHidden_HashValidate, hash);
            if (isValidate)
                result = objReturnValue.msg;
            return result;
        }          
        public static cReturnValue Encriptar_class(byte[] pValue, cSegUsuario pUserA, cSegUsuario pUserB, cSessionSeg pSession)
        {
            cReturnValue objReturnValue = new cReturnValue();
            byte[] hash = cSHA1.claveSHA1(pValue);
            byte[] hashSignature = cRSA.createSignaturesRSA(hash, pUserA.keyPrivate);
            objReturnValue.msg = cAES.encryptString(pValue, pSession.Key, pSession.IV);
            objReturnValue.Key_RSA = cRSA.EncrytText(pSession.Key, pUserB.keyPublic);
            objReturnValue.IV_RSA = cRSA.EncrytText(pSession.IV, pUserB.keyPublic);
            objReturnValue.HashValidate_RSA = hashSignature;
            return objReturnValue;
        }

        public static byte[] Desencriptar_class(cReturnValue objReturnValue, cSegUsuario pUserA, cSegUsuario pUserB)
        {
            byte[] result = null;
            byte[] objReturnValueHidden_Key = cRSA.DecryptText(objReturnValue.Key_RSA, pUserB.keyPrivate);
            byte[] objReturnValueHidden_IV = cRSA.DecryptText(objReturnValue.IV_RSA, pUserB.keyPrivate);
            byte[] objReturnValueHidden_HashValidate = objReturnValue.HashValidate_RSA;
            byte[] objReturnValue_msg = cAES.decryptString(objReturnValue.msg, objReturnValueHidden_Key, objReturnValueHidden_IV);
            byte[] hash = cSHA1.claveSHA1(objReturnValue_msg);
            bool isValidate = cRSA.isVerifySignaturesDSA(pUserA.keyPublic, objReturnValueHidden_HashValidate, hash);
            if (isValidate)
                result = objReturnValue_msg;
            return result;
        }
    }
}
