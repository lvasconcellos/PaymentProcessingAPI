
using PaymentProcessingAPI.Data;
using PaymentProcessingAPI.Models;

namespace PaymentProcessingAPI.Services;

public class PaymentService : IPaymentService
{
    private readonly PaymentDbContext _dbContext;

    public PaymentService(PaymentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> ProcessPayment(PaymentMethod method, decimal amount, string description, SubscriptionPeriod? period)
    {
        var transaction = new PaymentTransaction
        {
            Method = method,
            Amount = amount,
            Description = description,
            Period = period,
            Timestamp = DateTime.UtcNow,
            Status = "Processing"
        };

        _dbContext.Transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();

        int delay = method switch
        {
            PaymentMethod.CreditCard => 500,  // Fast processing
            PaymentMethod.PayPal => 2000,     // Two-step authorization
            PaymentMethod.BankTransfer => 5000, // Slow processing (bank confirmation)
            _ => 1000
        };

        await Task.Delay(delay);

        transaction.Status = (new Random().Next(0, 10) > 2) ? "Completed" : "Failed";
        await _dbContext.SaveChangesAsync();

        return transaction.Status;
    }
}
