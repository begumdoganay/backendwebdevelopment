-- Aşağıdaki sorgular, dvdrental veri tabanındaki belirli bilgileri almak için tasarlanmıştır.
-- Her sorgu, belirli kriterlere göre verileri seçmekte ve sıralamaktadır.

-- 1. Film İsimleri 'n' ile Biten En Uzun 5 Filmi Sıralama
SELECT title, length  -- Filmin başlığını ve uzunluğunu seçiyoruz.
FROM film  -- Verilerin alınacağı tablo: film
WHERE title LIKE '%n'  -- Film isminin 'n' ile bitmesini istiyoruz.
ORDER BY length DESC  -- Uzunluğa göre azalan sırada sıralıyoruz, yani en uzun filmler önce gelir.
LIMIT 5;  -- Sadece ilk 5 sonucu almak istiyoruz.

-- 2. Film İsimleri 'n' ile Biten En Kısa İkinci 5 Filmi Sıralama
SELECT title, length  -- Yine film başlığı ve uzunluğunu seçiyoruz.
FROM film  -- Verilerin alınacağı tablo: film
WHERE title LIKE '%n'  -- Film isminin 'n' ile bitmesini istiyoruz.
AND length IN (6, 7, 8, 9, 10)  -- Uzunluğunun 6, 7, 8, 9 veya 10 karakter olmasını istiyoruz.
ORDER BY length ASC  -- Uzunluğa göre artan sırada sıralıyoruz, yani en kısa filmler önce gelir.
LIMIT 5 OFFSET 1;  -- İkinci 5 sonucu almak için ilk sonucu atlayarak 1 kaydırma yapıyoruz.

-- 3. Store ID 1 Olan Customer Tablosunda Last Name'e Göre Azalan Sıralama
SELECT *  -- Tablodaki tüm sütunları seçiyoruz.
FROM customer  -- Verilerin alınacağı tablo: customer
WHERE store_id = 1  -- Sadece store_id'si 1 olan müşteri kayıtlarını seçiyoruz.
ORDER BY last_name DESC  -- Müşterilerin soyadına göre azalan sırada sıralıyoruz, yani A'dan Z'ye.
LIMIT 4;  -- Sadece ilk 4 sonucu almak istiyoruz.

-- Bu sorguları kullanarak dvdrental veri tabanında istenen bilgileri elde edebiliriz.
-- Her sorgu, belirli bir amaca hizmet etmekte ve verileri analiz etmemizi kolaylaştırmaktadır.