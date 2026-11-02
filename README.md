# GreBaPOS

**GreBaPOS** is a Point of Sale (POS) and Inventory Management desktop application built using C# Windows Forms, .NET Framework 4.8, and Microsoft SQL Server[cite: 9].

## Features

- User authentication & role-based access control (Admin, Manager, Cashier)
- Product and inventory management
- Sales and checkout processing
- Receipt generation
- Dashboard and sales analytics
- User administration
- Inventory history and low-stock monitoring

## Technology Stack

- C# / Windows Forms (.NET Framework 4.8)[cite: 9]
- Microsoft SQL Server & SQL Server Express[cite: 9]
- LINQ-to-SQL[cite: 9]
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



## Default Accounts

The initial database seed creates the following default active accounts (change passwords before production use):

* **Admin**: `Username: admin`, `Password: Admin@123`
* **Manager**: `Username: manager` , `Password: Manager@123`
* **Cashier**: `Username: cashier` , `Password: cashier@123`

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

