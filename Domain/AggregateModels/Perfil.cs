using Microsoft.AspNetCore.Identity;

namespace Domain.AggregateModels
{
    public class Perfil : IdentityRole<long>
    {
        public Perfil()
        {

        }
        public Perfil(string perfil)
            : base(perfil)
        {
        }
    }
}
