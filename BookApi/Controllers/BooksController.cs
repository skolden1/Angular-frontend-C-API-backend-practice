using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BookApi.Controllers
{
    //Routen blir ju då: https://localhost:7042/api/Books
    [Route("api/[Controller]")] 
    [ApiController]
    public class BooksController : ControllerBase
    {
        private Book[] _books = new Book[]
        {
            new Book {Id = 1, Author = "Author1", Title = "Book1"},
            new Book {Id = 2, Author = "Author2", Title = "Book2"},
            new Book {Id = 3, Author = "Author3", Title = "Book3" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_books); //ok menas status kod 200 (att det fungerade)
        }
    }
}
