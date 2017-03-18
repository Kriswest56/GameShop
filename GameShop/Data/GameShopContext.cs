using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameShop.Models;

namespace GameShop.Models
{
    public class GameShopContext : DbContext
    {
        public GameShopContext (DbContextOptions<GameShopContext> options)
            : base(options)
        {
        }

        public DbSet<GameShop.Models.Game> Game { get; set; }

        public DbSet<GameShop.Models.Consoles> Console { get; set; }
    }
}
