using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DataBaseContext _context;

        public MoviesController(DataBaseContext context)
        {
            _context = context;
        }
        
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }
    }
}