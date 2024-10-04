using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUSeedAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    
                    DisplayName = "Youssef Ahmed",
                    Email = "youssef123@gmail.com",
                    UserName = "youssef1",
                    Address = new Address
                    {
                        FirstName = "Youssef",
                        LastName = "Ahmed",
                        City = "Downtown",
                        State = "Cairo",
                        Street = "2",
                        PostalCode = "12345"
                    }
                };
                await userManager.CreateAsync(user,"Password123@");
            }
        }
    }
}
