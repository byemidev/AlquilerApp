using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlquilerApp.Models;
using BibliotecaAppWeb.Models;

namespace AlquilerApp.Controllers
{
    public class CarsDescriptionsController : Controller
    {
        private readonly Contexto _context;

        public CarsDescriptionsController(Contexto context)
        {
            _context = context;
        }

        // GET: CarsDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.myCars.ToListAsync());
        }

        // GET: CarsDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsDescription = await _context.myCars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carsDescription == null)
            {
                return NotFound();
            }

            return View(carsDescription);
        }

        // GET: CarsDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarsDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] CarsDescription carsDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carsDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carsDescription);
        }

        private bool CarsDescriptionExists(int id)
        {
            return _context.myCars.Any(e => e.Id == id);
        }
    }
}
