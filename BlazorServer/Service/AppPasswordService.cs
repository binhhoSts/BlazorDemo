using BlazorServer.AppDbContext;
using BlazorServer.Entity;
using BlazorServer.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class AppPasswordService : BaseService
    {
        public AppPasswordService(ApplicationDbContext context) : base(context)
        {
        }

        public void Add(AppPasswordEntity model)
        {
            _context.AppPasswords.Add(model);
        }
    }
}
