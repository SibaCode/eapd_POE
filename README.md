
## 📸 I have deployed the website

Link :
📌 Website : [github.com/zuzakuhle](https://github.com/your-profile)
📌 GitHub : [click here](https://github.com/SibaCode/eapd_POE)

📌 GitHub: (https://github.com/SibaCode/eapd_POE)

# Agri-Energy Connect - README

## Overview

Agri-Energy Connect is a platform designed to empower local farmers by allowing them to list their products and connect with other farmers. The system has two main user roles: **Farmer** and **Employee**.

- **Farmers** can log in to manage their products, add new ones, and explore other farmers' offerings.
- **Employees** (admin users) have the ability to manage farmers and products, and filter products by name or category.

---

## User Credentials

### Farmer Login
Farmers can log in to the platform with the following credentials:

| **Username** | **Password** |
|--------------|--------------|
| Farmer1      | F@rmer1      |

Once logged in, farmers can:
- Add their products
- View products from other farmers in the marketplace

### Employee Login
Employees can log in with the following credentials:

| **Username** | **Password** |
|--------------|--------------|
| Admin1       | @admin       |

Once logged in, employees can:
- Add, edit, and delete farmer profiles
- View all products listed by farmers
- Filter products by name or category

---

## Features

### Farmer Dashboard
When a **Farmer** logs in, they are presented with a dashboard that includes:
- **Add Product**: A button to add their produce to the platform.
- **Products**: A section where they can view products listed by other farmers.
  
Farmers can list products such as fruits, vegetables, or other agricultural produce with the following information:
- **Name**: The product's name.
- **Category**: The product category (e.g., fruits, vegetables).
- **Price**: The price of the product.
- **Stock Availability**: Whether the product is in stock or out of stock.
- **Production Date**: When the product was harvested.

### Employee Dashboard
When an **Employee** logs in, they are provided with an admin dashboard where they can:
- **Manage Farmers**: Add, edit, or delete farmer profiles.
- **View Products**: Access all products listed by farmers, filterable by **name** or **category**.

### Marketplace
- Farmers and employees alike can view products from other farmers in the marketplace. Products are displayed with relevant details such as price, category, and availability.

---

## System Workflow

1. **Farmer Login**:
    - Farmer enters their credentials (e.g., `Farmer1` / `F@rmer1`).
    - Once logged in, they can manage their products and see other farmers' products in the marketplace.
    
2. **Employee Login**:
    - Employee logs in using credentials (e.g., `Admin1` / `@admin`).
    - Employees can manage the farmer database (add/edit/delete) and filter/view all listed products.

---

## Setting Up the Development Environment

### Prerequisites

Before running the system, you must have the following installed:
- .NET SDK (version 5.0 or higher)
- Visual Studio or Visual Studio Code (with C# extension)
- SQL Server (or use Azure SQL for a remote database setup)
- Git (for version control)

### Instructions

1. **Clone the Repository**

   Clone the repository to your local machine:

   ```bash
   git clone https://github.com/SibaCode/eapd_POE.git
---

### ⚙️ 2. Configure Database

In `appsettings.json`, configure your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=AgriEnergyDB;Trusted_Connection=True;"
}
```

> Adjust the connection string if you're using full SQL Server instead of LocalDB.

---

### 🏗 3. Apply Migrations and Create Database

Open a terminal or Package Manager Console and run:

```bash
dotnet ef database update
```

---

### ▶️ 4. Run the Project

From the root directory:

```bash
dotnet run
```

Then open your browser and visit:

```
http://localhost:5000
```

---

## ▶️ How to Build and Run the System

### 🔨 To Build

```bash
dotnet build
```

### 🚀 To Run

```bash
dotnet run
```

Or press the **▶ Start Debugging** button in Visual Studio.

---

## 🔐 How Authentication & Sessions Work

- When a farmer logs in, their username is stored in the session:
```csharp
HttpContext.Session.SetString("FarmerUsername", farmer.Username);
```

- Every protected page checks if this session variable exists:
```csharp
var farmerUsername = HttpContext.Session.GetString("FarmerUsername");
if (string.IsNullOrEmpty(farmerUsername))
    return RedirectToAction("Login", "Farmer");
```

- This prevents unauthorized access and ensures **role-based logic** (Farmer vs Employee).

---
