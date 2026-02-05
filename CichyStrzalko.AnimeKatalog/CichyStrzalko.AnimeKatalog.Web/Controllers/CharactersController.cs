using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CichyStrzalko.AnimeKatalog.Web.Data;
using CichyStrzalko.AnimeKatalog.Web.Models;

namespace CichyStrzalko.AnimeKatalog.Web.Controllers
{
    public class CharactersController : Controller
    {
        private readonly CichyStrzalkoAnimeKatalogWebContext _context;
        private readonly BL.BL _BL;
        public CharactersController(BL.BL bL)
        {
            _BL = bL;
        }

        private Character MapFromICharacter(Interfaces.ICharacter character)
        {
            return new Character
            {
                Id = character.Id,
                Name = character.Name,
                AnimeId = character.AnimeId,
                ImageData = character.ImageData
            };
        }

        private IEnumerable<SelectListItem> GetAllAnimesId()
        {
            return _BL.GetAllAnime().Select(
                a =>
                {
                    return new SelectListItem { Text = a.Name, Value = a.Id.ToString() };
                }
                );
        }

        // GET: Characters
        public async Task<IActionResult> Index(String SearchString)
        {
            var characters = _BL.GetAllCharacters().Select(c => MapFromICharacter(c));

            if (!String.IsNullOrEmpty(SearchString))
            {
                characters = characters.Where(c => c.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
                return View(characters);
            }
            return View(characters);
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = _BL.GetCharacterByID(id.Value);
            if (character == null)
            {
                return NotFound();
            }

            return View(MapFromICharacter(character));
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewBag.AnimeIds = GetAllAnimesId();
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AnimeId,ImageData")] Character character)
        {
            if (ModelState.IsValid)
            {
                var c = _BL.CreateCharacter();
                c.Id = character.Id;
                c.Name = character.Name;
                c.AnimeId = character.Id;
                c.ImageData = character.ImageData;
                _BL.UpdateCharacter(c);
                //_context.Add(character);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = MapFromICharacter( _BL.GetCharacterByID(id.Value));
            if (character == null)
            {
                return NotFound();
            }
            ViewBag.AnimeIds = GetAllAnimesId();
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AnimeId,ImageData")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                //try
                //{
                //    _context.Update(character);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CharacterExists(character.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                var c = _BL.GetCharacterByID(id);
                c.Id = character.Id;
                c.Name = character.Name;
                c.AnimeId = character.AnimeId;
                c.ImageData = character.ImageData;
                _BL.UpdateCharacter(c);
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = MapFromICharacter(_BL.GetCharacterByID(id.Value)) ;
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = MapFromICharacter(_BL.GetCharacterByID(id));
            if (character != null)
            {
                _BL.DeleteCharacter(id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _BL.GetAllCharacters().Any(e => e.Id == id);
        }
    }
}
