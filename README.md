# Clothing Store API

Hi, this project follows **Clean Architecture** principles and is built using **.NET 8**, **C#**, and **Entity Framework Core** with **SQL Server**.
It has CRUD operations designed for the management of a clothing store.

---

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [API Endpoints](#api-endpoints)

---

## Features

- **Create Products**: Add new clothing items.
- **Retrieve Products**: Get details of all products or a specific product by ID.
- **Update Products**: Modify existing product details.
- **Delete Products**: Remove products from the store.
- **DTOs**: Uses Data Transfer Objects to manage input and output.
- **Automapper**: Automatically maps DTOs to entities and vice versa.
- **Clean Architecture**: Separation of concerns with Presentation, Application, Domain, and Infrastructure layers.
- **SQL Server Integration**: Uses Entity Framework Core for database management.

---

## Technologies Used

- **.NET 8**
- **C#**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **Swagger / OpenAPI**
- **Clean Architecture**

---

## Architecture

The project follows **Clean Architecture** principles with the following structure:

```
ClothingStoreAPI/
│
├── ClothingStore.API                // Controllers
│
├── ClothingStore.Application        // Business Logic, DTOs, Services
│
├── ClothingStore.Domain             // Entities, Core Business Logic
│
└── ClothingStore.Infrastructure     // Data, Entity Framework Core
```

---

## API Endpoints

### Products

| Method | Endpoint                                  | Description                           |
|--------|-------------------------------------------|---------------------------------------|
| GET    | /api/all-products                | Retrieves all products                |
| GET    | /api/findById/{productId}        | Retrieves a specific product by ID    |
| POST   | /api/new-product                 | Creates a new product                 |
| PUT    | /api/update-product/{productId}  | Updates an existing product          |
| DELETE | /api/delete-product/{productId}  | Deletes a product                    |

---

### Example Requests

#### Create a New Product

```http
POST /api/new-product
{
  "name": "T-Shirt",
  "description": "A comfortable cotton t-shirt",
  "price": 15,
  "category": "T-Shirt",
  "stockQuantity": 11
}
```

#### Get All Products

```http
GET /api/all-products
```

#### Get Product by ID

```http
GET /api/findById/1
```

#### Update an Existing Product

```http
PUT /api/update-product/1
Content-Type: application/json

{
  "name": "Updated T-Shirt",
  "description": "Updated description",
  "price": 15,
  "category": "T-Shirt",
  "stockQuantity": 11
}
```

#### Delete a Product

```http
DELETE /api/delete-product/1
```



