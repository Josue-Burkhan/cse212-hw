/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        Console.WriteLine("Test 1: invalid size -> should use 10");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        Console.WriteLine("=================");

        Console.WriteLine("Test 2: add more than max");
        var cs2 = new CustomerService(2);
        cs2.FakeAdd("Alice", "A1", "Issue A");
        cs2.FakeAdd("Bob", "B2", "Issue B");
        cs2.FakeAdd("Charlie", "C3", "Issue C");
        Console.WriteLine(cs2);
        Console.WriteLine("=================");

        Console.WriteLine("Test 3: serve with empty queue");
        var cs3 = new CustomerService(1);
        cs3.ServeCustomer();
        Console.WriteLine("=================");

        Console.WriteLine("Test 4: AddNewCustomer manual test");
        var cs4 = new CustomerService(2);
        cs4.AddNewCustomer("Angelica", "D4", "Issue D");
        cs4.AddNewCustomer("Elly", "E5", "Issue E");
        cs4.AddNewCustomer("Freddy", "F6", "Issue F");
        cs4.ServeCustomer();
        Console.WriteLine(cs4);
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    public void AddNewCustomer(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    public void FakeAdd(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
