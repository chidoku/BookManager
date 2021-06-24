using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Details(int id)
        {
            using (BookManagerContext context = new BookManagerContext())
            {
                return View(context.Books.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            List<Book> listBook = context.Books.ToList();
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();

                return RedirectToAction("listbook");
            }
            else
            {
                return View(book);
            }
        }
        public ActionResult Edit(int id)
        {
            using (BookManagerContext context = new BookManagerContext())
            {
                return View(context.Books.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id,Book book)
        {
            try
            {
                using (BookManagerContext context = new BookManagerContext())
                {
                    context.Entry(book).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            using (BookManagerContext context = new BookManagerContext())
            {
                return View(context.Books.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id,Book book)
        {
            using (BookManagerContext context = new BookManagerContext()) {
                Book dbDelete = context.Books.FirstOrDefault(p => p.ID == id);
                if (dbDelete != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
               
        }

    }
   
}