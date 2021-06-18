using System;
using System.Collections.Generic;
using System.Text;

namespace coreBasicNet5.Entities.Authenticate
{
    public class AuthenticateResponse
    {
        public int usu_codigo { get; set; }
        public int cli_codigo { get; set; }
        public string login { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse()
        { }
       /* public AuthenticateResponse(User user, string token)
        {
            usu_codigo = user.usu_codigo;
            cli_codigo = user.cli_codigo;
            Token = token;
        }*/
        public AuthenticateResponse(User user, string token)
        {
            usu_codigo = user.usu_codigo;
            cli_codigo = user.cli_codigo;
            Token = token;
            login = user.usu_login;
        }
    }
}
