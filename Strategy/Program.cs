using Strategy;
using Strategy.ShoppingCart;
using System.Text;

namespace Strategy;
public class Program
{
private static readonly SortableCollection _data = new
SortableCollection(new[] { "Lorem", "ipsum", "dolor", "sit", "amet." });

    public static void Main(string[] args) {
        //string input = default;
        //do
        //{
        //    Console.Clear();
        //    Console.WriteLine("Options:");
        //    Console.WriteLine("1: Display the items");
        //    Console.WriteLine("2: Sort the collection");
        //    Console.WriteLine("3: Select the sort ascending strategy");
        //    Console.WriteLine("4: Select the sort descending strategy");
        //    Console.WriteLine("0: Exit");
        //    Console.WriteLine("--------------------------------------");
        //    Console.WriteLine("Please make a selection: ");
        //    input = Console.ReadLine();
        //    Console.Clear();

        //    var output = input switch
        //    {
        //        "1" => PrintCollection(),
        //        "2" => SortData(),
        //        "3" => SetSortAsc(),
        //        "4" => SetSortDesc(),
        //        "0" => "Shutting down........",
        //        _ => "Invalid"
        //    };
        //    Console.WriteLine(output);
        //    Console.WriteLine("Press **enter** to continue.");
        //    Console.ReadLine();

        //} while (input != "0");


        IShoppingCartCheckOut cart = ShoppingCartFactory.CreateShoppingCart(new StandardShippingStrategy());
        cart.OrderTotal = 100;

        // Calculate the shipping cost with the current strategy
        var shippingCost = cart.CalculateShippingCost();
        Console.WriteLine($"Shipping cost: {shippingCost}");

        // Change the shipping strategy to expedited
        cart.SetShippingStrategy(new FastShippingStrategy());

        // Calculate the new shipping cost with the new strategy
        shippingCost = cart.CalculateShippingCost();
        Console.WriteLine($"New shipping cost: {shippingCost}");

    }

    private static string SetSortAsc()
    {
        _data.SortStrategy = new SortAscendingStrategy();
        return "The sort strategy is now Descending!";
    }
    private static string SetSortDesc()
    {
        _data.SortStrategy = new SortDescendingStrategy();
        return "The sort strategy is now Descending!";
    }

    private static string SortData()
    {
        try
        {
            _data.Sort();
            return "Data sorted!";
        }
        catch (NullReferenceException ex)
        {
            return ex.Message;
        }
    }

    private static string PrintCollection()
    {
        var sb = new StringBuilder();
        foreach (var item in _data.Items)
        {
            sb.AppendLine(item);
        }
        return sb.ToString();
    }
}

