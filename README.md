# PizzaPlaceAPI

This is an ASP.NET REST API application which the sole purpose is for practice and demonstration. Below are the steps to run this in your local machine.

### Setup

**Configuring database and string connection**

**STEP 1** Make sure to create database named "PizzaPlace" in you local SQL Server
**STEP 2** Open appsettings.json
**STEP 3** Replace "DefaultConnection" with your local connection string

**String value guide**
- Data Source = Local SQL Sever instance 
- Initial Catalog = Name of Database to be used
- User = Username credential of SQL server instance
- Password = Password of your local SQL server instance
- TrustServerCertificate = true/false (optional)
	*Set this to true if you can't initialize DB context or retrieve data when local SQL server connection encryption is enabled.*

**STEP 4** Open Package Manager console
**STEP 5** Type "update-database" and hit ENTER. This will create the entities in your local **PizzaPlace** db

That's it! You should be able to run the app on your machine with those steps. You can utilize Swagger UI too for testing the HTTP methods.




