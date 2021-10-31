using BlazorServer.AppDbContext;
using BlazorServer.Middleware;
using BlazorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class LoginService
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BaseResponseSuccess<UserEntity> Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                return new BaseResponseSuccess<UserEntity>(null);
            }

            return new BaseResponseSuccess<UserEntity>(user);
        }

        public BaseResponse Register(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                return new BaseResponseError("Username already exist");
            }

            _context.Users.Add(new UserEntity
            {
                Username = username,
                Password = password
            });

            _context.SaveChanges();

            var token = Guid.NewGuid();

            return new BaseResponseSuccess<UserEntity>(user, token);
        }

        public void init()
        {
            var exist = _context.Browsers.Any();

            if (exist == false)
            {
                var names = new List<string>
                {
                    "facebook",
                    "gmail",
                    "microsoflt",
                    "instagram",
                };
                foreach (var n in names)
                {
                    _context.Browsers.Add(new Entity.BrowserEntity
                    {
                        IsPublic = true,
                        Image = n,
                        Name = n
                    });
                }

                _context.SaveChanges();
            }
        }
    }
}
