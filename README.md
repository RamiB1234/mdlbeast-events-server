# MDLBeast Events (Server)

![Events](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/README_Images/mdlBeastLogo.png?raw=true)

This is the server side of the event system. Please check the [front-end repository](https://github.com/RamiB1234/mdlbeast-events-front) as well.

## Introduction
This is the server side for managing the MDLBeast Events. It offers REST APIs to be consumed by a React client.

It's a demo I developed to demonstrate my abilities in the technology stack needed for the Fullstack Engineer technical interview

The system is a simulation for an event/ticketing system that has the following features:
- Browsing currently available events
- Displaying more information about an event
- Purchasing a ticket (actual payment is beyound the scope of the demo)
- Receiving the ticket number by email (Ideally, clients receive a QR code, but I tried to keep things simple)
- Admin log in
- Admins can view all ticket information and whither or not tickets were scanned
- Admins can scan an image to prevent mutiple entries (Meaning simply entering the ticket number, in the real world, ushers would use a QR scanner)

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
  - Note: The frontend is not part of this repository. It exists in the [front-end repository](https://github.com/RamiB1234/mdlbeast-events-front)

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

Visual Studio with the ASP.NET 6 and web development workload is required

1. **Configure the Connection String**:
   - In `appsettings.json`, ensure the connection string is set to use localDB:
     ```json
     "ConnectionStrings": {
       "DefaultValue": "Server=(localdb)\\mssqllocaldb;Database=mdlbeast-events-db;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```
1. **Update the Database**:
   - Ensure that the Entity Framework Core tools are installed.
   - Open the Package Manager Console in Visual Studio.
   - Run the command `Update-Database` to create the localDB and apply the migrations.

3. **Start the Application**:
   - Use Visual Studio to run the application using IIS Express.
   - Navigate to `https://localhost:PORT/swagger` to access the Swagger UI and test the API endpoints.

### Running with Docker and PostgreSQL

1. **Configure the Connection String for the image**:
   - For local migration and updates, use `localhost` in the connection string. 
   - For runtime within containers, use `db`
   - Initially, ensure the connection string has the host name `db`. This is essential for compusing the commands that exist in `docker-compose.yml`
     ```json
     "ConnectionStrings": {
       "DefaultValue": "Host=db;Port=5432;Database=mydatabase;Username=postgres;Password=mysecretpassword"
     }
     ```

2. **Building the image and running the container**:
   - Ensure Docker is installed on your machine.
   - Open `bash` terminal or `Powershell` and navigate to the root folder containing your `docker-compose.yml` file
   - Run `docker-compose up --build` to build an image that contains the application and `PostgreSQL` database and run the container


3. **Configure the Connection String for the migration**:
   - Now set the connection string host name to `localhost`. This is needed to apply the migration to the container db
     ```json
     "ConnectionStrings": {
       "DefaultValue": "Host=localhost;Port=5432;Database=mydatabase;Username=postgres;Password=mysecretpassword"
     }
     ```

4. **Update the Database**:
   - Open the Package Manager Console in Visual Studio.
   - Run the command `Update-Database` to create the localDB and apply the migrations.


Once the services are running, the application is accessible via `http://localhost:8000/`

This setup ensures that you can easily switch between development environments depending on your needs.

## License
The project is released under [MIT](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/LICENSE) License
