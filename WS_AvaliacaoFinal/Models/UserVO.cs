using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AvaliacaoFinal.Models
{

    public class UserVO
    { 
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

    }
}
