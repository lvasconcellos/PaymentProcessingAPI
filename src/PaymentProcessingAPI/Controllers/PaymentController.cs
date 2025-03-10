using Microsoft.AspNetCore.Mvc;
using PaymentProcessingAPI.Factories;
using PaymentProcessingAPI.Models;
using PaymentProcessingAPI.Processors;
using System;

namespace PaymentProcessingAPI.Controllers;


[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly IFactory<IPaymentProcessor> _paymentFactory;

    public PaymentController(IFactory<IPaymentProcessor> paymentFactory)
    {
        _paymentFactory = paymentFactory;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
    {
        try
        {
            var method = Enum.Parse<PaymentMethod>(request.PaymentMethod, true);
            var processor = _paymentFactory.Create(method.ToString());
            var result = await processor.ProcessPayment(request.Amount);

            return Ok(new { message = $"Payment Status: {result}" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
