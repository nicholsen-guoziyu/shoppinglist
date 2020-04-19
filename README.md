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

The framework used in this application:
* .NET Core 3.1

The IDEs which are being used to develop this application:
* Visual Studio Code 1.44.0 for the React frontend
* Microsoft Visual Studio Professional 2019 16.5.2 for the ASP.NET Core Web API REST Services (_**Prerequisite**_)
* SQL Server Management Studio v18.4
* Microsoft SQL Server 2019 Developer Edition for the backend database (_**Prerequisite**_)

The tool used in this application:
* create-react-app

The JavaScript Runtime used by this application:
* Node.js v12.16.1 (installed using NVM for Windows 1.1.7) (_**Prerequisite**_)

### How to Use
* Install the required (_**Prerequisite**_)
* Run the DatabaseSchema.sql to create the ShoppingList database.
* Run the DataSeed.sql to seed data.
* Open ShoppingList.sln in the shoppinglist-api\ShoppingList folder by using Visual Studio 2019 and press F5 to start the backend REST Services.
* Open shoppinglist-ui folder by using Visual Studio Code/any React supported IDE and type npm start in the Visual Studio Code Terminal to run the React app. You will see one data will be shown which is based on the data populated in the DataSeed.sql.


### Pending Implementation
* Authentication
* Calendar component
* Form Validation
* Exception Management
* Logging
* Unit Testing
* Deploy to Azure

Thank you and have a nice day. :smiley:
