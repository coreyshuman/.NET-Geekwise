using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.TodoList;


namespace MvcMovie.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Todo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TodoItem.ToListAsync());
        }

        // GET: Todo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem.SingleOrDefaultAsync(m => m.ID == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: Todo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Create([Bind("Content")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoItem);
                await _context.SaveChangesAsync();
                return "ok";
            }
            return "Error occured";
        }

        // GET: Todo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem.SingleOrDefaultAsync(m => m.ID == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return View(todoItem);
        }

        // POST: Todo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,completed,content")] TodoItem todoItem)
        {
            if (id != todoItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItem.SingleOrDefaultAsync(m => m.ID == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteConfirmed(int id)
        {
            var todoItem = await _context.TodoItem.SingleOrDefaultAsync(m => m.ID == id);
            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();
            return "ok";
        }

        // POST: Todo/MarkComplete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> MarkComplete(int id)
        {
            var todoItem = await _context.TodoItem.SingleOrDefaultAsync(m => m.ID == id);
            if(todoItem == null)
            {
                return "failed";
            }
            todoItem.Completed = true;
            _context.TodoItem.Update(todoItem);
            await _context.SaveChangesAsync();
            return "ok";
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItem.Any(e => e.ID == id);
        }
    }
}
