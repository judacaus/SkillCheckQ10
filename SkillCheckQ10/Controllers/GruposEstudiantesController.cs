    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkillCheckQ10.Data;
using SkillCheckQ10.Models;

namespace SkillCheckQ10.Controllers
{
    public class GruposEstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GruposEstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GruposEstudiantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GrupoEstudiante.Include(g => g.Docente).Include(g => g.Estudiante).Include(g => g.Materia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GruposEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEstudiante = await _context.GrupoEstudiante
                .Include(g => g.Docente)
                .Include(g => g.Estudiante)
                .Include(g => g.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoEstudiante == null)
            {
                return NotFound();
            }

            return View(grupoEstudiante);
        }

        // GET: GruposEstudiantes/Create
        public IActionResult Create()
        { 

            ViewData["DocenteId"] = new SelectList(
                _context.Docente.Select(m => new
                {
                    m.Id,
                    NombreCompleto = m.Nombre + " " + m.Apellido
                }),
                "Id",
                "NombreCompleto"
            );
            ViewData["EstudianteId"] = new SelectList(
                _context.Estudiante
                    .Where(e =>
                        e.Creditos > (
                            from g in _context.GrupoEstudiante
                            where g.EstudianteId == e.Id
                            select g.Materia.Creditos
                        ).Sum()
                    )
                    .Select(e => new {
                        e.Id,
                        NombreCompleto = e.Nombre + " " + e.Apellido + " (" + (e.Creditos - (
                            from g in _context.GrupoEstudiante
                            where g.EstudianteId == e.Id
                            select g.Materia.Creditos
                        ).Sum()) + " Creditos Disponibles)"
                    }),
                "Id",
                "NombreCompleto"
            );
            ViewData["MateriaId"] = new SelectList(
                _context.Materia.Select(m => new
                {
                    m.Id,
                    NombreCompleto = m.Nombre + " (" + m.Creditos + " Creditos)"
                }),
                "Id",
                "NombreCompleto"
            );
            return View();
        }

        // POST: GruposEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MateriaId,DocenteId,EstudianteId")] GrupoEstudiante grupoEstudiante)
        {
                
            int matriculaExiste = _context.GrupoEstudiante.Where(m => m.EstudianteId.Equals(grupoEstudiante.EstudianteId) && m.MateriaId.Equals(grupoEstudiante.MateriaId) ).Count();

            if (!matriculaExiste.Equals(0))
            {
                ModelState.AddModelError("", "Ya tiene matriculada esta materia");
            }
            else
            {


                grupoEstudiante.Estudiante = _context.Estudiante.Where(e => e.Id.Equals(grupoEstudiante.EstudianteId)).First();
                grupoEstudiante.Materia = _context.Materia.Where(e => e.Id.Equals(grupoEstudiante.MateriaId)).First();


                int creditosOcupados = _context.GrupoEstudiante
                    .Where(g => g.EstudianteId == grupoEstudiante.EstudianteId)
                    .Select(g => g.Materia.Creditos as int?)
                    .Sum() ?? 0;

                int creditosDisponibles = grupoEstudiante.Estudiante.Creditos - creditosOcupados;

                if (grupoEstudiante.Materia.Creditos.Equals(4))
                {
                    int materias4Creditos = _context.GrupoEstudiante.Where(g => g.EstudianteId == grupoEstudiante.EstudianteId && g.Materia.Creditos == 4).Count();
                    if (materias4Creditos == 3)
                    {
                        ModelState.AddModelError("", "No puede agregar mas materias de 4 creditos");
                    }
                }

                if (grupoEstudiante.Materia.Creditos > creditosDisponibles)
                {
                    ModelState.AddModelError("", "No alcanzan los creditos para esta materia");
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(grupoEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DocenteId"] = new SelectList(
                _context.Docente.Select(m => new {
                    m.Id,
                    NombreCompleto = m.Nombre + " " + m.Apellido
                }),
                "Id",
                "NombreCompleto",
                grupoEstudiante.DocenteId
            );

            ViewData["EstudianteId"] = new SelectList(
                _context.Estudiante
                    .Where(e =>
                        e.Creditos > (
                            from g in _context.GrupoEstudiante
                            where g.EstudianteId == e.Id
                            select g.Materia.Creditos
                        ).Sum()
                    )
                    .Select(e => new {
                        e.Id,
                        NombreCompleto = e.Nombre + " " + e.Apellido + " (" + (e.Creditos - (
                            from g in _context.GrupoEstudiante
                            where g.EstudianteId == e.Id
                            select g.Materia.Creditos
                        ).Sum()) + " Creditos Disponibles)"
                    }),
                "Id",
                "NombreCompleto",
                grupoEstudiante.EstudianteId
            );

            ViewData["MateriaId"] = new SelectList(
                _context.Materia.Select(m => new
                {
                    m.Id,
                    NombreCompleto = m.Nombre + " (" + m.Creditos + " Creditos)"
                }),
                "Id",
                "NombreCompleto",
                grupoEstudiante.MateriaId
             );
            
            return View(grupoEstudiante);
        }

        // GET: GruposEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEstudiante = await _context.GrupoEstudiante.FindAsync(id);
            if (grupoEstudiante == null)
            {
                return NotFound();
            }
            ViewData["DocenteId"] = new SelectList(_context.Docente, "Id", "Apellido", grupoEstudiante.DocenteId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Apellido", grupoEstudiante.EstudianteId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", grupoEstudiante.MateriaId);
            return View(grupoEstudiante);
        }

        // POST: GruposEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MateriaId,DocenteId,EstudianteId")] GrupoEstudiante grupoEstudiante)
        {
            if (id != grupoEstudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoEstudianteExists(grupoEstudiante.Id))
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
            ViewData["DocenteId"] = new SelectList(_context.Docente, "Id", "Apellido", grupoEstudiante.DocenteId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "Id", "Apellido", grupoEstudiante.EstudianteId);
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nombre", grupoEstudiante.MateriaId);
            return View(grupoEstudiante);
        }

        // GET: GruposEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEstudiante = await _context.GrupoEstudiante
                .Include(g => g.Docente)
                .Include(g => g.Estudiante)
                .Include(g => g.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoEstudiante == null)
            {
                return NotFound();
            }

            return View(grupoEstudiante);
        }

        // POST: GruposEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoEstudiante = await _context.GrupoEstudiante.FindAsync(id);
            if (grupoEstudiante != null)
            {
                _context.GrupoEstudiante.Remove(grupoEstudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoEstudianteExists(int id)
        {
            return _context.GrupoEstudiante.Any(e => e.Id == id);
        }
    }
}
