/*
 The strategy pattern defines a famuly of algotithms,
encapsulates each one, and makes them interchangeable. 

This lets the alogorithm vary independently from the clients that use it.
 */

Payer payer = new() { PaymentStrategy = new CreditCardPayment()};
payer.MakePayment(100);

// flexible change of payment strategy
payer.PaymentStrategy = new PaypalPayment();
payer.MakePayment(101);


// Design Principle - Encapsulate What Varies
// Once you separate the parts that are changing, you can then modify those parts without affecting the rest of the code.
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Credit card payment of {amount}");
    }
}


public class PaypalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paypal payment of {amount}");
    }
}


public class Payer
{
    public required IPaymentStrategy PaymentStrategy { get; set; }              // HAS-A Relationship - COMPOSITION

    public void MakePayment(decimal amount)
    {
        PaymentStrategy.Pay(amount);
    }
}
