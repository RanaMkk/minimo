# Minimo

Minimo is a task manager project built on .NET 6 and Entity Framework. It harnesses the latest technology to deliver a responsive and reliable API for managing projects and tasks.

## Key Features

### 1. Project Creation and Collaboration

Users can:

- 1.1 Create projects
- 1.2 Define project details
- 1.3 Set start and end dates
- 1.4 Collaborate by adding team members as collaborators.

### 2. Task Management

Within each project, tasks can be:

- 2.1 Created
- 2.2 Assigned
- 2.3 Tracked.

Tasks include properties such as titles, descriptions, due dates, priorities, and statuses.

### 3. Project Notes

Project-specific notes can be added to provide context and important information.

### 4. Search and Filtering

Efficient search and filtering capabilities enable users to quickly locate projects and tasks.

## Packages to Install

To get started, make sure to install the following packages:

1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.Design
3. Microsoft.EntityFrameworkCore.SqlServer
4. Microsoft.EntityFrameworkCore.Tools

## How to Run the Project Locally

To run Minimo on your local machine, follow these steps:

### Prerequisites

- Install .NET 6 SDK (https://dotnet.microsoft.com/download/dotnet/6.0)
- Install Visual Studio or Visual Studio Code (optional but recommended)

### Clone the Repository

Clone the Minimo repository to your local machine using Git:

```
git clone https://github.com/your-username/minimo.git
```

### Configure the Database

Open the `appsettings.json` file in the project and update the database connection string as needed.

### Migrate the Database

Run the following commands in the project directory to create and apply migrations to the database:

```
dotnet ef migrations add InitialMigration
dotnet ef database update
```

### Build and Run the Application

Use the following commands to build and run the application:

```
dotnet build
dotnet run
```

The application should now be running locally at `https://localhost:5001`.

## Project Sections

The project is divided into several sections:

1. **User Management**
2. **Project Management**
3. **Task Management**
4. **Collaboration and Sharing**

## Future Implementations

**In the future, we plan to implement:**

1. User authentication and authorization.
2. Project comments.
3. Project attachments.
4. User interface improvements.

Feel free to contribute and stay tuned for more updates!
