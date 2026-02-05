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

namespace CichyStrzalko.AnimeKatalog.Web.Controllers
{
    public class StudiosController : Controller
    {
        private readonly CichyStrzalkoAnimeKatalogWebContext _context;
        private readonly BL.BL _BL;

        public StudiosController(BL.BL bL)
        {
            _BL = bL;
        }

        public Studio MapFromIStudio(IStudio studio)
        {
            return new Studio
            {
                Id = studio.Id,
                Name = studio.Name,
                Address = studio.Address
            };
        }

        // GET: Studios
        public async Task<IActionResult> Index(string searchString)
        {
            var studios = _BL.GetAllStudios().Select(s => MapFromIStudio(s));
            if (!string.IsNullOrEmpty(searchString))
            {
                studios = studios.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }
            return View(studios);
        }

        // GET: Studios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else if(id != null)
            {

            }
            var studio = MapFromIStudio(_BL.GetStudioByID(id));
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // GET: Studios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                var s = _BL.CreateStudio();
                s.Name = studio.Name;
                s.Address = studio.Address;
                s.Id = studio.Id;
                _BL.UpdateStudio(s);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studio);
        }

        // GET: Studios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = MapFromIStudio(_BL.GetStudioByID(id));
            if (studio == null)
            {
                return NotFound();
            }
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] Studio studio)
        {
            if (id != studio.Id)
            {
                return NotFound();
            }
            var edited = _BL.GetStudioByID(id);
            if (edited == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                edited.Name = studio.Name;
                edited.Address = studio.Address;
                _BL.UpdateStudio(edited);
                return RedirectToAction(nameof(Index));
                //    try
                //    {
                //        _context.Update(studio);
                //        await _context.SaveChangesAsync();
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        if (!StudioExists(studio.Id))
                //        {
                //            return NotFound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return RedirectToAction(nameof(Index));
            }
            return View(studio);
        }

        // GET: Studios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var studio = MapFromIStudio(_BL.GetStudioByID(id));
            if (studio == null)
            {
                return NotFound();
            }
            var animes = _BL.GetAllAnime().Where(a => a.StudioId == id);
            bool hasAnimes = animes.Any();
            ViewBag.HasAnimes = hasAnimes;
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var studio = await _context.Studio.FindAsync(id);
            //if (studio != null)
            //{
            //    _context.Studio.Remove(studio);
            //}

            //await _context.SaveChangesAsync();
            _BL.DeleteStudio(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudioExists(int id)
        {
            return _BL.GetAllStudios().Any(e => e.Id == id);
        }
    }
}
