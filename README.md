# 🍔 Foodie — Online Restaurant Ordering System

A web-based restaurant ordering application built as a university project using ASP.NET Web Forms, C#, Bootstrap 5, and SQL Server.

---

## 📌 Project Overview

Foodie is a fully functional online food ordering system that allows customers to browse a restaurant menu, add items to a cart, and place orders. It also includes an admin panel for managing menu items.

---

## 🛠️ Technologies Used

| Layer | Technology |
|---|---|
| Frontend | HTML, CSS, Bootstrap 5, Font Awesome |
| Backend | ASP.NET Web Forms, C# |
| Database | Microsoft SQL Server (SSMS) |
| IDE | Visual Studio 2022 |
| Architecture | Client-Server |

---

## ✅ Features

- User registration and login with session management
- Dynamic menu page loaded from database
- Search food items by name
- Filter menu by category (Burgers, Pizza, Sides, Drinks)
- Session-based shopping cart (add and remove items)
- Order placement with total calculation
- Order history with Pending / Delivered status
- Admin panel to add and delete menu items
- Responsive design using Bootstrap 5

---

## 🗄️ Database Tables

| Table | Description |
|---|---|
| Users | Stores customer name, email, password |
| MenuItems | Stores food name, description, price, category, image |
| Orders | Stores order total, date, status, and user reference |
| OrderItems | Stores individual items belonging to each order |

---

## 🚀 How to Run This Project

### Requirements
- Visual Studio 2022
- .NET Framework 4.7 or above
- SQL Server / SSMS

### Steps

**1. Clone the repository**
