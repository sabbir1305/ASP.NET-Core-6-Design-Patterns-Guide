using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Contracts
{
    public interface IBookWriter
    {
        void Create(Book book);
        void Replace(Book book);
        void Remove(Book book);
    }
}
