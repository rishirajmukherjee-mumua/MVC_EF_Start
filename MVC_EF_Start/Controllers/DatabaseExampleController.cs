using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> GetSpotifyData()
        {
            SpotifyDataAccess spotifyDataAccess = new SpotifyDataAccess("078c7392711e4b978d6a3bd21984c93c", "8b7f7c3b96454fcd8b42193a179ca19b");
            Token token = await spotifyDataAccess.GetToken();
            ViewData["token"] = token;
            Object objectData = await spotifyDataAccess.SearchArtistAndTrack(token.AccessToken, "Linkin");
            return View();
        }

    }
}