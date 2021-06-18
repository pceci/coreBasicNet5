using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace coreBasicNet5.Codigo.Criptografía
{
    public class cSHA1
    {
        public static byte[] claveSHA1(byte[] pValor)
        {
            // Crear una clave SHA1 a partir del texto indicado.
            // Devuelve un array de bytes con la clave SHA1 generada
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(pValor);
        }
    }
}
