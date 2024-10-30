🌟 Introduction
Welcome to the SQL Joins Project! This repository contains SQL queries demonstrating various types of joins in relational databases. The focus is on retrieving data from multiple tables using different join operations, including LEFT JOIN, RIGHT JOIN, and FULL JOIN.

📋 Table of Contents
Project Overview
Database Schema
SQL Queries
City and Country Join
Customer and Payment Join
Customer and Rental Join
Running the Queries
Conclusion
📂 Project Overview
The SQL Joins Project illustrates how to combine data from multiple tables using SQL joins. Each query demonstrates a different type of join to showcase various data retrieval techniques.

🗃️ Database Schema
The relevant tables in this project include:

CITY: Contains city information.
city_id: Identifier for the city
city: Name of the city
country_id: Identifier for the country
COUNTRY: Contains country information.
country_id: Identifier for the country
country: Name of the country
CUSTOMER: Contains customer information.
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
City and Country Join

SELECT 
    city.city AS city_name, 
    country.country AS country_name
FROM 
    city
LEFT JOIN 
    country ON city.country_id = country.country_id;
This query retrieves city names along with their corresponding country names; if a city has no associated country, the city information is still displayed.

Customer and Payment Join

SELECT 
    customer.first_name, 
    customer.last_name, 
    payment.payment_id
FROM 
    customer
RIGHT JOIN 
    payment ON customer.customer_id = payment.customer_id;
This query retrieves all payment records along with the names of customers associated with each payment; if a payment has no associated customer, the payment information is still displayed.

Customer and Rental Join

SELECT 
    customer.first_name, 
    customer.last_name, 
    rental.rental_id
FROM 
    customer
FULL JOIN 
    rental ON customer.customer_id = rental.customer_id;
This query retrieves both customer names and rental IDs; it includes all records from both tables, even if there is no match in one of the tables.

🏃 Running the Queries
To run these queries:

Ensure you have access to the relevant database.
Use a SQL client (e.g., MySQL Workbench, pgAdmin) to connect to the database.
Copy and paste the desired query into the query editor.
Execute the query to view the results.
