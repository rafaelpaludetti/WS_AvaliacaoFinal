using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AvaliacaoFinal.Models
{
    interface IUserDAL
    {
        UserVO GetUser(string username, string password);
    }
}
