-- Aşağıdaki sorgular, dvdrental veri tabanındaki belirli bilgileri almak için tasarlayalım efeniiiim.

-- 1. Farklı Replacement Cost Değerlerini Sıralama
SELECT DISTINCT replacement_cost  -- film tablosundaki benzersiz replacement_cost değerlerini alıyoruz
FROM film  -- film tablosundan verileri alıyoruz
ORDER BY replacement_cost;  -- değerleri artan düzende sıralıyoruz

-- 2. Farklı Replacement Cost Sayısını Bulma
SELECT COUNT(DISTINCT replacement_cost) AS unique_replacement_cost_count  -- benzersiz değerlerin sayısını alıyoruz
FROM film;  -- film tablosunu kullanarak verileri alıyoruz

-- 3. 'T' ile Başlayan ve Rating 'G' Olan Film Sayısı
SELECT COUNT(*) AS title_starting_with_T_and_rating_G  -- 'T' ile başlayan ve 'G' rating'e sahip filmleri sayıyoruz
FROM film  -- film tablosundan verileri alıyoruz
WHERE title LIKE 'T%' AND rating = 'G';  -- başlık 'T' ile başlamalı ve rating 'G' olmalı

-- 4. 5 Karakterden Oluşan Ülke Sayısı
SELECT COUNT(*) AS countries_with_5_characters  -- 5 karakterden oluşan ülkelerin sayısını alıyoruz
FROM country  -- country tablosunu kullanarak verileri alıyoruz
WHERE LENGTH(country) = 5;  -- ülke adı 5 karakter olmalı

-- 5. 'R' veya 'r' ile Biten Şehir Sayısı
SELECT COUNT(*) AS cities_ending_with_R_or_r  -- 'R' veya 'r' ile biten şehirlerin sayısını alıyoruz
FROM city  -- city tablosunu kullanarak verileri alıyoruz
WHERE city LIKE '%R' OR city LIKE '%r';  -- şehir adı 'R' veya 'r' ile bitmeli

-- Bu sorguları çalıştırarak, veri tabanındaki bilgileri daha iyi anlayabiliriz.