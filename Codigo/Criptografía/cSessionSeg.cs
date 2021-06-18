using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace coreBasicNet5.Codigo.Criptografía
{
     [Serializable]
    public class cSessionSeg 
    {
        public cSessionSeg(byte[] pInit)
        {
            byte[] valor = cSHA512.claveSHA512(pInit);
            Key = valor.Take(32).ToArray();
            IV = valor.Take(16).ToArray();
        }
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
        public byte[] HashValidate { get; set; }
    }
}