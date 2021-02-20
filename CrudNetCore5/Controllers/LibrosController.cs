using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = _context.Libro;
            return View(listLibros);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se a creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obter libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se a actualizado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obter libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            //Obter o libro por Id
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["mensaje"] = "El libro se a eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
