
using Microsoft.EntityFrameworkCore;
using PaymentProcessingAPI.Models;

namespace PaymentProcessingAPI.Data;
public class PaymentDbContext : DbContext
{
    public DbSet<PaymentTransaction> Transactions { get; set; }

    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }
}