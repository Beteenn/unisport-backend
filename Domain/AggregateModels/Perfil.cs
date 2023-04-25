using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
