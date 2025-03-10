using PaymentProcessingAPI.Models;
using PaymentProcessingAPI.Services;

namespace PaymentProcessingAPI.Processors;
public class BankTransferPayment : IPaymentProcessor
{
    private readonly IPaymentService _paymentService;

    public BankTransferPayment(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task<string> ProcessPayment(decimal amount)
    {
        Console.WriteLine("Requesting bank transfer...");
        await Task.Delay(3000);
        Console.WriteLine("Waiting for bank confirmation...");
        await Task.Delay(2000);
        Console.WriteLine("Bank confirmed transaction.");

        return await _paymentService.ProcessPayment(PaymentMethod.BankTransfer, amount, "Bank Transfer", null);
    }
}
