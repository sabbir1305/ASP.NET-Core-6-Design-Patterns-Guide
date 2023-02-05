namespace DecoratorPattern
{
    public interface IComponent
    {
        string Operation();
    }

    public class ComponentA : IComponent
    {
        public string Operation()
        {
            return "Hello from ComponentA";
        }
    }

}
