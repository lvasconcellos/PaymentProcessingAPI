namespace PaymentProcessingAPI.Factories;

public interface IFactory<T>
{
    T Create(string type);
}
