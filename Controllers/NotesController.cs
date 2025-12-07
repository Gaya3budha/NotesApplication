using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Context;
using NotesApplication.Models;

namespace NotesApplication.Controllers
{
    public class NotesController : Controller
    {
        private readonly NotesContext _context;

        public NotesController(NotesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var notes = await _context.Notes.ToListAsync();

            return View(notes.OrderByDescending(x => x.lastModifiedDate).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Notes _note = new Notes();
            return View(_note);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notes Ndata)
        {
            if (!ModelState.IsValid)
            {
                return View(Ndata);
            }
            _context.Notes.Add(Ndata);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int NotesId)
        {
            var _note = await _context.Notes.FindAsync(NotesId);
            if (_note != null)
                return View("Create",_note);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Notes Ndata)
        {
            if (!ModelState.IsValid)
            {
                return View(Ndata);
            }

             _context.Notes.Update(Ndata);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int NotesId)
        {
            if (NotesId != 0)
            {
                var _note = await _context.Notes.FindAsync(NotesId);
                if (_note != null)
                    return View("Create", _note);
                else return NotFound();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostDelete(int NotesId)
        {

            var _note = await _context.Notes.FindAsync(NotesId);

            if (_note == null) return NotFound();

            _context.Notes.Remove(_note);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
