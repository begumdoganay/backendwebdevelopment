📚 Dvdrental SQL Queries Project ✨
🌟 Introduction
Welcome to the dvdrental SQL Queries Project! This repository contains SQL queries designed to interact with the dvdrental database, showcasing various operations such as data retrieval using joins. This document aims to provide an overview of the project, including the structure of tables, example queries, and how to run them.

📋 Table of Contents
Project Overview
Database Schema
SQL Queries
1. City and Country Join
2. Customer and Payment Join
3. Customer and Rental Join
Running the Queries
Conclusion
📂 Project Overview
The dvdrental database is a sample database that contains information about rental movies, customers, payments, and related entities. This project focuses on writing SQL queries to retrieve meaningful data from the database using different join operations.

🗃️ Database Schema
The relevant tables in the dvdrental database include:

CITY: Contains information about cities.
city_id: Identifier for the city
city: Name of the city
country_id: Identifier for the country
COUNTRY: Contains information about countries.
country_id: Identifier for the country
country: Name of the country
CUSTOMER: Contains information about customers.
customer_id: Identifier for the customer
first_name: Customer's first name
last_name: Customer's last name
PAYMENT: Contains payment transaction details.
payment_id: Identifier for the payment
customer_id: Identifier for the customer who made the payment
RENTAL: Contains rental transaction details.
rental_id: Identifier for the rental
customer_id: Identifier for the customer who made the rental
📝 SQL Queries
1. City and Country Join
sql

Copy
SELECT 
    city.city AS city_name, 
    country.country AS country_name
FROM 
    city
INNER JOIN 
    country ON city.country_id = country.country_id;
This query retrieves city names along with their corresponding country names.

2. Customer and Payment Join
sql

Copy
SELECT 
    customer.first_name, 
    customer.last_name, 
    payment.payment_id
FROM 
    customer
INNER JOIN 
    payment ON customer.customer_id = payment.customer_id;
This query retrieves customer names along with their payment IDs.

3. Customer and Rental Join
sql

Copy
SELECT 
    customer.first_name, 
    customer.last_name, 
    rental.rental_id
FROM 
    customer
INNER JOIN 
    rental ON customer.customer_id = rental.customer_id;
This query retrieves customer names along with their rental IDs.

🏃 Running the Queries
To run these queries:

Ensure you have access to the dvdrental database.
Use a SQL client (e.g., MySQL Workbench, pgAdmin) to connect to the database.
Copy and paste the desired query into the query editor.
Execute the query to view the results.
