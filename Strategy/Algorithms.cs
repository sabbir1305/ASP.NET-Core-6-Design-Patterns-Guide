using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class SortAscendingStrategy : ISortStrategy
    {
        public IOrderedEnumerable<string> Sort(IEnumerable<string> items)
        {
            return items.OrderBy(x => x);
        }
    }

    public class SortDescendingStrategy : ISortStrategy
    {
        public IOrderedEnumerable<string> Sort(IEnumerable<string> items)
        {
            return items.OrderByDescending(x => x);
        }
    }

    public sealed class SortableCollection
    {
        public ISortStrategy? SortStrategy { get; set; }
        public IEnumerable<string> Items { get; private set; }

        public SortableCollection(IEnumerable<string> items)
        {
            Items = items;
        }

        public void Sort()
        {
            if (SortStrategy == null)
            {
                throw new NullReferenceException("Sort strategy not found.");
            }
            Items = SortStrategy.Sort(Items);
        }

    }
}
