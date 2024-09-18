using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Seguridad.Business.Contracts;
using PruebaTecnica.Seguridad.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Seguridad.Business.Code
{
    public class AutorizacionBusiness : IAutorizacionBusiness
    {
        private IConfiguration _configurationServices;
        public AutorizacionBusiness(IConfiguration configurationServices)
        {
            _configurationServices = configurationServices;
        }

        public async Task<AutorizacionE> Token()
        {
            var signgCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pZroXVxJVC026tQIJ3uU4wRh8P7iRdQNq14TIEW9s2XCgtDtD6SYR1GDGAFXLXPC")),
                SecurityAlgorithms.HmacSha256Signature
            );

            var jwt = new JwtSecurityToken(
                issuer: _configurationServices["AutenticationSettings:Issuer"],
                audience: _configurationServices["AutenticationSettings:Audience"],
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1000),
                signingCredentials: signgCredentials
            );

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return await Task.FromResult(new AutorizacionE { Token = encodeJwt });
        }
    }
}
