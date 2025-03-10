namespace PaymentProcessingAPI.Processors;
public interface IPaymentProcessor
{
    Task<string> ProcessPayment(decimal amount);
}