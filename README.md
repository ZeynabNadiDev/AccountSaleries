# Salary Management Web API

This project is a backend technical task implemented as part of a recruitment challenge.

It consists of:
- A Web API for managing employees' monthly salary data
- A Class Library for overtime calculation policies
- Support for multiple input formats (JSON, XML, Custom)
- Dockerized deployment using Dockerfile

---

## 🧱 Project Structure

- **OvertimePolicies (Class Library)**
  - Contains overtime calculation methods:
    - `CalcurlatorA`
    - `CalcurlatorB`
    - `CalcurlatorC`

- **Salary Web API**
  - Handles salary data submission, calculation, and persistence
  - Uses EF Core for write operations
  - Uses Dapper for read operations

---

## 🔄 Data Flow & Architecture

Request (JSON / XML / Custom)

↓

Parser (per data type)

↓

SalaryRawDto (Unified DTO)

↓

Mapper

↓

SalaryInput (Domain Model)

↓

Service → Database


This design ensures:
- Separation of concerns
- Format-independent domain logic
- Easier extensibility and maintainability

---

## 📥 Supported Input Formats

### JSON

POST /json/salary/add

### XML

POST /xml/salary/add

### Custom

POST /custom/salary/add

Custom format example:

FirstName/LastName/BasicSalary/Allowance/Transportation/Date
Ali/Ahmadi/1200000/400000/350000/14010801


## Request Body
```json
{
  "data": "...",
  "overTimeCalculator": "CalculatorB"
}

🧮 Salary Calculation Formula

NetSalary =
BasicSalary
+ Allowance
+ Transportation
+ OverTimeCalculator(BasicSalary + Allowance)
- Tax

📡 API Endpoints

Add
POST /{datatype}/salary/add

Update
PUT /{datatype}/salary/update

Delete
DELETE /{datatype}/salary/delete/{id}

Get (Dapper)
GET /salary/get/{id}

GetRange (Dapper)
GET /salary/getrange

🛠 Technologies Used

ASP.NET Core Web API
EF Core (Add, Update, Delete)
Dapper (Get, GetRange)
Swagger
Docker
SQL Server

🐳 Docker Notes
This project uses a Dockerfile for containerization.

Docker Compose was intentionally not used.
SQL Server is expected to be available on the host machine.
The API connects to SQL Server using SQL Authentication via:

host.docker.internal

Build & Run
docker build -t salary-api .
docker run -p 5178:8080 salary-api

▶️ Run Locally (Without Docker)
1.Update the connection string in appsettings.json
2.Apply migrations:

dotnet ef database update

3.Run the API
4.Open Swagger:

http://localhost:5178/swagger
🧪 Testing
Swagger UI is available for testing all endpoints and input formats.

🎥 Video Presentation
A short video (under 5 minutes) is provided separately, explaining:
Architecture decisions
Design choices
Trade-offs and assumptions
https://drive.google.com/file/d/1Dl57u1FfSD48m-mbBB8Ft0MmCf-lNh3x/view?usp=drive_link

📌 Notes
Due to time constraints, full unit test coverage was not implemented.
The architecture is designed to be testable and extensible.

📬 Author
https://github.com/ZeynabNadiDev
znadi05@gmail.com
