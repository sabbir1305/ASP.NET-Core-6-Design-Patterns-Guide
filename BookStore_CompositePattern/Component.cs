using System.Text;

namespace BookStore_CompositePattern
{
    public interface IComponent
    {
        void Add(IComponent bookComponent);
        void Remove(IComponent bookComponent);
        string Display();
        int Count();
        string Type { get; }
    }
    public abstract class BookComposite : IComponent
    {
        public string Name { get; }
        protected readonly List<IComponent> children = new List<IComponent>();
        protected virtual string HeadingTagName { get; }


        public BookComposite(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public virtual string Type => GetType().Name;



        public void Add(IComponent bookComponent)
        {
            children.Add(bookComponent);
        }

        public int Count()
        {
            return children.Sum(child => child.Count());
        }

        public string Display()
        {
            var sb = new StringBuilder();
            sb.Append("<section class=\"card\">");
            AppendHeader(sb);
            AppendBody(sb);
            AppendFooter(sb);
            sb.Append("</section>");
            return sb.ToString();
        }

        private void AppendHeader(StringBuilder sb)
        {
            sb.Append($"<{HeadingTagName} class=\"card-header\">");
            sb.Append(Name);
            sb.Append($"<span class=\"badge badge-secondary float-right\">{Count()} books </span>");
            sb.Append($"</{HeadingTagName}>");
        }

        public void Remove(IComponent bookComponent)
        {
            children.Remove(bookComponent);
        }

        private void AppendBody(StringBuilder sb)
        {
            sb.Append($"<ul class=\"list-group list-group-flush\">");
            children.ForEach(child =>
            {
                sb.Append($"<li class=\"list-group-item\">");
                sb.Append(child.Display());
                sb.Append("</li>");
            });
            sb.Append("</ul>");
        }
        private void AppendFooter(StringBuilder sb)
        {
            sb.Append("<div class=\"card-footer text-muted\">");
            sb.Append($"<small class=\"text-muted text-right\">{Type}</small>");
            sb.Append("</div>");
        }
    }

    public class Book : IComponent
    {
        public Book(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
        public string Title { get; set; }
        public string Type => "Book";
        public int Count() => 1;
        public string Display() => $"{Title} <small class=\"text-muted\">({Type})</small>";
        public void Add(IComponent bookComponent) => throw new
        NotSupportedException();
        public void Remove(IComponent bookComponent) => throw new
        NotSupportedException();
    }
}
