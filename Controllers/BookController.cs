using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestBaiThi1.Models;
using TestBaiThi1.DAL;
using System.Data.SqlClient;

namespace TestBaiThi1.Controllers
{
    public class BookController : Controller
    {
        private Book_DAL bookdal = new Book_DAL();
        private List<Book> book = new List<Book>();

        public ActionResult ListBook()
        {
            
            book = bookdal.ListBooks();
            return View(book);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book b)
        {
            bookdal.AddBook(b);
            return View("ListBook",bookdal.ListBooks());
        }

        [HttpGet]
        public ActionResult EditBook(int ID)
        {
            
            book = bookdal.ListBooks();
            Book b = new Book();
            for(int i = 0; i < book.Count; i++)
            {
                if(book[i].ID == ID)
                {
                    b = book[i];
                }
                
            }
            return View(b);
        }

        [HttpPost]
        public ActionResult EditBook(Book b)
        {
            bookdal.EditBook(b);
            return View("ListBook", bookdal.ListBooks());
        }

        public ActionResult DeleteBook(int ID)
        {
            bookdal.DeleteBook(ID);
            return View("ListBook", bookdal.ListBooks());
        }
    }
}