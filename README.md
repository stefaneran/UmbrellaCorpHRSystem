# Umbrella Corp HR System

This is the HR System used by Umbrella Corp to manage the employees in their secret underground facillity where they conduct experiments to develop bio-weapons to be sold to the highest bidder.
You are Claire Redfield, the new HR assistant. You start as a regular User but you will gain the abillity to ascend into Admin role. 
As a regular user you can check emails, interact with the employee list and look at the status of the office.
Some views in the application will be different based on whether the user is an Admin or not.

## Technologies used

- ASP.NET Core 10 MVC
- Entity Framework Core 10 + SQL Server (LocalDB)
- ASP.NET Core Identity (authentication + Admin role)
- Razor views, partial views, a view component
- Bootstrap 5

## Features

- View the company bulletin board in the home page.
- Check emails, send and receive email threads, reply within threads, and delete threads.
- See num of unread emails and which emails are unread
- View the list of employees in a paginated view, create new employees, edit and delete existing ones.
- Check the office status, throw a pizza party and, if necessary, initiate the self destruct protocol.
- Server-side form validation
- Role-based views

## Configuration and credentials
All important configurations can be found in appsettings.json:

- ConnectionStrings:DefaultConnection - The LocalDB database
- SeedUsers:ClairePassword - The password with which to log into the existing pre-seeded user
- Admin:ElevationPassword - The password used to elevate the user to admin status (also initiate self destruct)

## Prerequisites 

Visual Studio version that supports .NET 10 with installed SQL Server LocalDB

## Setup

1) Open the UmbrellaCorpHRSystem.slnx file with Visual Studio 
2) Build the solution (Ctrl+Shift+B) so all NuGet packages are restored
3) Run `Update-Database` in the Package Manager Console to apply migrations
3a) Alternatively if `Update-Database` fails, try to run `dotnet ef database update` in the terminal
4) Run the project (Press F5)

## Logging in and the plot
You have an account in the HR System. As Claire Redfield, the new HR assistant, you can log in using your credentials:

- Email: claireredfield@umbrellacorp.com
- Pass: Racoon1998

You will be able to access the application as a basic user after log in.

Once you log in, make sure to check your emails for your responsibilities, if you follow them you will find a way to get the Admin role.

If you do not want to discover the Admin role through the narrative plot, here is the plot including the password
<details>
<summary>Spoiler: Admin access</summary>

After throwing the pizza party, most of the office will be infected which will prompt Wesker to send you an email with the elevation password.
Go to **Elevate Access** and enter `ARKLAYPROTOCOL`.
Successful elevation will redirect you to Office/Index page where as admin you will see the real status, and an option to initiate self destruct protocol.
The password for self destruct is the same as elevation (`ARKLAYPROTOCOL`).
If you want to reverse the office state, you can press `Heal Office` in Office/Index page

</details>

## Project Structure

### Main parts of the project
- Home: has Views and Controller
- Email: has Views, Controller, Service, and Data Configuration/Seed
- Employees: has Views, Controller, Service, and Data Configuration/Seed
- Office: has Views, Controller and Service
- Director: is a Service
- Identity: has scaffolding and Data Seed

### Models
The project uses 4 types of models:

1. Entity - The main model for the entities we keep in the database which serve as an instruction for the database on how to structure the tables and columns and relationships.
2. Dto - Binding models used for forms to validate data and return back to invalid forms with prefilled data so user won't have to type again.
3. ViewModel - The model that the Views expect for showing only the data it needs to know about
4. Enums - Value types

### Controllers
Each part of the application has it's own controller which either returns a View or checks ModelState and decides to return the same view if it's invalid with the same DTO.
Controllers do not perform any business logic, they call the services for that. 
They are also protected with the [Authorize] decorators to prevent unauthenticated or unauthorized users from accessing some controller actions.
Each controller also uses the [HttpGet] or [HttpPost] decorators depending on the type of the action.

### Services
The services contain the business logic that interact with the DB context for CRUD operations. 
Some services also use UserManager and SignInManager for certain actions and to modify the user's role.
Each service has a corresponding interface which outlines it's method implementations.

### Views and Partials
The Razor views display information with link/forms for the user to trigger operations or change views. 
Some views will contain different information based on whether the user has the Admin role (which means they have clearance to see that sensitive info). 
Views also leverage the use of Partials to prevent repetition of code.

### Data
The project contains Data configurations for the DB sets so that the project can know the relationships between the tables and prefill them with initial data which comes from the data seeds.
Not including Identity related entities, the project has 3 main entities:

1. EmailThread (One-to-Many relationship with EmailMessage)
2. EmailMessage
3. Employee

### Constants
Contains just one constant, which is the Role type. 

### ViewComponents
Contains one component for displaying number of unread emails because that was the only way to call a service to display the result in _Layout.cshtml
