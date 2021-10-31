using BlazorServer.AppDbContext;
using BlazorServer.Entity;
using BlazorServer.Middleware;
using BlazorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class BrowserService : BaseService
    {
        public BrowserService(ApplicationDbContext context) : base(context)
        {
        }

        public List<BrowserEntity> GetAllPublicBrowser()
        {
            var listBrowsers = _context.Browsers.Where(x=>x.IsPublic).ToList();

            return new List<BrowserEntity>(listBrowsers);
        }

        public Guid? getCurrentUser()
        {
            return CurrentUser.UserId;
        }

        public void AddNewAppPass(AppPasswordEntity model)
        {
            _context.AppPasswords.Add(model);

            _context.SaveChanges();
        }

        public List<AppPasswordEntity> GetAppPass(Guid? userId)
        {
            return _context.AppPasswords.Where(x=>x.UserId == userId).ToList();
        }
    }
}
