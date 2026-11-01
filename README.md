# GreBaPOS



**GreBaPOS** is a Point of Sale (POS) and Inventory Management desktop application built using C# Windows Forms, .NET Framework 4.8, and Microsoft SQL Server.



## Features



- User authentication

- Product and inventory management

- Sales and checkout processing

- Receipt generation

- Dashboard and sales analytics

- User administration

- Inventory history and low-stock monitoring



## Technology Stack



- C#

- Windows Forms

- .NET Framework 4.8

- Microsoft SQL Server

- LINQ-to-SQL

- Visual Studio



## Requirements



Before building and running GreBaPOS, install:



- Visual Studio with the .NET desktop development workload

- .NET Framework 4.8 Developer Pack

- SQL Server Express

- SQL Server Management Studio (SSMS)



## Project Structure



```text

GreBaPOS/

├── EnterprisePOS.Data/

├── EnterprisePOS.Domain/

├── EnterprisePOS.Services/

├── EnterprisePOS.WinForms/

├── GreBaPOS.slnx

├── .gitignore

└── README.md

```



## Database Setup



GreBaPOS uses Microsoft SQL Server.



1. Install and start SQL Server Express.

2. Open SQL Server Management Studio.

3. Connect to your SQL Server instance.

4. Create or restore the required `Batestel` database.

5. Make sure the required database tables, stored procedures, and other objects are available.



## Database Connection



The current development configuration uses Windows Authentication:



```text

Data Source=.\\SQLEXPRESS;

Initial Catalog=Batestel;

Integrated Security=True;

Encrypt=True;

TrustServerCertificate=True;

```



The application uses a runtime connection-string provider with a default connection-string setting.



For another computer, configure the connection string to match its SQL Server instance and database. Do not commit passwords, production credentials, or other secrets to source control.



## Build Instructions



1. Clone or download this repository.

2. Open `GreBaPOS.slnx` in a compatible version of Visual Studio.

3. Allow Visual Studio to load the projects.

4. Set `EnterprisePOS.WinForms` as the startup project.

5. Select the **Release** configuration.

6. Build the solution.

7. Make sure the required SQL Server database is running before launching the application.



## Create the Desktop Installer



GreBaPOS can be packaged into a Windows installer using Inno Setup.



1. Build the application using the Release configuration in Visual Studio.

2. Prepare the required application files.

3. Locate and open the GreBaPOS Inno Setup script (`.iss`), which is maintained separately from the main project folder.

4. Compile the script using Inno Setup.

5. Test the generated installer on a separate computer.



**Note:** The Inno Setup script is maintained separately from the main project folder. The installer is currently stored locally and is not yet published through GitHub Releases.



## Hardware Requirements



- Windows-compatible receipt printer, if receipt printing is required.

- Barcode scanner, if barcode-based product entry is used.



Actual hardware compatibility depends on the connected device and its configuration.



## Security Guidelines



- Do not commit passwords, access tokens, or production credentials.

- Do not upload real customer information or sales records.

- Keep database backups outside the repository.

- Use test accounts and test data during development.

- Change any initial or default account passwords before production use.



## Source Control



The repository uses Git for version control. See the commit history for project changes.



## License



No license has been added to this repository. All rights are reserved by the project owner unless a license is added later.



## Development Workflow

New features are developed in separate Git branches and reviewed through Pull Requests before being merged into the main branch.
