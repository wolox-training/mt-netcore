using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models.Database;
using MvcMovie.Repositories;
using MvcMovie.Models.Views;

namespace MvcMovie.Controllers
{
    public class CommentsController : Controller
    {
        private readonly DbContextOptions<DataBaseContext> _options;
        private readonly CommentRepository _commentRepository;

        public CommentsController(DbContextOptions<DataBaseContext> options)
        {
            this._options = options;
            this._commentRepository = new CommentRepository(_options);
        }
      
        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int MovieID, string Text)
        {
            if (ModelState.IsValid)
            {
                using(var context = Context)
                {
                    Comment Comment = new Comment();
                    Comment.Text = Text;
                    Comment.Movie = context.Set<Movie>().Find(MovieID);
                    context.Set<Comment>().Add(Comment);
                    context.SaveChanges();
                }
                return RedirectToAction("Details", "Movies", new {@id=MovieID});
            }
            return View();
        }
        
        public CommentRepository commentRepository
        {
            get {return _commentRepository;}
        }

        public DbContextOptions<DataBaseContext> Options
        {
            get {return _options;}
        }

        public DataBaseContext Context
        {
            get {return new DataBaseContext(Options);}
        }
    }
}
