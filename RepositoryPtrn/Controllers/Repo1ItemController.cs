using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryPtrn.Models;

namespace RepositoryPtrn.Controllers
{
    public class Repo1ItemController : Controller
    {
        private readonly RepositoryPtrnContext _context;

        public Repo1ItemController(RepositoryPtrnContext context)
        {
            _context = context;
        }

        // GET: Repo1Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repo1Items.ToListAsync());
        }

        // GET: Repo1Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo1Item = await _context.Repo1Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repo1Item == null)
            {
                return NotFound();
            }

            return View(repo1Item);
        }

        // GET: Repo1Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repo1Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SomeNumber")] Repo1Item repo1Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repo1Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repo1Item);
        }

        // GET: Repo1Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo1Item = await _context.Repo1Items.FindAsync(id);
            if (repo1Item == null)
            {
                return NotFound();
            }
            return View(repo1Item);
        }

        // POST: Repo1Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SomeNumber")] Repo1Item repo1Item)
        {
            if (id != repo1Item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repo1Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Repo1ItemExists(repo1Item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(repo1Item);
        }

        // GET: Repo1Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo1Item = await _context.Repo1Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repo1Item == null)
            {
                return NotFound();
            }

            return View(repo1Item);
        }

        // POST: Repo1Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repo1Item = await _context.Repo1Items.FindAsync(id);
            _context.Repo1Items.Remove(repo1Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Repo1ItemExists(int id)
        {
            return _context.Repo1Items.Any(e => e.Id == id);
        }
    }
}
