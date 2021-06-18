using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using coreBasicNet5.Business;
using coreBasicNet5.Entities;
using System.Text;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace coreBasicNet5.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAdminService adminService;

        public AuthController(IAdminService pAdminService)
        {
            this.adminService = pAdminService;
        }
      /*  [HttpPost]
        [Route("[action]")]
        public IActionResult Login(AuthenticateRequest model)
        {
            // Tu código para validar que el usuario ingresado es válido

            // Asumamos que tenemos un usuario válido
            var user = new cUsuario
            {
                usu_codigo = 1,
                usu_nombre = "Eduardo",
                usu_mail = "admin@kodoti.com"//,
                // UserId = "a79b2e64-a4de-4f3a-8cf6-a68ba400db24"
            };

            // Leemos el secret_key desde nuestro appseting
            var keyJWT = coreBasicNet5.Codigo.Helper.keyJWT;//_configuration.GetValue<string>("SecretKey");
            // var key = Encoding.ASCII.GetBytes(keyJWT);

            // Creamos los claims (pertenencias, características) del usuario
            ClaimsIdentity oClaimsIdentity = new ClaimsIdentity();

            //     var claims = new[]
            //     {//. user.usu_codigo
            //     new Claim(ClaimTypes.NameIdentifier, "e883da63-e080-4c72-a152-125081f4aadc"),
            //     new Claim(ClaimTypes.Email, user.usu_mail)
            // };
            oClaimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "e883da63-e080-4c72-a152-125081f4aadc"));
            oClaimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.usu_mail));
            // oClaimsIdentity.AddClaims(claims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = oClaimsIdentity,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyJWT), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(tokenHandler.WriteToken(createdToken));
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login_viejo(LoginViewModel model)
        {
            // Tu código para validar que el usuario ingresado es válido

            // Asumamos que tenemos un usuario válido
            var user = new cUsuario
            {
                usu_codigo = 1,
                usu_nombre = "Eduardo",
                usu_mail = "admin@kodoti.com"//,
                // UserId = "a79b2e64-a4de-4f3a-8cf6-a68ba400db24"
            };

            // Leemos el secret_key desde nuestro appseting
            var keyJWT = coreBasicNet5.Codigo.Helper.keyJWT;//_configuration.GetValue<string>("SecretKey");
            // var key = Encoding.ASCII.GetBytes(keyJWT);

            // Creamos los claims (pertenencias, características) del usuario
            ClaimsIdentity oClaimsIdentity = new ClaimsIdentity();

            //     var claims = new[]
            //     {//. user.usu_codigo
            //     new Claim(ClaimTypes.NameIdentifier, "e883da63-e080-4c72-a152-125081f4aadc"),
            //     new Claim(ClaimTypes.Email, user.usu_mail)
            // };
            oClaimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "e883da63-e080-4c72-a152-125081f4aadc"));
            oClaimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.usu_mail));
            // oClaimsIdentity.AddClaims(claims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = oClaimsIdentity,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyJWT), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(tokenHandler.WriteToken(createdToken));
        }*/
    }
}