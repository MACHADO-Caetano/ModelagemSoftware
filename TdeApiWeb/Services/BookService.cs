public class BookService : IBookService
{
    private readonly List<Book> _books = new();

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) =>
        _books.FirstOrDefault(l => l.Id == id);

    Book IBookService.add(Book book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);
        return book;
    }

    Book? IBookService.delete(int id)
    {
        var book = GetById(id);
        if (book is null) return null;
        _books.Remove(book);
        return book;
    }

    Book? IBookService.update(int id, Book book)
    {
        var updatedBook = GetById(id);
        if (updatedBook is null) return null;
        updatedBook.Title = book.Title;
        updatedBook.AuthorId = book.AuthorId;
        return updatedBook;
    }
}