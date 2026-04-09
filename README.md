# 📌 Overview

A full-featured Desktop System that simulates a real-world Driving & Vehicle Licensing Department workflow.

The system manages people, users, driving license applications, testing processes, license issuance, renewals, replacements, and detention operations with structured business rules and layered architecture.

This project demonstrates real backend logic implementation beyond basic CRUD operations.

---

## 🏗️ Architecture

The project follows a clean **3-Tier Architecture**:

* **Presentation Layer (Windows Forms)**
* **Business Logic Layer (BLL)**
* **Data Access Layer (DAL)**

### Why this matters:

✔ Separation of concerns
✔ Maintainable codebase
✔ Scalable structure
✔ Reusable business logic

---

## 🔐 Authentication & User Management

* Secure Login System
* Add / Edit / Delete Users
* Account Settings
* Permission-based access
* Password management

---

## 👥 People Management

* Add new person
* Update personal information
* Delete records
* Advanced filtering
* Link person to license applications

---

## 📂 Application Types

The system supports multiple application types:

* New Local Driving License
* Renew Driving License
* Replace Lost License
* Replace Damaged License
* Release Detained License
* New International License

Each type has its own business rules and fee calculation logic.

---

## 📝 License Applications

### 🚘 Local Driving License

* Create application
* Assign required tests
* Track status
* Issue license

### 🌍 International Driving License

* Validate eligibility
* Issue international license

### 🔄 Renewal

* Validate expiration
* Calculate fees
* Generate renewed license

### ♻ Replacement (Lost / Damaged)

* Auto-detect issue reason
* Maintain license history
* Prevent invalid replacements

---

## 🚓 Detain & Release System

* Detain active licenses
* Record fines
* Release licenses
* Maintain detention history

---

## 🧪 Test Management

* Manage Test Types
* Assign tests
* Track results
* Control retake attempts

---

## 💾 Database Design

* Fully relational SQL Server database
* Strong constraints
* Stored procedures
* Enum-based business logic integration

---

## 🛠️ Technologies Used

* C#
* .NET Framework
* Windows Forms
* SQL Server
* ADO.NET
* Layered Architecture Pattern

---

## 🎯 Key Highlights

✔ Real-world business workflow simulation
✔ Complex application state handling
✔ Strong separation between layers
✔ Enum-driven decision logic
✔ Status tracking system
✔ Clean structured code
