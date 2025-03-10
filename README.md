# Payment Processing API (Factory Pattern)

## 📌 Overview
This project is a **real-world, portfolio-worthy** implementation of a **Payment Processing API** built with **.NET 9**. It uses the **Factory Pattern** to dynamically create different payment processors, handling:
- **One-time purchases & subscriptions** (1 month, 6 months, 1 year)
- **Asynchronous payment processing simulation**
- **Logging transactions in a database (SQLite)**
- **SOLID, DRY, and Clean Architecture**

## 🚀 Features
✅ Supports **Credit Card, PayPal, and Bank Transfer** payments
✅ **Subscription Handling** (1 month, 6 months, 1 year)
✅ **Asynchronous Payment Processing**
✅ **Database-Logged Transactions (SQLite)**
✅ **Swagger API Documentation**
✅ **Fully Testable Factory Implementation**

## 🛠️ Technologies Used
- **.NET 9 Web API**
- **Entity Framework Core (SQLite)**
- **Factory Pattern for Payment Processing**
- **Dependency Injection (DI)**
- **Swagger for API Documentation**

---
## 📂 Project Structure
```
/PaymentProcessingAPI
│── /Controllers
│    ├── PaymentController.cs
│── /Factories
│    ├── IFactory.cs
│    ├── PaymentProcessorFactory.cs
│── /Payments
│    ├── IPaymentProcessor.cs
│    ├── CreditCardPayment.cs
│    ├── PayPalPayment.cs
│    ├── BankTransferPayment.cs
│── /Services
│    ├── IPaymentService.cs
│    ├── PaymentService.cs
│    ├── PaymentDbContext.cs
│── /Models
│    ├── PaymentTransaction.cs
│    ├── PaymentRequest.cs
│    ├── SubscriptionPeriod.cs
│    ├── PaymentMethod.cs
│── Program.cs
│── appsettings.json
│── README.md
```

---
## 🚀 Getting Started
### 📌 Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- SQLite (installed automatically by Entity Framework Core)

### 📌 Installation & Setup
1. **Clone the repository**:
   ```sh
   git clone https://github.com/yourusername/PaymentProcessingAPI.git
   cd PaymentProcessingAPI
   ```
2. **Restore dependencies**:
   ```sh
   dotnet restore
   ```
3. **Apply database migrations**:
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
4. **Run the API**:
   ```sh
   dotnet run
   ```

---
## 📌 API Endpoints
### 🔹 Process a Payment (One-Time Purchase)
**Request:**
```http
POST /api/payments
Content-Type: application/json
```
```json
{
    "paymentMethod": "CreditCard",
    "amount": 49.99,
    "description": "Premium Feature Upgrade"
}
```

### 🔹 Process a Subscription Payment
**Request:**
```http
POST /api/payments
```
```json
{
    "paymentMethod": "PayPal",
    "amount": 99.99,
    "description": "6-Month Pro Subscription",
    "subscriptionPeriod": "SixMonths"
}
```

---
## 🛠️ Testing with Swagger
Swagger UI is enabled at:
```
http://localhost:5000/swagger/index.html
