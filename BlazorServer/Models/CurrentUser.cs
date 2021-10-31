using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public static class CurrentUser
    {
        public static Guid? UserId { get; set; }
    }
}
