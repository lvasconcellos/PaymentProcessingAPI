using PaymentProcessingAPI.Models;

namespace PaymentProcessingAPI.Services;
public interface IPaymentService
{
    Task<string> ProcessPayment(PaymentMethod method, decimal amount, string description, SubscriptionPeriod? period);
}
