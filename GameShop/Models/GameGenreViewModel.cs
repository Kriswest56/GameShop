using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class GameGenreViewModel
    {
        public List<Game> games;
        public SelectList genres;
        public string gameGenre { get; set; }
    }
}
