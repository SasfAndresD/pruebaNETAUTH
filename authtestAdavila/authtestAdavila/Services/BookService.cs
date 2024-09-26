using authtestAdavila.Models;

namespace authtestAdavila.Services
{
    public class BookService
    {
        private List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "El Quijote", Author = "Miguel de Cervantes", Price = 19.99m },
        new Book { Id = 2, Title = "Cien años de soledad", Author = "Gabriel García Márquez", Price = 24.99m }
    };

        public IEnumerable<Book> GetAll() => _books;

        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        public void Update(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
                _books[index] = book;
        }

        public void Delete(int id)
        {
            _books.RemoveAll(b => b.Id == id);
        }
    }
}
