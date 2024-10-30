-- 1. City ve Country Tablosu: 
-- Şehir ve ülke isimlerini birleştirir. 
-- city.country_id ile country.country_id sütunlarını eşleştirir.
SELECT 
    city.city AS city_name,       -- Şehir adını seçer ve city_name olarak adlandırır
    country.country AS country_name -- Ülke adını seçer ve country_name olarak adlandırır
FROM 
    city
INNER JOIN 
    country ON city.country_id = country.country_id; -- Eşleşen kayıtları birleştirir

-- 2. Customer ve Payment Tablosu: 
-- Müşteri isimleri ile ödeme ID'lerini birleştirir.
-- customer.customer_id ile payment.customer_id sütunlarını eşleştirir.
SELECT 
    customer.first_name,          -- Müşterinin adını seçer
    customer.last_name,           -- Müşterinin soyadını seçer
    payment.payment_id            -- Ödeme ID'sini seçer
FROM 
    customer
INNER JOIN 
    payment ON customer.customer_id = payment.customer_id; -- Eşleşen kayıtları birleştirir

-- 3. Customer ve Rental Tablosu: 
-- Müşteri isimleri ile kiralama ID'lerini birleştirir.
-- customer.customer_id ile rental.customer_id sütunlarını eşleştirir.
SELECT 
    customer.first_name,          -- Müşterinin adını seçer
    customer.last_name,           -- Müşterinin soyadını seçer
    rental.rental_id              -- Kiralama ID'sini seçer
FROM 
    customer
INNER JOIN 
    rental ON customer.customer_id = rental.customer_id; -- Eşleşen kayıtları birleştirir