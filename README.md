# PizzaPlaceAPI

###Database Setup

Configure database and string connection
1. Make sure to create database named "PizzaPlace" in you local SQL Server
1. Open appsettings.json
2. Replace "DefaultConnection" with your local connection string

Guide: 
* Data Source = Local SQL Sever instance 
* Initial Catalog = Name of Database to be used
* User = Username credential of SQL server instance
* Password = Password of your local SQL server instance
* TrustServerCertificate = true/false (optional)
	Set this to true if you can't initialize DB context or retrieve data when local SQL server connection encryption is enabled.




