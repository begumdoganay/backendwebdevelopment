-- Bu sorgu, 'A' ile başlayıp 'a' ile biten ülke adlarını döndürür.
-- Böylece "Afganistan", "Arjantin" gibi ülkeler listelenecektir.
SELECT country 
FROM country
WHERE country LIKE 'A%a';

-- Bu sorgu, en az 6 karakterden oluşan ve 'n' harfi ile biten ülke adlarını getirir.
-- Örneğin; "Almanya", "Hollanda", "Japonya" gibi ülkeler listelenecektir.
SELECT country
FROM country
WHERE LENGTH(country) >= 6
  AND country LIKE '%n';

-- Bu sorgu, film başlıklarında en az 4 adet 't' harfi (büyük/küçük harf duyarsız) geçen filmleri listeler.
-- Böylece "The Matrix", "Letter to My Father" gibi filmler görüntülenecektir.
SELECT title
FROM film
WHERE LOWER(title) LIKE '%t%t%t%t%';

-- Bu sorgu, 'C' ile başlayan, 90 dakikadan uzun, 2.99$ kiralama ücretli filmlerin tüm verilerini döndürür.
-- Örneğin; "Citizen Kane", "Chicago" gibi filmler listelenecektir.
SELECT *
FROM film
WHERE title LIKE 'C%'
  AND length > 90
  AND rental_rate = 2.99;