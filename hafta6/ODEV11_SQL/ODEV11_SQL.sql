-- 1. Actor ve Customer Tablolarında Bulunan first_name Sütunları için Tüm Verileri Sıralama
SELECT first_name 
FROM actor 
UNION ALL  -- Her iki tabloda tekrar eden değerleri korur
SELECT first_name 
FROM customer 
ORDER BY first_name;  -- Sonuçları first_name'e göre sıralar

-- 2. Actor ve Customer Tablolarında Bulunan first_name Sütunları için Kesişen Verileri Sıralama
SELECT first_name 
FROM actor 
INTERSECT  -- Her iki tabloda bulunan ortak değerleri alır
SELECT first_name 
FROM customer 
ORDER BY first_name;  -- Sonuçları first_name'e göre sıralar

-- 3. Actor Tablosunda Bulunan Ancak Customer Tablosunda Bulunmayan Verileri Sıralama
SELECT first_name 
FROM actor 
EXCEPT  -- İlk tabloda olup ikincisinde olmayan değerleri alır
SELECT first_name 
FROM customer 
ORDER BY first_name;  -- Sonuçları first_name'e göre sıralar

-- 4. İlk 3 Sorguyu Tekrar Eden Veriler için Yapma

-- 4.1. Tüm Verileri Tekrar Edenler için Sıralama
SELECT first_name 
FROM actor 
UNION ALL  -- Her iki tabloda tekrar eden değerleri korur
SELECT first_name 
FROM customer 
ORDER BY first_name;  -- Sonuçları first_name'e göre sıralar

-- 4.2. Kesişen Verileri Tekrar Edenler için Sıralama
SELECT first_name 
FROM actor 
JOIN customer ON actor.first_name = customer.first_name  -- Ortak değerleri bulur
ORDER BY actor.first_name;  -- Sonuçları first_name'e göre sıralar

-- 4.3. İlk Tabloda Bulunan Ancak İkinci Tabloda Bulunmayan Tekrar Edenler için Sıralama
SELECT first_name 
FROM actor 
LEFT JOIN customer ON actor.first_name = customer.first_name  -- Tüm actor kayıtlarını alır
WHERE customer.first_name IS NULL  -- Customer'da olmayanları filtreler
ORDER BY actor.first_name;  -- Sonuçları first_name'e göre sıralar