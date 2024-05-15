# MDLBeast Events (Server)

![Events](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/mdlBeastLogo.png?raw=true)

This is the server side of the event system. Please check the [front-end repository](https://github.com/RamiB1234/mdlbeast-events-front) as well.

## Features

## Technology Stack

This project utilizes a robust set of technologies for development and deployment. Below are the major technologies used:

### Backend
- **ASP.NET Core 6**
  - ![ASP.NET Core 6 Logo](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/aspnet.PNG?raw=true)
  - A cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.

### Frontend
- **React**
  - ![React Logo](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/react.PNG?raw=true)
  - A JavaScript library for building user interfaces, maintained by Facebook and a community of individual developers and companies.

### Database
- **PostgreSQL**
  - ![PostgreSQL Logo](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/postgre.PNG?raw=true)
  - An open source object-relational database system that uses and extends the SQL language combined with many features that safely store and scale the most complicated data workloads.

### Containerization
- **Docker**
  - ![Docker Logo](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/docker.PNG?raw=true)
  - A set of PaaS products that use OS-level virtualization to deliver software in packages called containers.

### Authentication
- **JWT (JSON Web Tokens)**
  - ![JWT Logo](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/jwt.PNG?raw=true)
  - A compact, URL-safe means of representing claims to be transferred between two parties, allowing the use of bearer tokens to verify the end user.


## Endpoints

### EventController Endpoints

| HTTP Method | Endpoint | Parameters | Return JSON   | Description          | Authentication Required |
|-------------|----------|------------|---------------|----------------------|-------------------------|
| GET         | /event   | None       | List of Events| Retrieves all events | No                      |

### TicketController Endpoints

| HTTP Method | Endpoint | Parameters  | Return JSON | Description                                | Authentication Required |
|-------------|----------|-------------|-------------|--------------------------------------------|-------------------------|
| POST        | /ticket  | Ticket body | Status Code | Saves ticket and sends confirmation email  | No                      |
| GET         | /ticket  | None        | List of Tickets | Retrieves all tickets                   | Yes                     |
| PATCH       | /ticket  | Ticket body | Status Code | Updates ticket status as scanned           | Yes                     |

### AuthController Endpoints

| HTTP Method | Endpoint   | Parameters       | Return JSON      | Description                         | Authentication Required |
|-------------|------------|------------------|------------------|-------------------------------------|-------------------------|
| POST        | /auth/login| User credentials | JSON with Token  | Authenticates user and returns JWT  | No                      |

**Notes:**
- **Parameters**: Add further details about required parameters as needed.
- **Return JSON**: Describe the JSON structure returned by endpoints where applicable.
- **Authentication Required**: Indicates whether an endpoint requires authentication.


## Running the Application

This application can be run in two environments: locally using IIS Express and a localDB, or using Docker containers with a PostgreSQL database.

### Running Locally with IIS Express and localDB

1. **Update the Database**:
   - Ensure that the Entity Framework Core tools are installed.
   - Open the Package Manager Console in Visual Studio.
   - Run the command `Update-Database` to apply the migrations to your localDB.
   
2. **Configure the Connection String**:
   - In `appsettings.json`, ensure the connection string is set to use localDB:
     ```json
     "ConnectionStrings": {
       "DefaultValue": "Server=(localdb)\\mssqllocaldb;Database=mdlbeast-events-db;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

3. **Start the Application**:
   - Use Visual Studio to run the application using IIS Express.
   - Navigate to `https://localhost:PORT/swagger` to access the Swagger UI and test the API endpoints.

### Running with Docker and PostgreSQL

1. **Configure the Connection String**:
   - For local migration and updates, use `localhost` in the connection string. For runtime within containers, use `db`:
     ```json
     "ConnectionStrings": {
       "DefaultValue": "Host=db;Port=5432;Database=mydatabase;Username=postgres;Password=mysecretpassword" // Use 'Host=localhost' for local migration
     }
     ```

2. **Docker Compose**:
   - Ensure Docker is installed on your machine.
   - Navigate to the directory containing your `docker-compose.yml` file.
   - Run the following command to start all services:
     ```bash
     docker-compose up
     ```
   - Once the services are running, the application is accessible via `http://localhost:8000/swagger`.

### Updating Database Migrations

To apply migrations to the PostgreSQL database when running in Docker:
- Use `docker-compose exec app bash` to access the app's container shell.
- Run migration commands within the container if necessary, or directly from your machine pointing to the PostgreSQL service exposed on `localhost`.

This setup ensures that you can easily switch between development environments depending on your needs.


## License
The project is released under [MIT](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/LICENSE) License
