using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace coreBasicNet5.Codigo.Criptografía
{
    public class cSHA512
    {
        public static byte[] claveSHA512(byte[] pValor)
        {
            // Crear una clave SHA512 a partir del texto indicado.
            // Devuelve un array de bytes con la clave SHA512 generada
            SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
            return sha512.ComputeHash(pValor);
        }
}
}
