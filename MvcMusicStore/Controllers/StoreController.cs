using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        // GET: Store
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            //var genres = new List<Genre>
            //{
            //new Genre { Name = "Disco"},
            //new Genre { Name = "Jazz"},
            //new Genre { Name = "Rock"}
            //};
            return View(genres);
        }
        public ActionResult Browse(string genre)
        {
            //var genreModel = new Genre { Name = genre };
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            //var album = new Album { Title = "Album" + id };
            var album = storeDB.Albums.Find(id);
            return View(album);
        }
    }
}