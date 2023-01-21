using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Contracts
{
    public interface IBookReader
    {
        IEnumerable<Book> Books { get; }
        Book? Find(int bookId);
    }
}
