using System;

namespace PaymentProcessingAPI.Models;
public class PaymentTransaction
{
    public int Id { get; set; }
    public PaymentMethod Method { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = default!;
    public SubscriptionPeriod? Period { get; set; }
    public DateTime Timestamp { get; set; }
    public string Status { get; set; } = default!;
}
