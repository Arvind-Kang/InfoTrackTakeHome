# Infotrack Take Home

## Overview
This project is a web application built with a C# API, Vue.js front end, and Entity Framework for data management. The application lets a user create a Google search query for the top 100 results and track the
positions of a url in the search rankings. The application also lets the user see a history of past searches.

## Technologies Used
- **Back End**: C#, ASP.NET Core
- **Front End**: Vue.js
- **Database**: SQL Server, Entity Framework Core
- **Other**:, Swagger

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js and npm](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository**

2. **Configure the connection string** in `appsettings.json` in the Server project:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=(localdb)\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

3. **Apply Entity Framework migrations**
    ```
    cd InfoTrackTakeHome.Server
    dotnet ef database update
    ```  

4. **Set up the front end**
    ```bash
    cd ../infotracktakehome.client
    npm install
    ```
    
4.**Ensure Startup Configuration matches the image**
![image](https://github.com/user-attachments/assets/f486ec5d-fd46-4555-9417-005d450d4a77)

5.**Press Start in the IDE and both the API and Frontend should launch**

6.
   The API will be running at `https://localhost:7044`.
   The front end will be running at `http://localhost:5173`.


## API Documentation
The API uses Swagger for documentation. Once the API is running, you can access the Swagger UI at `https://localhost:7044/swagger`.


