-- 1. Film tablosunda bulunan rental_rate sütunundaki değerlerin ortalaması nedir?
SELECT AVG(rental_rate) AS average_rental_rate  -- rental_rate sütununun ortalamasını alıyoruz
FROM film;  -- film tablosundan
-- AVG(rental_rate): rental_rate sütunundaki tüm değerlerin ortalamasını alır.
-- AS average_rental_rate: Sonucu daha anlaşılır hale getirmek için bir takma ad (alias) kullanır.

-- 2. Film tablosunda bulunan filmlerden kaç tanesi 'C' karakteri ile başlar?
SELECT COUNT(*) AS count_of_films_starting_with_C  -- 'C' ile başlayan filmleri sayıyoruz
FROM film  -- film tablosundan
WHERE title LIKE 'C%';  -- Başlangıç karakteri 'C' olan filmleri seçiyoruz
-- COUNT(*): Belirtilen koşula uyan film sayısını döndürür.
-- WHERE title LIKE 'C%': Film isminin 'C' ile başladığı kayıtları filtreler.

-- 3. Film tablosunda bulunan filmlerden rental_rate değeri 0.99'a eşit olan en uzun (length) film kaç dakikadır?
SELECT MAX(length) AS longest_film_length  -- En uzun film süresini buluyoruz
FROM film  -- film tablosundan
WHERE rental_rate = 0.99;  -- rental_rate değeri 0.99 olan filmleri filtreliyoruz
-- MAX(length): length sütunundaki en yüksek değeri bulur.
-- WHERE rental_rate = 0.99: Sadece rental_rate değeri 0.99 olan filmleri dikkate alır.

-- 4. Film tablosunda bulunan filmlerin uzunluğu 150 dakikadan büyük olanlarına ait kaç farklı replacement_cost değeri vardır?
SELECT COUNT(DISTINCT replacement_cost) AS unique_replacement_costs  -- Farklı replacement_cost değerlerini sayıyoruz
FROM film  -- film tablosundan
WHERE length > 150;  -- Uzunluğu 150 dakikadan büyük olan filmleri filtreliyoruz
-- COUNT(DISTINCT replacement_cost): Farklı replacement_cost değerlerini sayar.
-- WHERE length > 150: Sadece 150 dakikadan uzun filmleri dikkate alır.