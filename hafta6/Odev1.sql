-- 1. Query: Film kiralama ücretine göre filtreleme
-- Bu sorgu, belirli bir fiyat aralığındaki tüm filmleri listeler
-- Örneğin: 2.99-4.99 arası kiralık filmler
SELECT *
FROM film
WHERE rental_rate BETWEEN 2.99 AND 4.99;

-- 2. Query: Belirli isimlere sahip aktörleri listeleme
-- Bu sorgu, verilen isim listesine sahip aktörleri getirir
-- Örnek: Popüler aktörleri listelemek için
SELECT first_name, last_name 
FROM actor
WHERE first_name IN ('Nick', 'Penelope', 'Ed');

-- 3. Query: Çoklu koşulla film filtreleme
-- Bu sorgu, hem kiralama ücreti hem de değiştirme maliyetine göre filmleri bulur
SELECT title, rental_rate, replacement_cost
FROM film
WHERE 
    rental_rate IN (0.99, 2.99, 4.99)
    AND
    replacement_cost IN (12.99, 15.99, 28.99);

-- 4. Query: Film uzunluğu ve kiralama ücreti filtrelemesi
-- Bu sorgu, film uzunluğu ve kiralama ücretine göre filmleri filtreler
SELECT 
    title,
    length,
    rental_rate
FROM film
WHERE 
    length BETWEEN 60 AND 120
    AND
    rental_rate IN (2.99, 4.99);

-- 5. Query: Tarih aralığına göre kiralama filtreleme
-- Bu sorgu, belirli tarih aralığındaki kiralamaları listeler
SELECT 
    rental_id,
    rental_date,
    customer_id,
    return_date
FROM rental
WHERE 
    rental_date BETWEEN '2005-05-24' AND '2005-05-31';