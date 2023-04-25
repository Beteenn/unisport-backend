using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Logger
{
	public interface IIdentityServerLog
	{
        void Error(string message, params LogProperty[] properties);
        void Warning(string message, params LogProperty[] properties);
        void Debug(string message, params LogProperty[] properties);
        void Error(Exception exception, params LogProperty[] properties);
    }
}
