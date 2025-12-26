-- =============================================
-- Inventory Management Database Schema
-- =============================================

-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'InventoryDB')
BEGIN
    CREATE DATABASE InventoryDB;
END
GO

USE InventoryDB;
GO

-- =============================================
-- Create Categories Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories')
BEGIN
    CREATE TABLE Categories (
        CategoryId INT PRIMARY KEY IDENTITY(1,1),
        CategoryName NVARCHAR(100) NOT NULL
    );
END
GO

-- =============================================
-- Create Products Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
BEGIN
    CREATE TABLE Products (
        ProductId INT PRIMARY KEY IDENTITY(1,1),
        ProductName NVARCHAR(200) NOT NULL,
        Quantity INT NOT NULL CHECK (Quantity >= 0),
        Price DECIMAL(18,2) NOT NULL CHECK (Price > 0),
        CategoryId INT NOT NULL,
        CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) 
            REFERENCES Categories(CategoryId)
    );
END
GO

-- =============================================
-- Insert Sample Data
-- =============================================

-- Insert Categories
IF NOT EXISTS (SELECT * FROM Categories)
BEGIN
    INSERT INTO Categories (CategoryName) VALUES 
        ('Electronics'),
        ('Clothing'),
        ('Books');
END
GO

-- Insert Products
IF NOT EXISTS (SELECT * FROM Products)
BEGIN
    INSERT INTO Products (ProductName, Quantity, Price, CategoryId) VALUES 
        ('Laptop', 10, 999.99, 1),
        ('T-Shirt', 50, 19.99, 2),
        ('Programming Book', 30, 49.99, 3);
END
GO

-- =============================================
-- Verify Data
-- =============================================
SELECT * FROM Categories;
SELECT * FROM Products;
GO
