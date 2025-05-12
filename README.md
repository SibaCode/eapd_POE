
# 🌿 Agri-Energy Connect: Empowering Farmers Through Technology

Agri-Energy Connect is a **prototype platform** built with **ASP.NET Core MVC** and C#. It helps:


---
Pre-added Credentials
Farmer
Username - Farmer1
Password - F@rmer1

Employee
Username - Admin1
Password - @admin
## 👤 User Roles and What They Can Do

### 🧑‍🌾 Farmer

| Action                                        | Description |
|-----------------------------------------------|-------------|
| Login - using pre-added credentials           | Securely access their dashboard. |
| Add Product                                   | Upload new agricultural items for visibility. |
| Edit/Delete Product                           | Manage only their own listings. |
| View Other Products                           | Browse offerings from fellow farmers. |

> 🔐 Farmers cannot see or manage products submitted by others beyond viewing them.

---

### 🧑‍💼 Employee (Coming Soon / For Extension)

| Action                        | Description |
|-------------------------------|-------------|
| Login                         | Access to internal employee dashboard. |
| View All Products             | View all products submitted by farmers. |
| Create new farmer credentials | Register and provide login details. |
| Submit to Marketplace         | Publish verified listings to wider networks. |

> 🔒 Employees have different access logic and are authenticated using a separate login path.

---

## ⚙️ System Functionalities Overview

The system offers the following core features:

- **Secure Farmer Registration & Login**
- **Session-based role access**
- **Product Creation** (name, price, category, stock status, production date)
- **Farmer Dashboard** – See your products + explore others
- **Role-based permissions** to limit access based on login type
- **Educational & Marketplace Sections** (Coming soon)

---

## 🛠 Step-by-Step Development Setup

### ✅ Prerequisites

You must have the following installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- [SQL Server or LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/)
- [Git](https://git-scm.com/) for cloning the repository

---

### 🧪 1. Clone the Project

```bash
git clone https://github.com/your-username/agri-energy-connect.git
cd agri-energy-connect
```

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

## 🧭 How the System Works

### 👨‍🌾 Farmer Side – Full Flow

1. **Pre-registered **
   - Get pre-added credentials - username, full name, password from the admin
   - Password is securely hashed.
   - Separate login path (`/Farmer/Login`)

2. **Login**
   - Verified credentials start a session.
   - Session grants access to the Farmer Dashboard.

3. **Dashboard Features**
   - See welcome banner and UI tiles.
   - Button to "Add Product" (Create View)
   - List of **all other farmer products** shown below (view only)

4. **Add/Edit/Delete Products**
   - Add your own items via the form.
   - Only **your own** products will show edit/delete options.
   - Products must include:
     - Name
     - Category
     - Price
     - Production Date
     - In Stock or Not

5. **Logout**
   - Session ends. Farmer is redirected to login if trying to return.

---

### 👩‍💼 Employee Side – Future Implementation (Optional)

1. **Employee Register and Login**
   - Using username/passwords.
   - Separate login path (`/Employee/Login`).

2. **View Dashboard**
   - See **all submitted products** across all farmers.

3. **Create  and manage new farmers**
   - Using name and password..



---

## 📸 I have deployed the website

Link :
📌 Website : [github.com/zuzakuhle](https://github.com/your-profile)
📌 GitHub: [github.com/zuzakuhle](https://github.com/your-profile)
- Logging in as Farmer
- Adding a product
- Browsing products from others
- Role-based restrictions (cannot edit/delete other products)
- Logging out and being redirected to login screen

---

📌 GitHub: [github.com/zuzakuhle](https://github.com/your-profile)

---

*Agri-Energy Connect – Bridging the gap between sustainable farming and digital innovation.*
