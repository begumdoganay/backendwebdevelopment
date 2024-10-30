-- Dvdrental veritabanındaki sorgular

-- 1. Film tablosundaki tüm sütunlardaki verileri,
-- replacement_cost değeri 12.99'dan büyük eşit ve 16.99'dan küçük olma koşuluyla sıralıyoruz.
SELECT * 
FROM film 

WHERE replacement_cost BETWEEN 12.99 AND 16.99;

-- Örnek: 
-- Film A: replacement_cost 12.99
-- Film B: replacement_cost 14.50
-- Film C: replacement_cost 16.00
-- Film D: replacement_cost 17.50
-- Bu sorgu Film A ve Film B'yi döndürecektir.

-- 2. Actor tablosundaki first_name ve last_name sütunlarındaki verileri,
-- first_name 'Alice', 'Bob' veya 'Charlie' olanları seçiyoruz.
SELECT first_name, last_name 
FROM actor 
WHERE first_name IN ('Alice', 'Bob', 'Charlie');

-- Örnek: 
-- Actor 1: first_name 'Alice', last_name 'Smith'
-- Actor 2: first_name 'David', last_name 'Johnson'
-- Actor 3: first_name 'Bob', last_name 'Williams'
-- Actor 4: first_name 'Charlie', last_name 'Brown'
-- Bu sorgu Actor 1 ve Actor 3'ü döndürecektir.

-- 3. Film tablosundaki tüm sütunlardaki verileri,
-- rental_rate 1.99, 3.99 veya 5.99 ve replacement_cost 10.99, 20.99 veya 30.99 olanları seçiyoruz.
SELECT * 
FROM film 
WHERE rental_rate IN (1.99, 3.99, 5.99) 
AND replacement_cost IN (10.99, 20.99, 30.99);

-- Örnek: 
-- Film X: rental_rate 1.99, replacement_cost 10.99
-- Film Y: rental_rate 2.99, replacement_cost 20.99
-- Film Z: rental_rate 3.99, replacement_cost 25.99
-- Bu sorgu Film X ve Film Y'yi döndürecektir.