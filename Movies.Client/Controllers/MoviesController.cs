using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Client.ApiServices;
using Movies.Client.Models;

namespace Movies.Client.Controllers
{
    public class MoviesController(IMovieApiService movieApiService) : Controller
    {
        private readonly IMovieApiService _movieApiService = movieApiService;

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _movieApiService.GetMovies());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            return View();
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Movie movie)
        {
            return View();
            //if (ModelState.IsValid)
            //{
            //    movie.ID = Guid.NewGuid();
            //    _context.Add(movie);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movie.FindAsync(id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}
            //return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Title,Genre,Rating,ReleaseDate,ImageUrl,Owner")] Movie movie)
        {
            return View();
            //if (id != movie.ID)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(movie);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MovieExists(movie.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movie
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            return View();
            //var movie = await _context.Movie.FindAsync(id);
            //if (movie != null)
            //{
            //    _context.Movie.Remove(movie);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return true;
            //return _context.Movie.Any(e => e.ID == id);
        }
    }
}
