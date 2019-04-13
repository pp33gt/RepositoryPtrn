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
    public class Repo2ItemController : Controller
    {
        private readonly RepositoryPtrnContext _context;

        public Repo2ItemController(RepositoryPtrnContext context)
        {
            _context = context;
        }

        // GET: Repo2Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repo2Items.ToListAsync());
        }

        // GET: Repo2Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo2Item = await _context.Repo2Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repo2Item == null)
            {
                return NotFound();
            }

            return View(repo2Item);
        }

        // GET: Repo2Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repo2Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SomeName")] Repo2Item repo2Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repo2Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repo2Item);
        }

        // GET: Repo2Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo2Item = await _context.Repo2Items.FindAsync(id);
            if (repo2Item == null)
            {
                return NotFound();
            }
            return View(repo2Item);
        }

        // POST: Repo2Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SomeName")] Repo2Item repo2Item)
        {
            if (id != repo2Item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repo2Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Repo2ItemExists(repo2Item.Id))
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
            return View(repo2Item);
        }

        // GET: Repo2Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repo2Item = await _context.Repo2Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repo2Item == null)
            {
                return NotFound();
            }

            return View(repo2Item);
        }

        // POST: Repo2Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repo2Item = await _context.Repo2Items.FindAsync(id);
            _context.Repo2Items.Remove(repo2Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Repo2ItemExists(int id)
        {
            return _context.Repo2Items.Any(e => e.Id == id);
        }
    }
}
