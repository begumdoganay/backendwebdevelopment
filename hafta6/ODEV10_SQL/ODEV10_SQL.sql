-- 1. City ve Country Tablosu ile LEFT JOIN:
-- Şehir ve ülke isimlerini birleştirir; eğer şehir için ülke yoksa, şehir bilgisi yine de gösterilir.
SELECT 
    city.city AS city_name,       -- Şehir adını seçer ve city_name olarak adlandırır
    country.country AS country_name -- Ülke adını seçer ve country_name olarak adlandırır
FROM 
    city
LEFT JOIN 
    country ON city.country_id = country.country_id; -- Eşleşen kayıtları birleştirir

-- 2. Customer ve Payment Tablosu ile RIGHT JOIN:
-- Ödeme bilgilerini içeren tüm kayıtları ve her bir ödeme ile ilişkili müşteri isimlerini döndürür; 
-- eğer bir ödeme için müşteri yoksa, ödeme bilgileri yine de gösterilir.
SELECT 
    customer.first_name,          -- Müşterinin adını seçer
    customer.last_name,           -- Müşterinin soyadını seçer
    payment.payment_id            -- Ödeme ID'sini seçer
FROM 
    customer
RIGHT JOIN 
    payment ON customer.customer_id = payment.customer_id; -- Eşleşen kayıtları birleştirir

-- 3. Customer ve Rental Tablosu ile FULL JOIN:
-- Hem müşteri bilgilerini hem de kiralama bilgilerini döndürür; 
-- her iki tablodan da eksik olan kayıtlar dahil edilir.
SELECT 
    customer.first_name,          -- Müşterinin adını seçer
    customer.last_name,           -- Müşterinin soyadını seçer
    rental.rental_id              -- Kiralama ID'sini seçer
FROM 
    customer
FULL JOIN 
    rental ON customer.customer_id = rental.customer_id; -- Eşleşen kayıtları birleştirir

-- Açıklamalar:
-- - LEFT JOIN: Soldaki tablodaki tüm kayıtları ve sağdaki tablodan eşleşen kayıtları döndürür.
-- - RIGHT JOIN: Sağdaki tablodaki tüm kayıtları ve soldaki tablodan eşleşen kayıtları döndürür.
-- - FULL JOIN: Her iki tablodaki tüm kayıtları döndürür; eksik olan kayıtlar da dahil edilir.