using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesoma.Data;
using thesoma.Models;

namespace thesoma.Controllers
{
    public class ParentOrGuardiansController : Controller
    {
        private readonly thesomaContext _context;

        public ParentOrGuardiansController(thesomaContext context)
        {
            _context = context;
        }

        // GET: ParentOrGuardians
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParentsOrGuardians.ToListAsync());
        }

        // GET: ParentOrGuardians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentOrGuardian = await _context.ParentsOrGuardians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parentOrGuardian == null)
            {
                return NotFound();
            }

            return View(parentOrGuardian);
        }

        // GET: ParentOrGuardians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParentOrGuardians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Relationship,Sex,Occupation,Address,PhoneNumber,Email")] ParentOrGuardian parentOrGuardian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentOrGuardian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parentOrGuardian);
        }

        // GET: ParentOrGuardians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentOrGuardian = await _context.ParentsOrGuardians.FindAsync(id);
            if (parentOrGuardian == null)
            {
                return NotFound();
            }
            return View(parentOrGuardian);
        }

        // POST: ParentOrGuardians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Relationship,Sex,Occupation,Address,PhoneNumber,Email")] ParentOrGuardian parentOrGuardian)
        {
            if (id != parentOrGuardian.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentOrGuardian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentOrGuardianExists(parentOrGuardian.Id))
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
            return View(parentOrGuardian);
        }

        // GET: ParentOrGuardians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentOrGuardian = await _context.ParentsOrGuardians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parentOrGuardian == null)
            {
                return NotFound();
            }

            return View(parentOrGuardian);
        }

        // POST: ParentOrGuardians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentOrGuardian = await _context.ParentsOrGuardians.FindAsync(id);
            if (parentOrGuardian != null)
            {
                _context.ParentsOrGuardians.Remove(parentOrGuardian);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentOrGuardianExists(int id)
        {
            return _context.ParentsOrGuardians.Any(e => e.Id == id);
        }
    }
}
