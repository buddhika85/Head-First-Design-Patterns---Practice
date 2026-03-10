
Payer payer = new() { PaymentStrategy = PaymentStrategies.CreditCardStrategy };
payer.MakePayment(100);

// flexible change of payment strategy
payer.PaymentStrategy = PaymentStrategies.PayPalStrategy;
payer.MakePayment(101);


public static class PaymentStrategies
{
    public static Action<decimal> CreditCardStrategy = (amount) => Console.WriteLine($"Credit card payment of {amount}");
    public static Action<decimal> PayPalStrategy = (amount) => Console.WriteLine($"Paypal payment of {amount}");
}


public class Payer
{
    public required Action<decimal> PaymentStrategy { get; set; }              // HAS-A Relationship - COMPOSITION

    public void MakePayment(decimal amount)
    {
        PaymentStrategy(amount);
    }
}