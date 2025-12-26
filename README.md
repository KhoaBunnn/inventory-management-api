# Inventory Management API

A clean and minimal REST API for managing inventory, built with ASP.NET Core. This project demonstrates fundamental backend development practices suitable for student portfolios and entry-level positions.

## 📋 Project Overview

This API provides endpoints to manage products and categories in an inventory system. It follows RESTful principles and implements proper CRUD operations with Entity Framework Core and SQL Server.

## 🛠️ Tech Stack

- **Framework**: ASP.NET Core 7.0
- **ORM**: Entity Framework Core 7.0
- **Database**: SQL Server
- **API Documentation**: Swagger/OpenAPI
- **Language**: C# 11

## 📁 Project Structure

```
InventoryManagement.API/
├── Controllers/
│   ├── ProductsController.cs      # Product CRUD endpoints
│   └── CategoriesController.cs    # Category CRUD endpoints
├── Models/
│   ├── Product.cs                 # Product entity
│   └── Category.cs                # Category entity
├── Data/
│   └── InventoryDbContext.cs      # EF Core DbContext
├── database/
│   └── schema.sql                 # Database creation script
├── appsettings.json               # Configuration
└── Program.cs                     # Application entry point
```

## 🗄️ Database Schema

### Categories Table
| Column       | Type          | Constraints           |
|--------------|---------------|-----------------------|
| CategoryId   | INT           | PRIMARY KEY, IDENTITY |
| CategoryName | NVARCHAR(100) | NOT NULL              |

### Products Table
| Column      | Type           | Constraints                    |
|-------------|----------------|--------------------------------|
| ProductId   | INT            | PRIMARY KEY, IDENTITY          |
| ProductName | NVARCHAR(200)  | NOT NULL                       |
| Quantity    | INT            | NOT NULL, >= 0                 |
| Price       | DECIMAL(18,2)  | NOT NULL, > 0                  |
| CategoryId  | INT            | FOREIGN KEY → Categories       |

## 🚀 API Endpoints

### Categories

| Method | Endpoint              | Description              |
|--------|-----------------------|--------------------------|
| GET    | `/api/categories`     | Get all categories       |
| GET    | `/api/categories/{id}`| Get category by ID       |
| POST   | `/api/categories`     | Create new category      |
| PUT    | `/api/categories/{id}`| Update category          |
| DELETE | `/api/categories/{id}`| Delete category          |

### Products

| Method | Endpoint            | Description              |
|--------|---------------------|--------------------------|
| GET    | `/api/products`     | Get all products         |
| GET    | `/api/products/{id}`| Get product by ID        |
| POST   | `/api/products`     | Create new product       |
| PUT    | `/api/products/{id}`| Update product           |
| DELETE | `/api/products/{id}`| Delete product           |

## 📝 Sample Request/Response

### Create Product (POST `/api/products`)

**Request Body:**
```json
{
  "productName": "Wireless Mouse",
  "quantity": 25,
  "price": 29.99,
  "categoryId": 1
}
```

**Response (201 Created):**
```json
{
  "productId": 4,
  "productName": "Wireless Mouse",
  "quantity": 25,
  "price": 29.99,
  "categoryId": 1,
  "category": {
    "categoryId": 1,
    "categoryName": "Electronics"
  }
}
```

## 🔧 Setup Instructions

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (Express or Developer Edition)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/InventoryManagement.API.git
   cd InventoryManagement.API
   ```

2. **Update Connection String**
   
   Open `appsettings.json` and update the connection string if needed:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Database Setup (Option 1: Using EF Core Migrations)**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Database Setup (Option 2: Using SQL Script)**
   
   Run the SQL script in SQL Server Management Studio:
   ```bash
   database/schema.sql
   ```

5. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

6. **Run the Application**
   ```bash
   dotnet run
   ```

7. **Access Swagger UI**
   
   Open your browser and navigate to:
   ```
   https://localhost:7xxx/
   ```
   (The exact port will be shown in the console)

## 🧪 Testing the API

### Using Swagger UI
1. Run the application
2. Navigate to the Swagger UI (root URL)
3. Expand any endpoint and click "Try it out"
4. Fill in the request body and click "Execute"

### Using cURL

**Get all products:**
```bash
curl -X GET https://localhost:7xxx/api/products
```

**Create a category:**
```bash
curl -X POST https://localhost:7xxx/api/categories \
  -H "Content-Type: application/json" \
  -d '{"categoryName":"Furniture"}'
```

## 🎯 Key Features

- ✅ Clean RESTful API design
- ✅ Async/await pattern throughout
- ✅ Proper HTTP status codes (200, 201, 204, 400, 404)
- ✅ Input validation with Data Annotations
- ✅ Entity relationships (One-to-Many)
- ✅ Swagger/OpenAPI documentation
- ✅ Error handling and meaningful error messages
- ✅ Seed data for testing

## 📚 Learning Outcomes

This project demonstrates:
- ASP.NET Core Web API fundamentals
- Entity Framework Core with Code-First approach
- RESTful API design principles
- Database relationships and migrations
- Dependency injection
- Async programming in C#
- API documentation with Swagger

## 🔒 Notes

- This is a learning/portfolio project - **no authentication** is implemented
- Designed for local development and demonstration purposes
- Focus is on clean code and backend fundamentals

## 📄 License

This project is open source and available for educational purposes.

## 👤 Author

**Your Name**
- GitHub: [@KhoaBunnn](https://github.com/KhoaBunnn)
- Email: pkhoa3012@gmail.com

---


