# MDLBeast Events (Server)

This is the server side of the event system. Please check the [front-end repository](https://github.com/RamiB1234/mdlbeast-events-front) as well.

## Features

## Technology Stack

This project utilizes a robust set of technologies for development and deployment. Below are the major technologies used:

### Backend
- **ASP.NET Core 6**
  - ![ASP.NET Core 6 Logo](URL_TO_ASPNET_CORE_LOGO)
  - A cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.

### Frontend
- **React**
  - ![React Logo](URL_TO_REACT_LOGO)
  - A JavaScript library for building user interfaces, maintained by Facebook and a community of individual developers and companies.

### Database
- **PostgreSQL**
  - ![PostgreSQL Logo](URL_TO_POSTGRESQL_LOGO)
  - An open source object-relational database system that uses and extends the SQL language combined with many features that safely store and scale the most complicated data workloads.

### Containerization
- **Docker**
  - ![Docker Logo](URL_TO_DOCKER_LOGO)
  - A set of PaaS products that use OS-level virtualization to deliver software in packages called containers.

### Authentication
- **JWT (JSON Web Tokens)**
  - ![JWT Logo](URL_TO_JWT_LOGO)
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


## Running 

### Dockerized Version

### Using IIS Express

## License
The project is released under [MIT](https://github.com/RamiB1234/mdlbeast-events-server/blob/master/LICENSE) License
