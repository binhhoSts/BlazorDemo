using BlazorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Entity
{
    public class AppPasswordEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int BrowserId { get; set; }
        public BrowserEntity Browser { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
