using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Entity.Orders;
using BaseJWT.Domain.Entity.Shop;
using BaseJWT.Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace BaseJWT.Infrastructure.EntityFramework.Seeder
{
    public class Seeder
    {
        private readonly DataContext context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<User> userManager;

        public Seeder(DataContext ctx, IHostingEnvironment hosting, UserManager<User> userManager)
        {
            context = ctx;
            _hosting = hosting;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                var user = new User("test@gmail.com");
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.UserName = "TestUser";
               var result =  await userManager.CreateAsync(user, "Test123.");
            }
        }
    }
}
