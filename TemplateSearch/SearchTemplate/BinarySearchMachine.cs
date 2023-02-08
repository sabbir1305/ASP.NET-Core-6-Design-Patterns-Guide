﻿namespace TemplateSearch.SearchTemplate
{
    public class BinarySearchMachine : SearchMachine
    {
        public BinarySearchMachine(params int[] values): 
            base(values.OrderBy(v => v).ToArray()) { }

        protected override int? Find(int value)
        {
            var index = Array.BinarySearch(Values, value);
            return index == -1 ? null : index;
        }
    }
}
