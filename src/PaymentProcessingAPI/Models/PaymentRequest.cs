namespace PaymentProcessingAPI.Models
{
    public class PaymentRequest
    {
        public string PaymentMethod { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Description { get; set; } = default!;
        public string? SubscriptionPeriod { get; set; }
    }
}