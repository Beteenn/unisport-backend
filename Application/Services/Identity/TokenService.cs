using Application.AuxiliaryClasses;
using Application.Configuration.Identity.Interfaces;
using Application.ViewModels;
using Domain.AggregateModels;
using Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Identity
{
    public class TokenService : ITokenService
    {
        private IUsuarioPrincipal _usuarioPrincipal;
        private readonly string _tokenSecret;
        //private readonly IServicoCriptografia _servicoCriptografia;

        public TokenService(IConfiguration configuration, IUsuarioPrincipal principal) //IServicoCriptografia servicoCriptografia)
        {
            _tokenSecret = configuration.GetSection("BearerSettings:Secret").Value;
            //_servicoCriptografia = servicoCriptografia;
            _usuarioPrincipal = principal;
        }

        private Claim CriptografarClaim(string nome, string valor) //IServicoCriptografia servicoCriptografia)
            => new Claim(nome, valor);//servicoCriptografia.EncryptString(valor));

        private string DescriptografarClaim(string nome, IEnumerable<Claim> claims) //IServicoCriptografia servicoCriptografia)
            => claims.FirstOrDefault(x => x.Type == nome)?.Value;//servicoCriptografia.DecryptString(claims.FirstOrDefault(x => x.Type == nome)?.Value);

        private IEnumerable<string> DescriptografarListaClaims(string nome, IEnumerable<Claim> claims) //IServicoCriptografia servicoCriptografia)
            => claims.Where(x => x.Type == nome).Select(y => y.Value);//servicoCriptografia.DecryptString(y.Value));

        private void AdicionarListaClaimsCriptografada(SecurityTokenDescriptor tokenDescriptor, string nome, List<string> valores)
            => tokenDescriptor.Subject.AddClaims(valores.Select(r => CriptografarClaim(nome, r)));//_servicoCriptografia)));

        private UsuarioTokenViewModel DescriptografarTokenJWT(string token)
        {
            UsuarioTokenViewModel usuario = null;

            if (string.IsNullOrEmpty(token)) return usuario;

            try
            {
                var user = ObterUsuarioTokenJWT(token);
                var dataCriacaoToken = DataCriacaoTokenJWT(token);
                var dataExpiracaoToken = DataExpiracaoTokenJWT(token);

                PreencheExpiracaoUsuarioPrincipal(dataExpiracaoToken);

                if (user == null) return usuario;

                usuario = new UsuarioTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    DataCriacao = dataCriacaoToken,
                    DataExpiracao = dataExpiracaoToken,
                    //Claims = user.Claims.Select(x => x.ClaimValue).ToList
                };
            }
            catch (Exception ex)
            {
                //Logger.Error(ex);
            }

            return usuario;
        }

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

            var usuarioId = DescriptografarClaim("id", jwtToken.Claims); //_servicoCriptografia);
            var email = DescriptografarClaim("email", jwtToken.Claims); //_servicoCriptografia);
            var admin = DescriptografarClaim("admin", jwtToken.Claims); //_servicoCriptografia);
            //var claims = DescriptografarListaClaims("claims", jwtToken.Claims, _servicoCriptografia);

            if (string.IsNullOrEmpty(usuarioId)) return usuario;

            usuario = new Usuario(long.Parse(usuarioId), email, bool.Parse(admin));

            PreencheUsuarioPrincipal(usuario, token);

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
                    CriptografarClaim("email", user.Email), //_servicoCriptografia),
                    CriptografarClaim("admin", user.Admin.ToString()), //_servicoCriptografia),
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

        private void PreencheUsuarioPrincipal(Usuario usuario, string token)
        {
            _usuarioPrincipal.SetId(usuario.Id);
            _usuarioPrincipal.SetEmail(usuario.Email);
            _usuarioPrincipal.SetAdmin(usuario.Admin);
            _usuarioPrincipal.AddRole(usuario.UserRoles?.FirstOrDefault().Name);
            //_usuarioPrincipal.SetStatusToken(usuario.TokenExpirado);
            //usuario.Claims.ForEach(x => _usuarioPrincipal.AddClaim(x));

            var claimsidentity = new ClaimsIdentity(token);
            _usuarioPrincipal.SetAuthenticated(claimsidentity);
        }

        public async Task<Result<UsuarioTokenViewModel>> ObterConteudoTokenJWT(string token)
        {
            UsuarioTokenViewModel usuarioVm = DescriptografarTokenJWT(token);

            if (usuarioVm == null) return new Result<UsuarioTokenViewModel>().AdicionarMensagemErro("Token inválido");

            return new Result<UsuarioTokenViewModel>(usuarioVm);
        }

        public void PreencheExpiracaoUsuarioPrincipal(DateTime dataExpiracaoToken) => _usuarioPrincipal.SetStatusTokenInvalido(dataExpiracaoToken > DateTime.Now);
    }
}
