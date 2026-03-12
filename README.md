# 🖥️ PC Store Manager

PC Store Manager is a **C# console application** for managing a computer components inventory.  
The application allows users to add components, sell them, check stock availability, and search products by category.

This project demonstrates the use of **C#, OOP concepts, Dictionary collections, and LINQ** in a simple inventory management system.

---

# 🚀 Features

The application provides the following functionality:

## ➕ Add New Component
Users can add a new PC component by providing:
- Component name
- Category (CPU, GPU, RAM, SSD, etc.)
- Price
- Quantity

If the component already exists in the store, the program updates the quantity instead of creating a duplicate entry.

---

## 💰 Sell Component

Allows the user to sell a component from the store.

The program will:
- Check if the component exists
- Check if the component is in stock
- Reduce the quantity by one

If the product is out of stock or does not exist, the program will notify the user.

---

## 📦 Check Availability

Users can check whether a component is available in the store.

The program displays:
- Component name
- Price
- Current quantity in stock

---

## 💎 Show Most Expensive Product

Displays the most expensive component currently available in the store.

Information shown:
- Component name
- Category
- Price
- Quantity

This feature uses **LINQ sorting** to determine the highest priced item.

---

## 🔎 Search by Category

Users can search for components by category.

Features:
- Case-insensitive search
- Results sorted by **price and quantity**
- Displays all components that match the category

Example categories:
- CPU
- GPU
- RAM
- SSD
- Motherboard

---

# 🧠 Technologies Used

This project was built using:

- **C#**
- **.NET Console Application**
- **Object-Oriented Programming (OOP)**
- **Dictionary Collection**
- **LINQ**
- **Git**
- **GitHub**
