namespace CustomerMinimalAPI
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadAll();
        Customer? ReadOne(int id);
    }
}