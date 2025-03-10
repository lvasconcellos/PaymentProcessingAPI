using PaymentProcessingAPI.Models;
using PaymentProcessingAPI.Services;

namespace PaymentProcessingAPI.Processors;
public class CreditCardPayment : IPaymentProcessor
{
    private readonly IPaymentService _paymentService;

    public CreditCardPayment(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task<string> ProcessPayment(decimal amount)
    {
        Console.WriteLine("Requesting authorization from Credit Card company...");
        await Task.Delay(500);  // Simulated fast authorization
        Console.WriteLine("Authorization granted.");

        return await _paymentService.ProcessPayment(PaymentMethod.CreditCard, amount, "Credit Card Purchase", null);
    }
}
