using Application.AuxiliaryClasses;
using Application.ViewModels;
using Domain.AggregateModels;

namespace Application.Configuration.Identity.Interfaces
{
    public interface ITokenService
    {
        Usuario ObterUsuarioTokenJWT(string token);
        DateTime DataExpiracaoTokenJWT(string token);
        DateTime DataCriacaoTokenJWT(string token);
        string GerarToken(Usuario user);
        Task<Result<UsuarioTokenViewModel>> ObterConteudoTokenJWT(string token);
    }
}
