# 📚 Library Management System - ASP.NET Core MVC Project
Project Documentation: Library Management System
Project Overview:
The Library Management System is an ASP.NET Core MVC web application designed to manage books and authors in a library. This system allows users to perform various operations such as adding, editing, and deleting books and authors. The application follows the MVC (Model-View-Controller) architectural pattern, enabling a clear separation of concerns and maintainability.

Technologies and Tools:
ASP.NET Core MVC: Framework used for building the application.
Entity Framework Core: ORM used for database operations.
SQL Server: Database for storing books and author information.
HTML, CSS, JavaScript: Frontend technologies for creating the user interface.
Bootstrap: Frontend framework for responsive design.
Visual Studio: Integrated Development Environment (IDE) for building and testing the project.
Project Structure:
The project follows a modular approach, dividing responsibilities into models, controllers, views, and view models:

Models:

Book: Represents the book entity with properties such as title, author, genre, publish date, ISBN, and available copies.
Author: Represents the author entity with properties like first name, last name, and date of birth.
ViewModels:

BookViewModel: Used to represent book details on the book-related views (e.g., list, details, create).
AuthorViewModel: Used to represent author details on the author-related views (e.g., list, details, create).
Controllers:

BookController: Handles book-related operations such as listing, adding, editing, and deleting books.
AuthorController: Handles author-related operations such as listing, adding, editing, and deleting authors.
Views:

Book Views: Includes views for listing, displaying details, creating, and editing books.
Author Views: Includes views for listing, displaying details, creating, and editing authors.
Program.cs Configuration:

MVC Setup: Configures MVC services for the application.
Static Files: Serves static files (CSS, JavaScript, etc.) from the wwwroot folder.
Routing Configuration: Ensures that requests are routed to the appropriate controller and action methods.
Application Features:
Book Management:

Add, Edit, Delete, and List Books: Users can manage the books in the library, including adding new books, editing existing ones, and deleting books.
View Book Details: View detailed information about a specific book, such as title, author, genre, and ISBN.
Author Management:

Add, Edit, Delete, and List Authors: Users can manage authors, including adding new authors, editing their details, and deleting them.
View Author Details: View detailed information about an author, such as name, biography, and date of birth.
Layout & Partial Views:

The project utilizes a layout to include common elements like the navbar and footer across all pages.
Partial views are used to avoid code duplication for sections that appear on multiple pages, such as the footer.
MVC Architecture:

The project adheres to the Model-View-Controller (MVC) principles, ensuring a separation of concerns between the data model, user interface, and application logic.
Database Structure:
The application uses a relational database (SQL Server) to store the following entities:

Book table: Contains information about the books (title, author, genre, publish date, ISBN, available copies).
Author table: Contains information about the authors (first name, last name, date of birth).
The Book model has a foreign key relationship with the Author model, indicating which author has written a particular book.

Testing and Extendability:
The project is easily extendable. You can add new features such as:
User authentication and authorization for limiting access to certain parts of the system.
Search and filtering options for both books and authors.
Integration with external systems (e.g., book APIs).
For testing, unit and integration tests can be written to ensure the system behaves as expected. Frameworks like xUnit or NUnit can be used to test the controllers and services.

## 🌟 Project Overview
Welcome to the **Library Management System**! 📖✨  
This is an easy-to-use web application developed with **ASP.NET Core MVC** that allows you to manage books and authors in a library. You can add, edit, delete, and list books and authors with just a few clicks. The app follows the **Model-View-Controller (MVC)** design pattern, making it clean, maintainable, and efficient. 🚀

## 🛠 Technologies Used
This project utilizes the following technologies to ensure it runs smoothly and efficiently:
- **ASP.NET Core MVC** - Framework for building web applications.
- **Entity Framework Core** - ORM used to interact with the database.
- **SQL Server** - Database to store book and author information.
- **HTML, CSS, JavaScript** - Basic web technologies to create the frontend.
- **Bootstrap** - Responsive design framework for better user experience.
- **Visual Studio** - The IDE used to build and run the application.

## ⚙️ Installation Instructions

### 📝 Prerequisites
Before you begin, make sure you have the following installed:
- **.NET 6 or higher** (for running the backend)
- **SQL Server** (for the database)
- **Visual Studio** or **Visual Studio Code** (for editing and running the code)

### 💻 Setup Guide
To get started with the project, follow these simple steps:

1. **Clone the Repository**  
   Start by cloning this repository to your local machine:
   ```bash
   git clone https://github.com/yourusername/LibraryManagementSystem.git

   Open in Visual Studio
Open the cloned project in Visual Studio (or your preferred IDE).

Configure the Database Connection
Update the appsettings.json file with your local SQL Server connection string:

"ConnectionStrings": {
   "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Update the Database
Run the following command to update the database schema:

bash
Copy code
dotnet ef database update
Run the Application
Launch the project with this command:

bash
Copy code
dotnet run
Once everything is set up, you can visit the application in your browser and start managing your library! 🌍

📖 Features
1. 📚 Book Management
Add, Edit, Delete, and List Books: Manage the books in the library.
View Book Details: Get detailed information about each book, such as title, author, genre, and ISBN.
2. ✍️ Author Management
Add, Edit, Delete, and List Authors: Easily manage authors and their details.
View Author Details: Get more information about an author, such as their name and biography.
3. 🖥️ Layout & Partial Views
The project includes a layout that ensures a consistent header, footer, and navigation across all pages.
Partial views are used to keep common elements (like the footer) reusable and maintainable across the app.
4. 🛠️ MVC Architecture
The application is built following the Model-View-Controller (MVC) pattern, ensuring a clear separation between the data, user interface, and application logic.
🗂 Database Structure
This application uses a relational database (SQL Server) to store Book and Author entities. The Book model has a relationship with the Author model, indicating which author has written which book.

🤝 Contributing
We'd love to have you contribute!
Feel free to fork this repository and submit a pull request to add new features or improvements. 💡
If you find any bugs or have suggestions, don't hesitate to open an issue. 🐞

📜 License
This project is licensed under the MIT License. You are free to use, modify, and distribute the code. 😊