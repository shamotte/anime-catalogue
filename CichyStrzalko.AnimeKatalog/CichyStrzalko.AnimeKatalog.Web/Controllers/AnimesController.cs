using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CichyStrzalko.AnimeKatalog.Web.Data;
using CichyStrzalko.AnimeKatalog.Web.Models;

using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.Core;
namespace CichyStrzalko.AnimeKatalog.Web.Controllers
{
    public class AnimesController : Controller
    {
        private readonly CichyStrzalkoAnimeKatalogWebContext _context;
        private readonly BL.BL _BL;

        public AnimesController(BL.BL bL)
        {
            _BL = bL;
        }
        private Anime MapFromIAnime(IAnime anime)
        {
            return new Anime
            {
                Id = anime.Id,
                Name = anime.Name,
                Premiere = anime.Premiere,
                ImageData = anime.ImageData,
                Genre = anime.Genre,
                Episodes = anime.Episodes
            };
        }

        private IAnime MapToIAnime(Anime anime)
        {
            return new Anime
            {
                Id = anime.Id,
                Name = anime.Name,
                Premiere = anime.Premiere,
                ImageData = anime.ImageData,
                Genre = anime.Genre,
                Episodes = anime.Episodes
            };
        }

        // GET: Animes
        public async Task<IActionResult> Index(string SearchString)
        {
            var animes = _BL.GetAllAnime().Select(a => MapFromIAnime(a));
            if(!string.IsNullOrEmpty(SearchString))
            {
                animes = animes.Where(a => a.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }
            return View(animes);
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IAnime anime = _BL.GetAnimeByID(id.Value);
            if (anime == null)
            {
                return NotFound();
            }

            return View(MapFromIAnime(anime));
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Premiere,ImageData,Genre,Episodes")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                _BL.UpdateAnime(anime);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime =MapFromIAnime(_BL.GetAnimeByID(id.Value));

            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Premiere,ImageData,Genre,Episodes")] Anime anime)
        {
            if (id != anime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _BL.UpdateAnime(anime);
                //try
                //{
                //    //await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!AnimeExists(anime.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = MapFromIAnime(_BL.GetAnimeByID(id.Value));
            if (anime == null)
            {
                return NotFound();
            }
            ViewBag.HasCharacters = _BL.GetAllCharacters().Any(c => c.AnimeId == id.Value);
            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var anime = await _context.Anime.FindAsync(id);
            //if (anime != null)
            //{
            //    _context.Anime.Remove(anime);
            //}

            //await _context.SaveChangesAsync();
            _BL.DeleteAnime(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return _BL.GetAllAnime().Any(e => e.Id == id);
        }
    }
}
