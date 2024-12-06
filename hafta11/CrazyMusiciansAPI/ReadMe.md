# Crazy Musicians API

Welcome to the **Crazy Musicians API**, a fun and dynamic project designed to manage a dataset of quirky, fictional musicians. Built using **ASP.NET Core Web API**, this API demonstrates the power of modern web development while embracing humor and creativity.

---

## 🚀 Project Overview

The Crazy Musicians API allows you to interact with a collection of eccentric musicians, each with their own distinctive traits. With this API, you can:

- Retrieve a list of musicians.
- Search for musicians by name.
- Add new musicians to the dataset.
- Update existing musician records.
- Delete musicians who no longer deserve the spotlight.

---

## ✨ Features

1. **Comprehensive CRUD Operations**
   - `GET`: Fetch all musicians or search by name.
   - `POST`: Add new musicians with validation.
   - `PUT`: Update musician records entirely.
   - `PATCH`: Update specific attributes like quirky traits.
   - `DELETE`: Remove musicians from the dataset.

2. **Advanced Routing**
   Routes are structured with clarity and extensibility, inspired by the "Galactic Tour" routing style. Flexible and dynamic endpoints make this API user-friendly.

3. **Input Validation**
   - Ensures that all provided data is valid.
   - Returns descriptive error messages for invalid inputs.

4. **Dynamic Query Support**
   - Includes a `[FromQuery]` implementation for searching musicians dynamically by name or other attributes.

5. **English-Only Implementation**
   - Code and documentation are provided in English for global accessibility.

---

## 🎯 Objectives

This project was built to:

- Practice advanced API development with **ASP.NET Core Web API**.
- Demonstrate routing techniques inspired by real-world use cases.
- Apply robust validation to protect data integrity.
- Highlight the usage of `[FromQuery]` for flexible and user-friendly search functionalities.

---

## 📝 Dataset

Meet the musicians managed by this API:

| ID  | Name           | Profession              | Quirky Trait                                                         |
|-----|----------------|-------------------------|-----------------------------------------------------------------------|
| 1   | Ahmet Çalgı    | Famous Instrument Player | Always plays the wrong notes but is highly entertaining.              |
| 2   | Zeynep Melodi  | Popular Melody Writer   | Misunderstands songs but remains very popular.                        |
| 3   | Cemil Akor     | Crazy Chordist          | Frequently changes chords, yet surprisingly talented.                 |
| 4   | Fatma Nota     | Surprise Note Producer  | Constantly creates musical surprises.                                 |
| 5   | Hasan Ritmi    | Rhythm Maverick         | Plays unique, comically mismatched rhythms.                           |
| 6   | Elif Armoni    | Harmony Expert          | Occasionally creates wrong harmonies but is extremely creative.        |
| 7   | Ali Perde      | Curtain Innovator       | Innovatively uses curtains, always surprising the audience.           |
| 8   | Ayşe Rezonans  | Resonance Specialist      | Produces incredible sounds, sometimes causing loud resonance.          |
| 9   | Murat Ton      | Tone Enthusiast         | Enjoys tonal variations, often in humorous ways.                      |
| 10  | Selin Akor     | Chord Wizard            | Creates magical atmospheres with unique chord changes.                |

---

## 🛠️ Requirements

- **ASP.NET Core**: Framework for Web API development.
- **Dynamic Routing**: Inspired by the "Galactic Tour" application.
- **Validation**: Ensures valid data entry and protects the integrity of the dataset.
- **Query Parameters**: Demonstrates `[FromQuery]` usage for dynamic filtering.

---

## 📂 Folder Structure

- **Controllers**: Manages API logic and routing.
- **Models**: Defines the data structure for musicians.
- **Data**: Contains static data simulating a database.
- **Services**: (Optional) Can handle business logic.

---

## 🚦 Usage Instructions

1. **Clone the Repository**
   Clone this project to your local machine using Git:

   ```bash
   git clone https://github.com/begumdoganay/crazy-musicians-api.git
   ```

2. **Build and Run the Project**
   Open the project in Visual Studio or use the .NET CLI:

   ```bash
   dotnet build
   dotnet run
   ```

3. **Explore the API**
   Use tools like **Postman** or **Swagger** to test the API endpoints. Endpoints include:
   - `GET /api/musicians`: Fetch all musicians.
   - `GET /api/musicians/search?name={name}`: Search musicians by name.
   - `POST /api/musicians`: Add a new musician.
   - `PUT /api/musicians/{id}`: Update an entire musician record.
   - `PATCH /api/musicians/{id}`: Update a specific musician attribute.
   - `DELETE /api/musicians/{id}`: Remove a musician.

4. **Experiment and Have Fun!**
   Add, modify, and delete musicians to explore all the features of this quirky API.

---

## 🎉 Conclusion

The **Crazy Musicians API** is a great way to dive into API development while having fun with a creative dataset. Feel free to expand upon this project and customize it to suit your needs. Happy coding!