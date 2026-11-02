Ania ang gihapsay ug gi-revise nga **`README.md`** nga gi-optimize aron masabtan dayon sa mga mo-install nga **kinahanglan lang nila ang SQL Server Express (`.\SQLEXPRESS`)**, ug ang installer na ang bahala sa paghimo sa `Batestel` database ug pagbutang sa default accounts sa background nga walay hasol:

```markdown
# GreBaPOS

**GreBaPOS** is a Point of Sale (POS) and Inventory Management desktop application built using C# Windows Forms, .NET Framework 4.8, and Microsoft SQL Server.

## 🚀 Quick Installation (Recommended for Users)

If you want to install and run GreBaPOS, you can download the ready-to-use installer directly from our releases:

👉 **[Download GreBaPOS Installer (Latest Release)](https://github.com/batestelgreg/GreBaPOS/releases/latest)**

### 📋 Prerequisites for End-Users:
Before running the installer, ensure your computer has the following requirements:
1. **Windows 10 / 11** (64-bit)
2. **.NET Framework 4.8 Runtime**
3. **Microsoft SQL Server Express** (`.\SQLEXPRESS`) installed locally with Windows Authentication enabled.
   - *Note: You can download the free Express edition directly from the [Microsoft SQL Server Downloads page](https://www.microsoft.com/sql-server/sql-server-downloads).*
   - *Important:* **SSMS (SQL Server Management Studio)** is **not required** for regular users; only the SQL Server Express engine is needed to run the database.

### 🛠️ Installation Steps (100% Automated Database Setup):
You do **not** need to manually create databases, tables, or insert accounts. The installer handles everything automatically:
1. Download `GreBaPOS_Setup.exe` from the [Releases page](https://github.com/batestelgreg/GreBaPOS/releases/latest).
2. Right-click the installer and select **Run as Administrator**.
3. **Automated Deployment:** The setup wizard will automatically:
   - Install the application files to your system.
   - Detect your local SQL Server Express instance (`.\SQLEXPRESS`).
   - Run the background PowerShell script (`InstallDatabase.ps1`) to automatically create the **`Batestel`** database, build all schemas, and seed the default system accounts.
4. Launch **GreBaPOS** from your desktop shortcut and log in immediately!

---

## 🔑 Default User Accounts

Once installed, you can log in using any of these default roles:

| Role | Username | Password |
| :--- | :--- | :--- |
| **Admin** | `admin` | `Admin@123` |
| **Manager** | `manager` | `Manager@123` |
| **Cashier** | `cashier` | `Cashier@123` |

---

## Features

- User authentication & role-based access control (Admin, Manager, Cashier)
- Product and inventory management
- Sales and checkout processing
- Receipt generation
- Dashboard and sales analytics
- User administration
- Inventory history and low-stock monitoring

---

## Technology Stack

- C# / Windows Forms (.NET Framework 4.8)
- Microsoft SQL Server & SQL Server Express (`.\SQLEXPRESS`)
- LINQ-to-SQL
- Inno Setup (for desktop installation packaging)
- PowerShell (for automated database schema deployment, seeding, and verification)

---

## Project Structure

```text
GreBaPOS/
├── Database/
│   ├── Batestel_Schema.sql
│   ├── Batestel_Seed.sql
├── EnterprisePOS.Data/
├── EnterprisePOS.Domain/
├── EnterprisePOS.Services/
├── EnterprisePOS.WinForms/
├── GreBaPOS.slnx
├── GreBaPOS.iss
├── InstallDatabase.ps1
├── .gitignore
└── README.md

```

---

## Development & Build Instructions (For Developers)

### Requirements

Before building and running GreBaPOS from source, install:

* Visual Studio with the **.NET desktop development** workload
* .NET Framework 4.8 Developer Pack
* SQL Server Express (`.\SQLEXPRESS`)
* SQL Server Management Studio (SSMS) *(Optional, for database inspection)*

### Running from Source

1. Clone or download this repository.
2. Open `GreBaPOS.slnx` in a compatible version of Visual Studio.
3. Allow Visual Studio to load the projects.
4. Set `EnterprisePOS.WinForms` as the startup project.
5. Select the **Release** configuration.
6. Build the solution.
7. Make sure SQL Server Express is running before launching the application.

### Creating the Desktop Installer

GreBaPOS can be packaged into a Windows installer using Inno Setup:

1. Build the application using the Release configuration in Visual Studio.
2. Open the GreBaPOS Inno Setup script (`GreBaPOS.iss`).
3. Compile the script using Inno Setup to generate `GreBaPOS_Setup.exe`.

---

## Hardware Requirements

* Windows-compatible receipt printer, if receipt printing is required.
* Barcode scanner, if barcode-based product entry is used.

---

## Security Guidelines

* Do not commit passwords, access tokens, or production credentials.
* Do not upload real customer information or sales records.
* Keep database backups outside the repository.
* Use test accounts and test data during development.
* Change any initial or default account passwords before production use.

---

## Source Control

The repository uses Git for version control. See the commit history for project changes.

---

## License

No license has been added to this repository. All rights are reserved by the project owner unless a license is added later.

---

## Development Workflow

New features are developed in separate Git branches and reviewed through Pull Requests before being merged into the main branch.
