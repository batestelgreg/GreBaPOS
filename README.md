# GreBaPOS

**GreBaPOS** is a Point of Sale (POS) and Inventory Management desktop application built using C# Windows Forms, .NET Framework 4.8, and Microsoft SQL Server.

## 🚀 Quick Installation (Recommended for Users)

If you want to install and run GreBaPOS without setting up the source code, you can download the ready-to-use installer directly from our releases:

👉 **[Download GreBaPOS Installer (Latest Release)](https://github.com/batestelgreg/GreBaPOS/releases/latest)**

### Installation Steps:
1. Download `GreBaPOS_Setup.exe` from the [Releases page](https://github.com/batestelgreg/GreBaPOS/releases/latest).
2. Right-click the installer and select **Run as Administrator**.
3. The automated setup will handle application files, detect/configure SQL Server Express (`.\SQLEXPRESS`), and initialize the database schema and seed data.
4. Launch **GreBaPOS** from your desktop shortcut!


## 🔑 Default User Accounts

| Role | Username | Password |
| :--- | :--- | :--- |
| **Admin** | `admin` | `Admin@123` |
| **Manager** | `manager` | `Manager@123` |
| **Cashier** | `cashier` | `Cashier@123` |


## Features

- User authentication & role-based access control (Admin, Manager, Cashier)
- Product and inventory management
- Sales and checkout processing
- Receipt generation
- Dashboard and sales analytics
- User administration
- Inventory history and low-stock monitoring

## Technology Stack

- C# / Windows Forms (.NET Framework 4.8)
- Microsoft SQL Server & SQL Server Express
- LINQ-to-SQL[
- Inno Setup (for desktop installation packaging)
- PowerShell (for automated database schema deployment and verification)

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

## Installation Guide (For End-Users)

If you downloaded the application package (ZIP file) from GitHub Releases and want to install GreBaPOS:

1. **Download and Extract:** Download the release ZIP file from the repository's Releases page and extract its contents to a folder on your computer.
2. **Run the Installer:** Locate and right-click `GreBaPOS_Setup.exe`, then select **Run as Administrator**.
3. **Automated Setup:** The installation wizard will automatically:
* Install the application files to your system directory.
* Check and configure the local Microsoft SQL Server Express instance (`.\SQLEXPRESS`).
* Run the automated PowerShell setup script (`InstallDatabase.ps1`) to build the `Batestel` database, apply schemas, insert seed data, and verify system accounts.


4. **Launch:** Open **GreBaPOS** from your desktop shortcut and log in using your default credentials.

---

## Development & Build Instructions (For Developers)

### Requirements

Before building and running GreBaPOS from source, install:

* Visual Studio with the **.NET desktop development** workload


* .NET Framework 4.8 Developer Pack


* SQL Server Express (`.\SQLEXPRESS`)


* SQL Server Management Studio (SSMS)



### Running from Source

1. Clone or download this repository.


2. Open `GreBaPOS.slnx` in a compatible version of Visual Studio.


3. Allow Visual Studio to load the projects.


4. Set `EnterprisePOS.WinForms` as the startup project.


5. Select the **Release** configuration.


6. Build the solution.


7. Make sure the required SQL Server database is running before launching the application.



### Creating the Desktop Installer

GreBaPOS can be packaged into a Windows installer using Inno Setup:

1. Build the application using the Release configuration in Visual Studio.


2. Place the SQL Server Express installer (`SQLEXPR_x64_ENU.exe`) in your local deployment folder (excluded from Git).
3. Open the GreBaPOS Inno Setup script (`GreBaPOS.iss`).


4. Compile the script using Inno Setup to generate `GreBaPOS_Setup.exe`.



## Hardware Requirements

* Windows-compatible receipt printer, if receipt printing is required.


* Barcode scanner, if barcode-based product entry is used.



## Security Guidelines

* Do not commit passwords, access tokens, or production credentials.


* Do not upload real customer information or sales records.


* Keep database backups outside the repository.


* Use test accounts and test data during development.


* Change any initial or default account passwords before production use.



## Source Control

The repository uses Git for version control. See the commit history for project changes.


## License

No license has been added to this repository. All rights are reserved by the project owner unless a license is added later.


## Development Workflow

New features are developed in separate Git branches and reviewed through Pull Requests before being merged into the main branch.

