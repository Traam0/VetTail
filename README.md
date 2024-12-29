# VetTail

**VetTail** is a comprehensive veterinary management system designed to streamline the workflow of veterinary clinics. This project aims to provide an efficient and user-friendly platform for managing patient records, appointments, treatments, and billing.

This is a **school project** developed as part of the **Exam Final Module (EFM)**.

## Installation Guide

To get started with **VetTail**, follow these steps for setting up the .NET MVC web application:

### Prerequisites
- [Visual Studio](https://visualstudio.microsoft.com/) (Version 2019 or later recommended)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)

### Steps to Install

1. **Clone the repository**:
    ```bash
	    git clone https://github.com/Traam0/VetTail.git
    ```
2. **Open the solution in Visual Studio**:
	- Navigate to the directory where you cloned the repository.
	- Open the `VetTail.sln` solution file in Visual Studio.

3. **Restore NuGet Packages**:
	- Visual Studio should automatically restore the required NuGet packages. If not, you can manually restore them by right-clicking the solution in Solution Explorer and selecting **Restore NuGet Packages**.
4. **Set up the Database**:
	- Ensure you have SQL Server installed and running.
	- Update the connection string in the `web.config` or `appsettings.json` file to match your local database configuration.
	- Run the database migrations using Entity Framework to set up the required tables and schema:
	  ```bash
		  Update-Database
		```
5. **Build and Run**:
	- Build the solution by clicking **Build > Build Solution**.
	- Once built, run the application by pressing **F5** or clicking on the **Start** button in Visual Studio.
6. **Access the Web Application**

---
## Notes

- This is a basic version of the **VetTail** system. You can further extend and customize the application for real-world use.
- For more advanced setup or deployment, please refer to the official .NET documentation.

## Contributors

Thank you to the following people who have contributed to the **VetTail** project:

- [Khtou Younes](https://github.com/traam0/)
- Boukhris Hamza
- Chalabi Nada

## Instructor

This project was developed under the guidance of **Ettazarini Younes**.
