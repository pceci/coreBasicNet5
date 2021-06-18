using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreBasicNet5.Entities.Authenticate
{
    public class User
    {
        public int usu_codigo { get; set; }
        public int cli_codigo { get; set; }
        public int usu_codRol { get; set; }
        public int usu_estado { get; set; }
        public string usu_login { get; set; }
        public string usu_nombre { get; set; }
        public string usu_apellido { get; set; }


    }
}
