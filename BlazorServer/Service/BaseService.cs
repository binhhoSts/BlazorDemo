using BlazorServer.AppDbContext;
using BlazorServer.Middleware;
using BlazorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class BaseService
    {
        protected readonly ApplicationDbContext _context;

        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
