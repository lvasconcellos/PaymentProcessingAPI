using PaymentProcessingAPI.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PaymentProcessingAPI.Processors;
using PaymentProcessingAPI.Services;

namespace PaymentProcessingAPI.Factories;

public class PaymentProcessorFactory : IFactory<IPaymentProcessor>
{
    private readonly Dictionary<PaymentMethod, IPaymentProcessor> _registeredProcessors;

    public PaymentProcessorFactory(IPaymentService paymentService)
    {
        _registeredProcessors = new Dictionary<PaymentMethod, IPaymentProcessor>
        {
            { PaymentMethod.CreditCard, new CreditCardPayment(paymentService) },
            { PaymentMethod.PayPal, new PayPalPayment(paymentService) },
            { PaymentMethod.BankTransfer, new BankTransferPayment(paymentService) }
        };
    }

    public IPaymentProcessor Create(string method)
    {
        if (Enum.TryParse<PaymentMethod>(method, out var paymentMethod))
        {
            return CreateProcessor(paymentMethod);
        }

        throw new ArgumentException($"Payment method '{method}' is not supported.");
    }

    private IPaymentProcessor CreateProcessor(PaymentMethod paymentMethod)
    {
        if (_registeredProcessors.TryGetValue(paymentMethod, out var processor))
        {
            return processor;
        }

        throw new ArgumentException($"Payment method '{paymentMethod}' is not supported.");
    }
}