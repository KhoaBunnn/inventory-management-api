# API Testing Guide

## Testing with Swagger UI (Easiest Method)

### 1. Start the Application
```bash
dotnet run
```

### 2. Open Swagger UI
Navigate to: `https://localhost:7001`

### 3. Test Each Endpoint

#### Test Categories

**GET all categories:**
1. Expand `GET /api/categories`
2. Click "Try it out"
3. Click "Execute"
4. Expected: 200 OK with list of categories

**GET category by ID:**
1. Expand `GET /api/categories/{id}`
2. Click "Try it out"
3. Enter ID: `1`
4. Click "Execute"
5. Expected: 200 OK with Electronics category

**POST create category:**
1. Expand `POST /api/categories`
2. Click "Try it out"
3. Enter request body:
```json
{
  "categoryName": "Sports Equipment"
}
```
4. Click "Execute"
5. Expected: 201 Created with new category

**PUT update category:**
1. Expand `PUT /api/categories/{id}`
2. Click "Try it out"
3. Enter ID: `4` (or the ID from previous POST)
4. Enter request body:
```json
{
  "categoryId": 4,
  "categoryName": "Sports & Outdoors"
}
```
5. Click "Execute"
6. Expected: 204 No Content

**DELETE category:**
1. Expand `DELETE /api/categories/{id}`
2. Click "Try it out"
3. Enter ID: `4`
4. Click "Execute"
5. Expected: 204 No Content

#### Test Products

**GET all products:**
1. Expand `GET /api/products`
2. Click "Try it out"
3. Click "Execute"
4. Expected: 200 OK with list of products (includes category info)

**POST create product:**
1. Expand `POST /api/products`
2. Click "Try it out"
3. Enter request body:
```json
{
  "productName": "Wireless Keyboard",
  "quantity": 15,
  "price": 45.99,
  "categoryId": 1
}
```
4. Click "Execute"
5. Expected: 201 Created with new product

## Testing with Postman

### Import Collection

Create a new collection with these requests:

**1. Get All Categories**
- Method: GET
- URL: `https://localhost:7001/api/categories`

**2. Get Category by ID**
- Method: GET
- URL: `https://localhost:7001/api/categories/1`

**3. Create Category**
- Method: POST
- URL: `https://localhost:7001/api/categories`
- Headers: `Content-Type: application/json`
- Body (raw JSON):
```json
{
  "categoryName": "Home & Garden"
}
```

**4. Update Category**
- Method: PUT
- URL: `https://localhost:7001/api/categories/1`
- Headers: `Content-Type: application/json`
- Body (raw JSON):
```json
{
  "categoryId": 1,
  "categoryName": "Electronics & Gadgets"
}
```

**5. Delete Category**
- Method: DELETE
- URL: `https://localhost:7001/api/categories/4`

**6. Get All Products**
- Method: GET
- URL: `https://localhost:7001/api/products`

**7. Create Product**
- Method: POST
- URL: `https://localhost:7001/api/products`
- Headers: `Content-Type: application/json`
- Body (raw JSON):
```json
{
  "productName": "Gaming Mouse",
  "quantity": 20,
  "price": 59.99,
  "categoryId": 1
}
```

## Testing with cURL

### Categories

```bash
# Get all categories
curl -k https://localhost:7001/api/categories

# Get category by ID
curl -k https://localhost:7001/api/categories/1

# Create category
curl -k -X POST https://localhost:7001/api/categories \
  -H "Content-Type: application/json" \
  -d "{\"categoryName\":\"Toys\"}"

# Update category
curl -k -X PUT https://localhost:7001/api/categories/1 \
  -H "Content-Type: application/json" \
  -d "{\"categoryId\":1,\"categoryName\":\"Electronics & Tech\"}"

# Delete category
curl -k -X DELETE https://localhost:7001/api/categories/4
```

### Products

```bash
# Get all products
curl -k https://localhost:7001/api/products

# Get product by ID
curl -k https://localhost:7001/api/products/1

# Create product
curl -k -X POST https://localhost:7001/api/products \
  -H "Content-Type: application/json" \
  -d "{\"productName\":\"USB Cable\",\"quantity\":100,\"price\":9.99,\"categoryId\":1}"

# Update product
curl -k -X PUT https://localhost:7001/api/products/1 \
  -H "Content-Type: application/json" \
  -d "{\"productId\":1,\"productName\":\"Gaming Laptop\",\"quantity\":5,\"price\":1299.99,\"categoryId\":1}"

# Delete product
curl -k -X DELETE https://localhost:7001/api/products/4
```

## Expected HTTP Status Codes

| Status Code | Meaning | When You'll See It |
|-------------|---------|-------------------|
| 200 OK | Success | GET requests that return data |
| 201 Created | Resource created | POST requests |
| 204 No Content | Success, no data | PUT and DELETE requests |
| 400 Bad Request | Invalid input | Validation errors, missing fields |
| 404 Not Found | Resource not found | GET/PUT/DELETE with invalid ID |

## Common Test Scenarios

### ✅ Valid Operations

1. **Create category → Create product in that category**
2. **Update product price and quantity**
3. **Get all products (should include category info)**

### ❌ Error Cases to Test

1. **Create product with invalid category ID**
   - Expected: 400 Bad Request
   
2. **Delete category that has products**
   - Expected: 400 Bad Request
   
3. **Get non-existent product**
   - Expected: 404 Not Found
   
4. **Create product with negative price**
   - Expected: 400 Bad Request
   
5. **Update product with mismatched ID**
   - Expected: 400 Bad Request

## Validation Rules to Test

### Product Validation
- ❌ ProductName: Required, max 200 characters
- ❌ Quantity: Required, must be >= 0
- ❌ Price: Required, must be > 0
- ❌ CategoryId: Required, must exist in database

### Category Validation
- ❌ CategoryName: Required, max 100 characters

## Sample Test Data

```json
// Valid Product
{
  "productName": "Mechanical Keyboard",
  "quantity": 25,
  "price": 89.99,
  "categoryId": 1
}

// Invalid Product (negative quantity)
{
  "productName": "Test Product",
  "quantity": -5,
  "price": 10.00,
  "categoryId": 1
}

// Invalid Product (zero price)
{
  "productName": "Test Product",
  "quantity": 10,
  "price": 0,
  "categoryId": 1
}

// Invalid Product (non-existent category)
{
  "productName": "Test Product",
  "quantity": 10,
  "price": 10.00,
  "categoryId": 999
}
```

---

**Pro Tip:** Use Swagger UI for quick testing during development. It's the fastest way to verify your API works correctly!
