# Shopping List
This application is created as part of my ASP.NET Core + React learning journey.

### User Interface
![Shopping List UI](https://github.com/nicholsen-guoziyu/shoppinglist/blob/master/shoppinglist.png?raw=true)


### Functionality
* React UI - CRUD (Create, Read, Update, Delete) of Shopping Item. 
* React UI - Add new Shopping Item dynamically.
* React UI - Filter items using search box
* ASP.NET Core Web API - CRUD (Create, Read, Update, Delete) using LinqToDB to Microsoft SQL Server.


### Technology
The application uses the following libraries:
* CSS Grid Layout
* React
* LinqToDB to Microsoft SQL Server

The frameworks:
* .NET Core 3.1

The IDEs which are being used to develop this application:
* Visual Studio Code for the React frontend
* Visual Studio 2019 16.5.2 for the ASP.NET Core Web API REST Services
* SSMS and Microsoft SQL Server for the backend database


### How to Use
* Run the DatabaseSchema.sql to create the ShoppingList database.
* Run the DataSeed.sql to seed data.
* Open ShoppingList.sln in the shoppinglist-api\ShoppingList folder and press F5 to start the backend REST Services.
* Open shoppinglist-ui folder by using Visual Studio Code and type npm start in the Visual Studio Code Terminal to run the React app. You will see one data will be shown which is based on the data populated in the DataSeed.sql.


### Pending Implementation
* Authentication
* Calendar component
* Form Validation
* Exception Management
* Logging
* Unit Testing
* Deploy to Azure

Thank you and have a nice day. :smiley:
