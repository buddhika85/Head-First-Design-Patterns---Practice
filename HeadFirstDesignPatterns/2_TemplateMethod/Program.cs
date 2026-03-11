
Payer payer = new() { PaymentStrategy = new CreditCardPayment() };
payer.MakePayment(100);

Console.WriteLine("\n");

// flexible change of payment strategy
payer.PaymentStrategy = new PaypalPayment();
payer.MakePayment(101);


/*The Template Method pattern defines the skeleton of an algorithm in a base class, 
 * while allowing subclasses to override specific steps.
*/
public abstract class PaymentStrategy       // base class
{
    // Template Method (non‑virtual)
    public void Pay(decimal amount)
    {
        Validate(amount);
        Execute(amount);
        SendReceipt(amount);
    }

    // Steps that subclasses can override
    protected abstract void Validate(decimal amount);
    protected abstract void Execute(decimal amount);

    // Optional hook
    protected void SendReceipt(decimal amount)
    {
        Console.WriteLine($"Receipt sent for payment of {amount}");
    }
}

// sub class 1: implementing steps
public class CreditCardPayment : PaymentStrategy
{
    protected override void Execute(decimal amount)
    {
        Console.WriteLine($"Execute credit card payment: {amount}");
    }

    protected override void Validate(decimal amount)
    {
        Console.WriteLine($"Validate credit card payment: {amount}");
    }
}

// sub class 2: implementing steps
public class PaypalPayment : PaymentStrategy
{
    protected override void Execute(decimal amount)
    {
        Console.WriteLine($"Execute paypal payment: {amount}");
    }

    protected override void Validate(decimal amount)
    {
        Console.WriteLine($"Validate paypal payment: {amount}");
    }
}


public class Payer
{
    public required PaymentStrategy PaymentStrategy { get; set; }              // HAS-A Relationship - COMPOSITION

    public void MakePayment(decimal amount)
    {
        PaymentStrategy.Pay(amount);
    }
}
