using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class BookPresenter
    {
        public void Display(Book aBook)
        {
            Console.WriteLine($"Book: {aBook.Title} ({aBook.Id})");
        }
    }
}
