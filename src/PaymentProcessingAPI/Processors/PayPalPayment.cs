using PaymentProcessingAPI.Models;
using PaymentProcessingAPI.Services;

namespace PaymentProcessingAPI.Processors;
public class PayPalPayment : IPaymentProcessor
{
    private readonly IPaymentService _paymentService;

    public PayPalPayment(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task<string> ProcessPayment(decimal amount)
    {
        Console.WriteLine("Requesting authorization from PayPal...");
        await Task.Delay(1000);
        Console.WriteLine("PayPal approved, requesting Credit Card authorization...");
        await Task.Delay(1000);
        Console.WriteLine("Authorization granted.");

        return await _paymentService.ProcessPayment(PaymentMethod.PayPal, amount, "PayPal Purchase", null);
    }
}
