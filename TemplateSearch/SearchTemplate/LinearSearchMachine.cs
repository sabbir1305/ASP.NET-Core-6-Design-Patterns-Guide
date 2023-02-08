namespace TemplateSearch.SearchTemplate
{
    public class LinearSearchMachine : SearchMachine
    {
        public LinearSearchMachine(params int[] values) : base(values)
        {

        }
        protected override int? Find(int value)
        {
            int index = 0;
            foreach (var item in Values)
            {
                if (item == value) return index;
                index++;
            }
            return null;
        }
    }
}
