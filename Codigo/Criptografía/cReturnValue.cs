using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreBasicNet5.Codigo.Criptografía
{
    [Serializable]
    public class cReturnValue
    {
        public byte[] msg { get; set; }
        public byte[] Key_RSA { get; set; }
        public byte[] IV_RSA { get; set; }
        public byte[] HashValidate_RSA { get; set; }
    }
}
