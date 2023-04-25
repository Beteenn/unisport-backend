using Application.Configuration.Identity.Interfaces;
using Domain.AggregateModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Identity
{
	public class TokenService : ITokenService
	{
        private readonly string _tokenSecret;
        //private readonly IServicoCriptografia _servicoCriptografia;

        public TokenService(IConfiguration configuration) //IServicoCriptografia servicoCriptografia)
        {
            _tokenSecret = configuration.GetSection("BearerSettings:Secret").Value;
            //_servicoCriptografia = servicoCriptografia;
        }

        private Claim CriptografarClaim(string nome, string valor) //IServicoCriptografia servicoCriptografia)
            => new Claim(nome, valor);//servicoCriptografia.EncryptString(valor));

        private string DescriptografarClaim(string nome, IEnumerable<Claim> claims) //IServicoCriptografia servicoCriptografia)
            => claims.FirstOrDefault(x => x.Type == nome)?.Value;//servicoCriptografia.DecryptString(claims.FirstOrDefault(x => x.Type == nome)?.Value);

        private IEnumerable<string> DescriptografarListaClaims(string nome, IEnumerable<Claim> claims) //IServicoCriptografia servicoCriptografia)
            => claims.Where(x => x.Type == nome).Select(y => y.Value);//servicoCriptografia.DecryptString(y.Value));

        private void AdicionarListaClaimsCriptografada(SecurityTokenDescriptor tokenDescriptor, string nome, List<string> valores)
            => tokenDescriptor.Subject.AddClaims(valores.Select(r => CriptografarClaim(nome, r)));//_servicoCriptografia)));

        public DateTime DataCriacaoTokenJWT(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token);
            var jwtToken = jsonToken as JwtSecurityToken;

            return jwtToken.ValidFrom;
        }

        public DateTime DataExpiracaoTokenJWT(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token);
            var jwtToken = jsonToken as JwtSecurityToken;

            return jwtToken.ValidTo;
        }

        public Usuario ObterUsuarioTokenJWT(string token)
        {
            Usuario usuario = null;

            if (string.IsNullOrEmpty(token)) return usuario;

            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token);
            var jwtToken = jsonToken as JwtSecurityToken;

            var idUsuario = DescriptografarClaim("id", jwtToken.Claims); //_servicoCriptografia);
            var cpf = DescriptografarClaim("cpf", jwtToken.Claims); //_servicoCriptografia);
            var perfilUsuario = DescriptografarClaim("role", jwtToken.Claims); //_servicoCriptografia);
            //var claims = DescriptografarListaClaims("claims", jwtToken.Claims, _servicoCriptografia);

            if (string.IsNullOrEmpty(idUsuario)) return usuario;

            usuario = new Usuario(Convert.ToInt64(idUsuario), perfilUsuario);

            return usuario;
        }

        public string GerarToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    CriptografarClaim("id", user.Id.ToString()), //_servicoCriptografia),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddMinutes(30),
                NotBefore = DateTime.Now
            };

            var perfisUsuario = user.UserRoles.Select(x => x.NormalizedName).ToList();
            AdicionarListaClaimsCriptografada(tokenDescriptor, ClaimTypes.Role, perfisUsuario);

            //var claimUsuario = user.Claims.Select(x => x.ClaimValue).ToList();
            //AdicionarListaClaimsCriptografada(tokenDescriptor, "claims", claimUsuario);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
