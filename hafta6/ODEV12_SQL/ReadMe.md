SQL Basic Queries
This repository contains a set of SQL queries that solve various database-related challenges. The queries are written in MySQL and are accompanied by detailed explanations.

English
1. Find the Number of Films with Length Greater than the Average Film Length
This query retrieves the count of films whose length is greater than the average film length.

-- 1. Find the Number of Films with Length Greater than the Average Film Length
SELECT COUNT(*) AS Film_Sayisi  -- Count the number of films
FROM film
WHERE length > (SELECT AVG(length) FROM film);  -- Filter films with length greater than the average
2. Find the Number of Films with the Highest Rental Rate
This query retrieves the count of films that have the highest rental rate.

-- 2. Find the Number of Films with the Highest Rental Rate
SELECT COUNT(*) AS Film_Sayisi  -- Count the number of films
FROM film
WHERE rental_rate = (SELECT MAX(rental_rate) FROM film);  -- Filter films with the maximum rental rate
3. List the Films with the Lowest Rental Rate and Replacement Cost
This query retrieves all the details of the films that have the lowest rental rate and the lowest replacement cost.

-- 3. List the Films with the Lowest Rental Rate and Replacement Cost
SELECT *  -- Select all columns
FROM film
WHERE rental_rate = (SELECT MIN(rental_rate) FROM film)  -- Filter films with the minimum rental rate
  AND replacement_cost = (SELECT MIN(replacement_cost) FROM film);  -- Filter films with the minimum replacement cost
4. List the Customers with the Most Purchases
This query retrieves the customer IDs and the count of their purchases, sorted in descending order by the purchase count.

-- 4. List the Customers with the Most Purchases
SELECT customer_id, COUNT(*) AS Alisveris_Sayisi  -- Select customer ID and the count of purchases
FROM payment
GROUP BY customer_id  -- Group by customer ID
ORDER BY Alisveris_Sayisi DESC;  -- Sort in descending order by the purchase count
Türkçe
1. Ortalama Film Uzunluğundan Uzun Olan Filmlerin Sayısını Bul
Bu sorgu, film uzunluğu ortalama film uzunluğundan daha uzun olan filmlerin sayısını getirir.

-- 1. Ortalama Film Uzunluğundan Uzun Olan Filmlerin Sayısını Bul
SELECT COUNT(*) AS Film_Sayisi  -- Film sayısını sayar
FROM film
WHERE length > (SELECT AVG(length) FROM film);  -- Ortalama film uzunluğundan uzun olanları filtreler
2. En Yüksek Kiralama Oranına Sahip Filmlerin Sayısını Bul
Bu sorgu, en yüksek kiralama oranına sahip filmlerin sayısını getirir.

-- 2. En Yüksek Kiralama Oranına Sahip Filmlerin Sayısını Bul
SELECT COUNT(*) AS Film_Sayisi  -- Film sayısını sayar
FROM film
WHERE rental_rate = (SELECT MAX(rental_rate) FROM film);  -- En yüksek rental_rate'e sahip filmleri filtreler
3. En Düşük Kiralama Oranı ve Yerine Koyma Maliyetine Sahip Filmleri Listele
Bu sorgu, en düşük kiralama oranına ve en düşük yerine koyma maliyetine sahip tüm film ayrıntılarını getirir.

-- 3. En Düşük Kiralama Oranı ve Yerine Koyma Maliyetine Sahip Filmleri Listele
SELECT *  -- Tüm bilgileri seçer
FROM film
WHERE rental_rate = (SELECT MIN(rental_rate) FROM film)  -- En düşük rental_rate'e sahip filmleri filtreler
  AND replacement_cost = (SELECT MIN(replacement_cost) FROM film);  -- En düşük replacement_cost'a sahip filmleri filtreler
4. En Fazla Alışveriş Yapan Müşterileri Listele
Bu sorgu, müşteri kimliklerini ve alışveriş sayılarını, alışveriş sayısına göre azalan sırada getirir.

-- 4. En Fazla Alışveriş Yapan Müşterileri Listele
SELECT customer_id, COUNT(*) AS Alisveris_Sayisi  -- Müşteri kimliği ve alışveriş sayısını seçer
FROM payment
GROUP BY customer_id  -- Müşterilere göre gruplar
ORDER BY Alisveris_Sayisi DESC;  -- Alışveriş sayısına göre azalan sırada sıralar
