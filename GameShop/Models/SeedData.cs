using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GameShop.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameShopContext(
                serviceProvider.GetRequiredService<DbContextOptions<GameShopContext>>()))
            {
                // Look for any movies.
                if (context.Game.Any())
                {
                    return;   // DB has been seeded
                }

                context.Game.AddRange(
                     new Game
                     {
                         Title = "Mass Effect Andromeda",
                         ReleaseDate = DateTime.Parse("2017-3-21"),
                         Genre = "RPG",
                         Price = 59.99M,
                         Console = "PC"
                     },

                     new Game
                     {
                         Title = "Overwatch",
                         ReleaseDate = DateTime.Parse("2016-5-24"),
                         Genre = "First Person Shooter",
                         Price = 39.99M, 
                         Console = "PC"
                     },

                     new Game
                     {
                         Title = "Punch Out",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Action",
                         Price = 9.99M,
                         Console = "Nintendo"
                     },

                    new Game
                    {
                        Title = "The Legend of Zelda: Breath of the Wild",
                        ReleaseDate = DateTime.Parse("2017-3-3"),
                        Genre = "Adventure",
                        Price = 59.99M,
                        Console = "Nintendo"
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
