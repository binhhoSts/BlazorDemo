using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
