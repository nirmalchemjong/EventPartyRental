# EventPartyRental

## Description
EventPartyRental is a C# Windows Forms application designed to manage inventory and process rentals for an event supply company. It connects to a local SQL Server database to retrieve available items (furniture, electronics, linens) and calculates rental fees using Object-Oriented Programming principles like inheritance and polymorphism.

## Setup and Run Instructions
1. Clone this repository to your local machine using Visual Studio.
2. Ensure the `.NET desktop development` workload is installed.
3. Right-click the solution in Solution Explorer and select **Restore NuGet Packages** to install `System.Data.SqlClient`.
4. **Database Setup:** Open SQL Server Object Explorer in Visual Studio and recreate the `RentalDB` database on your `(localdb)\MSSQLLocalDB` instance. Create the `Inventory` and `Customers` tables to match the queries in the application.
5. Press **F5** or click **Start** to compile and run the application.

## References and Tools Used
* Visual Studio 2022 Official Documentation
* GitHub Docs for version control
* Generative AI (Gemini) utilized for code structuring advice, debugging compilation errors, and formatting reports.
