# GreBaPOS

**GreBaPOS** is a Point of Sale (POS) and Inventory Management desktop application built using C# Windows Forms, .NET Framework 4.8, and Microsoft SQL Server.

## 🚀 Quick Installation

### Recommended for End-Users

Download the latest ready-to-use installer from our GitHub Releases:

**[Download GreBaPOS Installer – Latest Release](https://github.com/batestelgreg/GreBaPOS/releases/latest)**

### 📋 System Requirements

Before installing GreBaPOS, ensure your computer meets the following requirements:

1. **Operating System:** Windows 10 / 11 (64-bit)
2. **.NET Framework:** 4.8 Runtime
3. **Database Engine:** Microsoft SQL Server Express with the `.\SQLEXPRESS` instance configured and Windows Authentication enabled.

**Note:**
- Download SQL Server Express from the [official Microsoft SQL Server Downloads page](https://www.microsoft.com/sql-server/sql-server-downloads).
- SQL Server Management Studio (SSMS) is optional and is not required for regular application users.
- Only the SQL Server Express database engine is required to run the application.

### 🛠️ Installation Guide

**Automated Database Setup**

You do not need to manually create the database, tables, stored procedures, or default user accounts. The installer automatically handles the database deployment.

Follow these steps:

1. Download `GreBaPOS_Setup.exe` from the [GitHub Releases page](https://github.com/batestelgreg/GreBaPOS/releases/latest).
2. Right-click the installer and select **Run as Administrator**.
3. Follow the installation wizard.

   During installation, the setup process automatically:

   - Installs the application files on your computer.
   - Detects the local SQL Server Express instance (`.\SQLEXPRESS`).
   - Executes the `InstallDatabase.ps1` PowerShell script.
   - Creates the `Batestel` database.
   - Deploys the database schema, tables, and stored procedures.
   - Seeds the default system accounts.
   - Performs the necessary database deployment and verification steps.

4. Once installation is complete, launch **GreBaPOS** using the desktop shortcut.
5. Log in using one of the default user accounts provided below.

---

## 🔑 Default User Accounts

GreBaPOS includes three default user accounts with different access roles.

| Role | Username | Password |
|:---|:---|:---|
| **Admin** | `admin` | `Admin@123` |
| **Manager** | `manager` | `Manager@123` |
| **Cashier** | `cashier` | `Cashier@123` |

**Security Reminder:** Change all default passwords after your first successful login, especially before using the application in a production environment.

---

## ✨ Features

### User Management
- User authentication and secure login.
- Role-based access control (Admin, Manager, and Cashier).
- User administration and account management.

### Product and Inventory Management
- Product management.
- Inventory monitoring and tracking.
- Inventory history.
- Low-stock monitoring.

### Sales and Checkout
- Sales transaction processing.
- Checkout management.
- Receipt generation.

### Dashboard and Analytics
- Dashboard overview.
- Sales analytics and reporting.
- Inventory monitoring.

---

## 💻 Technology Stack

GreBaPOS is developed using the following technologies and tools:

| Technology | Purpose |
|:---|:---|
| C# | Primary programming language |
| Windows Forms | Desktop application user interface |
| .NET Framework 4.8 | Application framework |
| Microsoft SQL Server Express | Database management |
| LINQ-to-SQL | Database access and data operations |
| PowerShell | Automated database deployment, seeding, and verification |
| Inno Setup | Windows application installer packaging |
| Git | Source control and version management |

---

## 📁 Project Structure

The solution follows a layered architecture with separate projects for data access, domain models, business logic, and the Windows Forms interface.

```text
GreBaPOS/
│
├── Database/
│   ├── Batestel_Schema.sql
│   └── Batestel_Seed.sql
│
├── EnterprisePOS.Data/
│
├── EnterprisePOS.Domain/
│
├── EnterprisePOS.Services/
│
├── EnterprisePOS.WinForms/
│
├── GreBaPOS.slnx
├── GreBaPOS.iss
├── InstallDatabase.ps1
├── .gitignore
└── README.md
```

### Project Responsibilities

- **EnterprisePOS.Data** – Handles database access and data operations.
- **EnterprisePOS.Domain** – Contains domain models and application entities.
- **EnterprisePOS.Services** – Handles business logic and application services.
- **EnterprisePOS.WinForms** – Contains the desktop user interface and application forms.
- **Database** – Contains the SQL scripts for database schema creation and initial data seeding.
- **InstallDatabase.ps1** – Automates database installation, configuration, seeding, and verification.
- **GreBaPOS.iss** – Defines the Inno Setup configuration for creating the Windows installer.

---

## 🧑‍💻 Development and Build Instructions

### Development Requirements

To build and run GreBaPOS from source, install the following:

- Visual Studio with the **.NET desktop development** workload.
- .NET Framework 4.8 Developer Pack.
- Microsoft SQL Server Express with the `.\SQLEXPRESS` instance.
- SQL Server Management Studio (SSMS) – Optional, for database inspection and management.
- Inno Setup – Required when creating the desktop installer.

### Running the Application from Source

1. Clone or download this repository.
2. Open `GreBaPOS.slnx` using a compatible version of Visual Studio.
3. Allow Visual Studio to load all solution projects.
4. Set `EnterprisePOS.WinForms` as the startup project.
5. Select the **Release** configuration.
6. Build the solution.
7. Ensure that the SQL Server Express instance (`.\SQLEXPRESS`) is running.
8. Run the application.

### Creating the Desktop Installer

GreBaPOS uses Inno Setup to package the application into a Windows installer.

Follow these steps:

1. Open the solution in Visual Studio.
2. Select the **Release** configuration.
3. Build the entire solution.
4. Open `GreBaPOS.iss` using Inno Setup Compiler.
5. Compile the installer script.
6. The generated `GreBaPOS_Setup.exe` will be available in the configured output directory.

---

## 🖨️ Hardware Requirements

The following hardware devices are optional, depending on the intended usage:

- **Receipt Printer** – For printing customer transaction receipts.
- **Barcode Scanner** – For barcode-based product entry and faster checkout operations.

---

## 🔒 Security Guidelines

To maintain application and database security, follow these guidelines:

- Never commit passwords, access tokens, or production credentials to the repository.
- Avoid uploading real customer information or confidential sales records.
- Keep database backups outside the source code repository.
- Use test accounts and test data during development.
- Change all initial and default account passwords before production use.
- Restrict database access to authorized users.
- Regularly back up important database records.

---

## 🌿 Source Control

GreBaPOS uses **Git** for source control and project version management.

The repository maintains a commit history to track changes, updates, and improvements throughout development.

---

## 🔄 Development Workflow

New features and improvements are developed using separate Git branches.

The development workflow follows these steps:

1. Create a separate branch for the new feature or modification.
2. Implement and test the changes.
3. Commit the completed changes.
4. Submit a Pull Request for review.
5. Merge the approved changes into the main branch.

This workflow helps maintain organized development and reduces the risk of introducing unintended changes to the main project.

---

## 📄 License

No open-source license has been added to this repository.

All rights are reserved by the project owner unless a license is added in the future.