📚 Patika BootCamp - Code First Relation Project
Hello! I am Begüm Doğanay. In the 12th week of the Patika BootCamp, we explored the topic of creating a database and designing relationships using the Code First approach. This project demonstrates how to create a relational database using Entity Framework Core. Throughout the project, we focused on establishing a relationship between two tables: Users and Posts. 🚀

🗂️ About the Project
This project showcases the Code First approach, allowing you to define and manage database tables directly through C# classes. Entity Framework Core maps these classes to relational database tables, enabling developers to concentrate on application logic without manually writing SQL scripts.

Database Name: PatikaCodeFirstDb2
Tables:

Users Table 🙍‍♀️
Posts Table 📝
There is a one-to-many relationship between these tables:

A single user can have multiple posts.
Each post belongs to only one user.
🛠️ Database Tables
🙍‍♀️ Users Table
This table stores user details and includes the following columns:

Column	Type	Description
Id	int	Primary Key, Auto-Incremented
Username	string	User's unique username
Email	string	User's email address
📝 Posts Table
This table stores posts created by users and includes the following columns:

Column	Type	Description
Id	int	Primary Key, Auto-Incremented
Title	string	Post title
Content	string	Post content
UserId	int	Foreign Key linked to the Users table
📂 Context Class
The DbContext class manages all database interactions:

Name: PatikaSecondDbContext
Tables:
DbSet<User> Users
DbSet<Post> Posts
Additionally, the relationship between Users and Posts tables is defined using Fluent API or Data Annotations.

🔗 Getting Started
Follow these steps to set up and run this project:

Install Required Packages
Install the necessary NuGet packages for Entity Framework Core:

bash
Copy code
dotnet add package Microsoft.EntityFrameworkCore  
dotnet add package Microsoft.EntityFrameworkCore.SqlServer  
Add a Migration
Define the database schema by adding a migration:

bash
Copy code
dotnet ef migrations add InitialCreate  
Update the Database
Apply the migration to create the database:

bash
Copy code
dotnet ef database update  
🎉 Congratulations! Your database PatikaCodeFirstDb2 with the Users and Posts tables is ready to use!

📝 Notes
Ensure your connection string is properly set in the appsettings.json file or another configuration file.
If the data model changes, create a new migration and update the database:
bash
Copy code
dotnet ef migrations add <NewMigrationName>  
dotnet ef database update  
💡 Why Choose Code First?
Develop your application in a structured, object-oriented manner.
Synchronize database and application structures automatically with migrations.
Focus on business logic instead of SQL-based database setups.
This project has been a fantastic learning experience as part of the Patika BootCamp. If you're working on similar projects or have any questions, feel free to reach out to me! 😊
