🌟 Introduction
Welcome to the DVDRental SQL Queries Project! This repository contains SQL queries demonstrating various operations on the dvdrental sample database, focusing on retrieving and manipulating data from the actor and customer tables.

📋 Table of Contents
Project Overview
Database Schema
SQL Queries
All First Names
Intersecting First Names
First Names in Actor but Not in Customer
All First Names with Duplicates
Intersecting First Names with Duplicates
First Names in Actor with Duplicates Not in Customer
Running the Queries
Conclusion
📂 Project Overview
This project demonstrates how to perform various SQL operations using the dvdrental sample database. The focus is on retrieving first_name data from the actor and customer tables through different SQL querying techniques.

🗃️ Database Schema
The relevant tables in this project include:

ACTOR: Contains information about actors.
actor_id: Identifier for the actor
first_name: First name of the actor
last_name: Last name of the actor
CUSTOMER: Contains information about customers.
customer_id: Identifier for the customer
first_name: First name of the customer
last_name: Last name of the customer
📝 SQL Queries
All First Names
sql

Copy
SELECT first_name 
FROM actor 
UNION ALL 
SELECT first_name 
FROM customer 
ORDER BY first_name;
Retrieves all first names from both actor and customer tables, including duplicates.

Intersecting First Names

SELECT first_name 
FROM actor 
INTERSECT 
SELECT first_name 
FROM customer 
ORDER BY first_name;
Retrieves first names that are common to both actor and customer tables.

First Names in Actor but Not in Customer

SELECT first_name 
FROM actor 
EXCEPT 
SELECT first_name 
FROM customer 
ORDER BY first_name;
Retrieves first names that exist in the actor table but not in the customer table.

All First Names with Duplicates

SELECT first_name 
FROM actor 
UNION ALL 
SELECT first_name 
FROM customer 
ORDER BY first_name;
Retrieves all first names from both tables, including duplicates again.

Intersecting First Names with Duplicates

SELECT first_name 
FROM actor 
JOIN customer ON actor.first_name = customer.first_name 
ORDER BY actor.first_name;
Retrieves common first names from both tables, including duplicates.

First Names in Actor with Duplicates Not in Customer

SELECT first_name 
FROM actor 
LEFT JOIN customer ON actor.first_name = customer.first_name 
WHERE customer.first_name IS NULL 
ORDER BY actor.first_name;
Retrieves first names that exist in the actor table and are not found in the customer table, including duplicates.

🏃 Running the Queries
To run these queries:

Ensure you have access to the dvdrental database.
Use a SQL client (e.g., MySQL Workbench, pgAdmin) to connect to the database.
Copy and paste the desired query into the query editor.
Execute the query to view the results.
