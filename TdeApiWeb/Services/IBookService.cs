public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book add(Book book);

    Book? delete(int id);

    Book? update(int id, Book book);
}