-- 1. Uzunluğu Ortalama Film Uzunluğundan Fazla Olan Film Sayısını Bul
SELECT COUNT(*) AS Film_Sayisi  -- Film sayısını sayar
FROM film
WHERE length > (SELECT AVG(length) FROM film);  -- Ortalama film uzunluğundan uzun olanları filtreler

-- 2. En Yüksek Rental Rate Değerine Sahip Film Sayısını Bul
SELECT COUNT(*) AS Film_Sayisi  -- Film sayısını sayar
FROM film
WHERE rental_rate = (SELECT MAX(rental_rate) FROM film);  -- En yüksek rental_rate'e sahip filmleri filtreler

-- 3. En Düşük Rental Rate ve En Düşük Replacement Cost Değerlerine Sahip Filmleri Sıralama
SELECT *  -- Tüm bilgileri seçer
FROM film
WHERE rental_rate = (SELECT MIN(rental_rate) FROM film)  -- En düşük rental_rate'e sahip filmleri filtreler
  AND replacement_cost = (SELECT MIN(replacement_cost) FROM film);  -- En düşük replacement_cost'a sahip filmleri filtreler

-- 4. En Fazla Alışveriş Yapan Müşterileri Sıralama
SELECT customer_id, COUNT(*) AS Alisveris_Sayisi  -- Müşteri kimliği ve alışveriş sayısını seçer
FROM payment
GROUP BY customer_id  -- Müşterilere göre gruplar
ORDER BY Alisveris_Sayisi DESC;  -- Alışveriş sayısına göre azalan sırada sıralar

-- Açıklamalar:
-- 1. İlk sorgu, film uzunluğu ortalamanın üzerinde olan filmleri sayar.
-- 2. İkinci sorgu, en yüksek kiralama oranına sahip filmleri sayar.
-- 3. Üçüncü sorgu, en düşük kiralama oranı ve en düşük yerine koyma maliyetine sahip filmleri döndürür.
-- 4. Son sorgu, en fazla alışveriş yapan müşterileri, alışveriş sayısına göre sıralar.