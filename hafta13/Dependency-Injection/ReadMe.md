# Dependency Injection Sample Project

This project demonstrates how to implement Dependency Injection principles in C# through a simple teacher and classroom management scenario. It serves as an educational example of how to properly implement dependency injection using constructor injection.

## 📚 About The Project

This sample project includes the following core components:
- `ITeacher` (Interface)
- `Teacher` (Concrete Class)
- `Classroom` (Dependent Class)

### Project Structure

```
Week-13-DependencyInjection.ConsoleApp/
├── ITeacher.cs
├── Teacher.cs
├── Classroom.cs
├── Program.cs
└── Week-13-DependencyInjection.ConsoleApp.csproj
```

## 🛠️ Technical Details

### ITeacher Interface
The interface defines the basic contract for the teacher class:
```csharp
public interface ITeacher
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Branch { get; set; }
    string GetInfo();
    string GetFullName();
    string GetBranch();
}
```

### Teacher Class
Concrete class implementing the ITeacher interface:
```csharp
public class Teacher : ITeacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Branch { get; set; }
    // ... other methods
}
```

### Classroom Class
Example of Constructor Injection:
```csharp
public class Classroom
{
    private readonly ITeacher _teacher;
    private readonly string _className;

    public Classroom(ITeacher teacher, string className)
    {
        _teacher = teacher;
        _className = className;
    }
    // ... other methods
}
```

## 🚀 How to Run

1. Open the project in Visual Studio
2. Right-click on the project in Solution Explorer
3. Select "Set as Startup Project"
4. Press F5 or click the "Start" button to run the project

## 📋 Usage Example

```csharp
// Create a teacher instance
ITeacher teacher = new Teacher("John", "Doe", "Mathematics");

// Create a classroom instance and inject the teacher
Classroom classroom = new Classroom(teacher, "12-A");

// Display information
Console.WriteLine(classroom.GetTeacherInfo());
```

## 🎯 Benefits of Dependency Injection

1. **Loosely Coupled Code**
   - Reduces dependencies between classes
   - Makes code more modular

2. **Easy Testing**
   - Enables unit testing with mock objects
   - Simplifies test writing process

3. **Code Flexibility**
   - Easy to add new implementations
   - Extendable without modifying existing code

4. **Maintenance Benefits**
   - Easier code maintenance
   - Isolated changes

## 🔍 Features

- Teacher information management
- Classroom-teacher relationship
- Comprehensive error handling
- Detailed parameter validation
- Rich methods and properties

## ⚠️ Error Handling

The project throws appropriate error messages in the following cases:
- Null teacher object
- Empty teacher first/last name
- Empty classroom name
- Invalid branch information

## 🔄 Development Process

1. Interface definition
2. Concrete class implementation
3. Dependency Injection implementation
4. Error handling
5. Testing and validation

## 💡 Key Concepts Demonstrated

1. **Interface Segregation**
   - Clean interface definition
   - Focused responsibilities

2. **Constructor Injection**
   - Dependencies injected through constructor
   - Clear dependency requirements

3. **Encapsulation**
   - Private fields
   - Public methods
   - Information hiding

4. **Validation**
   - Input parameter checking
   - Null checks
   - Error handling

## 📝 Note

This project is created for learning and demonstrating Dependency Injection principles. For real-world projects, it's recommended to use comprehensive DI frameworks (e.g., Microsoft.Extensions.DependencyInjection).

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'feat: Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 🔬 Testing

To test the application:
1. Run the program
2. Check different scenarios:
   - Valid teacher and classroom creation
   - Error handling for invalid inputs
   - Different teacher-classroom combinations

## 🎓 Learning Outcomes

After studying this project, you should understand:
- Basic Dependency Injection principles
- Interface-based programming
- Constructor injection pattern
- Error handling best practices
- C# coding standards

## 📫 Contact

For questions, please use the Issues section or feel free to fork the project and contribute to its development.

## 📚 Additional Resources

- [Microsoft Dependency Injection Documentation](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [SOLID Principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#solid)