📊 İçindekiler
Giriş
Sorgu Senaryoları
1. Rental Rate Ortalaması
2. 'C' ile Başlayan Film Sayısı
3. En Uzun Rental Rate Değeri 0.99 Olan Film
4. 150 Dakikadan Uzun Filmlerin Farklı Replacement Cost Değerleri
Sonuç
Görseller
📝 Sorgu Senaryoları
1. Rental Rate Ortalaması
sql

Copy
SELECT AVG(rental_rate) AS average_rental_rate  -- rental_rate sütununun ortalamasını alıyoruz
FROM film;  -- film tablosundan
-- AVG(rental_rate): rental_rate sütunundaki tüm değerlerin ortalamasını alır.
-- AS average_rental_rate: Sonucu daha anlaşılır hale getirmek için bir takma ad (alias) kullanır.
2. 'C' ile Başlayan Film Sayısı
sql

Copy
SELECT COUNT(*) AS count_of_films_starting_with_C  -- 'C' ile başlayan filmleri sayıyoruz
FROM film  -- film tablosundan
WHERE title LIKE 'C%';  -- Başlangıç karakteri 'C' olan filmleri seçiyoruz
-- COUNT(*): Belirtilen koşula uyan film sayısını döndürür.
-- WHERE title LIKE 'C%': Film isminin 'C' ile başladığı kayıtları filtreler.
3. En Uzun Rental Rate Değeri 0.99 Olan Film
sql

Copy
SELECT MAX(length) AS longest_film_length  -- En uzun film süresini buluyoruz
FROM film  -- film tablosundan
WHERE rental_rate = 0.99;  -- rental_rate değeri 0.99 olan filmleri filtreliyoruz
-- MAX(length): length sütunundaki en yüksek değeri bulur.
-- WHERE rental_rate = 0.99: Sadece rental_rate değeri 0.99 olan filmleri dikkate alır.
4. 150 Dakikadan Uzun Filmlerin Farklı Replacement Cost Değerleri
sql

Copy
SELECT COUNT(DISTINCT replacement_cost) AS unique_replacement_costs  -- Farklı replacement_cost değerlerini sayıyoruz
FROM film  -- film tablosundan
WHERE length > 150;  -- Uzunluğu 150 dakikadan büyük olan filmleri filtreliyoruz
-- COUNT(DISTINCT replacement_cost): Farklı replacement_cost değerlerini sayar.
-- WHERE length > 150: Sadece 150 dakikadan uzun filmleri dikkate alır.
📈 Sonuç
Yukarıdaki sorgular, dvdrental veri tabanındaki filmlerle ilgili önemli bilgileri elde etmek için kullanılabilir. Bu sorgular, veri analizi ve raporlama süreçlerinde faydalı olacaktır.
