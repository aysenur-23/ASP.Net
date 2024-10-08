using bookDemo.Controllers.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController] //kendinden sonra tanımlanan class'a davranış kazandırıyor
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id)) //dile entegre linq araması
                .SingleOrDefault();  //id varsa karşılık gelen değer yoksa default yani null

            if (book == null)
                return NotFound(); //404

            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); //400 gönderilen içerik istenen şekilde değil
                ApplicationContext.Books.Add(book);
                return StatusCode(201); //created
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]

        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            //check bu kitap var mı
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(); //404

            // check id
            if (id != book.Id)
                return BadRequest(); //400

            ApplicationContext.Books.Remove(book);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveOnebook([FromRoute(Name = "id")] int id)
        {
            var entity2 = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity2 is null)
                return NotFound(new
                {
                    message = $"Try another book, we can't have this one {id}"
                });

            ApplicationContext.Books.Remove(entity2);
            return NoContent();

        }

        [HttpPatch("{id:int}")]

        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = ApplicationContext.Books.Find( a => a.Id.Equals(id));
            if(entity is null)
                return NotFound();
            bookPatch.ApplyTo(entity);
            return NoContent();
        }

    }
}
