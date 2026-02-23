# 💼 Salary Management Web API

A backend technical task developed as part of a recruitment challenge.

This project provides a flexible and extensible **Salary Management Web API** that supports multiple input formats and dynamic overtime calculation policies.

---

## 📌 Overview

The solution consists of:

- 🌐 ASP.NET Core Web API  
- 📚 OvertimePolicies Class Library  
- 🗄 SQL Server Database  
- 🐳 Dockerized Deployment  

---

## 🧱 Project Structure

```
SalaryManagementSolution
│
├── OvertimePolicies        # Class Library
│   ├── CalculatorA
│   ├── CalculatorB
│   └── CalculatorC
│
└── Salary Web API          # Main API Project
```

### 🔹 OvertimePolicies (Class Library)

Contains different overtime calculation strategies:

- `CalculatorA`
- `CalculatorB`
- `CalculatorC`

Designed for easy extensibility (Open/Closed Principle).

---

### 🔹 Salary Web API

Responsible for:

- Receiving salary data  
- Parsing different formats  
- Mapping to domain models  
- Calculating net salary  
- Persisting data  

#### Data Access Strategy

- ✅ EF Core → Add / Update / Delete  
- ✅ Dapper → Read operations (Get / GetRange)  

---

## 🔄 Architecture & Data Flow

```
Request (JSON / XML / Custom)
        ↓
Parser (based on datatype)
        ↓
SalaryRawDto (Unified DTO)
        ↓
Mapper
        ↓
SalaryInput (Domain Model)
        ↓
Service Layer
        ↓
Database
```

The architecture is:

- Clean  
- Maintainable  
- Testable  
- Extensible  

---

## 📥 Supported Input Formats

### 1️⃣ JSON
```
POST /json/salary/add
```

### 2️⃣ XML
```
POST /xml/salary/add
```

### 3️⃣ Custom Format
```
POST /custom/salary/add
```

#### Custom Format Example

```
FirstName/LastName/BasicSalary/Allowance/Transportation/Date
Ali/Ahmadi/1200000/400000/350000/14010801
```

---

## 📦 Request Body Structure

```json
{
  "data": "...",
  "overTimeCalculator": "CalculatorB"
}
```

---

## 🧮 Salary Calculation Formula

```
NetSalary =
BasicSalary
+ Allowance
+ Transportation
+ OverTimeCalculator(BasicSalary + Allowance)
- Tax
```

---

## 📡 API Endpoints

### ➕ Add
```
POST /{datatype}/salary/add
```

### ✏️ Update
```
PUT /{datatype}/salary/update
```

### ❌ Delete
```
DELETE /{datatype}/salary/delete/{id}
```

### 📥 Get (Dapper)
```
GET /salary/get/{id}
```

### 📋 GetRange (Dapper)
```
GET /salary/getrange
```

---

## 🛠 Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core  
- Dapper  
- SQL Server  
- Swagger  
- Docker  

---

## 🐳 Docker Deployment

This project includes a **Dockerfile** for containerization.

> ⚠️ Docker Compose was intentionally not used.  
> SQL Server must be available on the host machine.

Connection string uses:

```
host.docker.internal
```

### 🔹 Build & Run

```bash
docker build -t salary-api .
docker run -p 5178:8080 salary-api
```

---

## ▶️ Run Locally (Without Docker)

1. Update the connection string in `appsettings.json`  
2. Apply migrations:

```bash
dotnet ef database update
```

3. Run the API  
4. Open Swagger:

```
http://localhost:5178/swagger
```

---

## 🧪 Testing

Swagger UI is available for testing all endpoints and supported input formats.

---

## 🎥 Video Presentation

A short video explaining:

- Architecture decisions  
- Design choices  
- Trade-offs and assumptions  

🔗  
https://drive.google.com/file/d/1Dl57u1FfSD48m-mbBB8Ft0MmCf-lNh3x/view?usp=drive_link

---

## 📌 Notes

- Due to time constraints, full unit test coverage was not implemented.  
- The architecture is designed to be extensible and testable.  
- Overtime calculation strategies can be expanded without modifying existing logic.  

---

## 👩‍💻 Author

**Zeynab Nadi**

- GitHub: https://github.com/ZeynabNadiDev  
- Email: znadi05@gmail.com  
