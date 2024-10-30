-- 1. Film tablosunda bulunan filmleri rating değerlerine göre gruplayınız.
SELECT rating, COUNT(*) AS film_count  -- Rating ve film sayısını seçiyoruz
FROM film  -- film tablosundan
GROUP BY rating;  -- rating değerine göre grupluyoruz
-- Bu sorgu, her bir rating değeri için film sayısını döndürür.

-- 2. Film tablosunda bulunan filmleri replacement_cost sütununa göre grupladığımızda film sayısı 50'den fazla olan replacement_cost değerini ve karşılık gelen film sayısını sıralayınız.
SELECT replacement_cost, COUNT(*) AS film_count  -- replacement_cost ve film sayısını seçiyoruz
FROM film  -- film tablosundan
GROUP BY replacement_cost  -- replacement_cost değerine göre grupluyoruz
HAVING COUNT(*) > 50;  -- Film sayısı 50'den fazla olan grupları filtreliyoruz
-- Bu sorgu, 50'den fazla filme sahip replacement_cost değerlerini ve film sayılarını döndürür.

-- 3. Customer tablosunda bulunan store_id değerlerine karşılık gelen müşteri sayılarını nelerdir?
SELECT store_id, COUNT(*) AS customer_count  -- store_id ve müşteri sayısını seçiyoruz
FROM customer  -- customer tablosundan
GROUP BY store_id;  -- store_id değerine göre grupluyoruz
-- Bu sorgu, her bir store_id için müşteri sayısını döndürür.

-- 4. City tablosunda bulunan şehir verilerini country_id sütununa göre gruplandırdıktan sonra en fazla şehir sayısı barındıran country_id bilgisini ve şehir sayısını paylaşınız.
SELECT country_id, COUNT(*) AS city_count  -- country_id ve şehir sayısını seçiyoruz
FROM city  -- city tablosundan
GROUP BY country_id  -- country_id değerine göre grupluyoruz
ORDER BY city_count DESC  -- Şehir sayısına göre azalan sırada sıralıyoruz
LIMIT 1;  -- En fazla şehir sayısına sahip olanı alıyoruz
-- Bu sorgu, en fazla şehir sayısına sahip olan country_id bilgisi ve şehir sayısını döndürür.