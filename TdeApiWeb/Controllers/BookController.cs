using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get() =>
        Ok(_bookService.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = _bookService.GetById(id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> Post(Book book)
    {
        var newBook = _bookService.add(book);
        return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var book = _bookService.GetById(id);
        if (book is null) return NotFound();
        _bookService.delete(id);
        return NoContent();
    }
}