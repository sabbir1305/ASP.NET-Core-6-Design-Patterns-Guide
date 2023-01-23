using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public interface ISortStrategy
    {
        IOrderedEnumerable<string> Sort(IEnumerable<string> items);
    }
}
