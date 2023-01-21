using SRP.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class BookStore : IBookStore
    {
        private static int _lastId = 0;

        private static List<Book> _books;
        private static int NextId => ++_lastId;
        public IEnumerable<Book> Books => new ReadOnlyCollection<Book>(_books);

        static BookStore()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = NextId,
                    Title = "Some cool computer book"
                }
            };
        }

        public void Create(Book book)
        {
            if (book.Id != default)
                throw new Exception("A new book can not be created with an id");
            book.Id = NextId;
            _books.Add(book);
        }

        public void Replace(Book book)
        {
            if (!_books.Any(x => x.Id == book.Id))
            {
                throw new Exception($"Book {book.Id} does not exist!");
            }
            var index = _books.FindIndex(x => x.Id == book.Id);
            _books[index] = book;
        }

        public Book? Find(int aBookId)
        {
            var book = _books.FirstOrDefault(x => x.Id == aBookId);
            if(book == null)
                throw new Exception($"Book {aBookId} does not exist!");
            return book;
        }


        public void Remove(Book book)
        {
            if (_books.Any(x => x.Id == book.Id))
            {
                throw new Exception($"Book {book.Id} does not exist!");
            }
            var index = _books.FindIndex(x => x.Id == book.Id);
            _books.RemoveAt(index);
        }
    }
}
