🎉 README: SQL Sorguları için Örnekler 🎉
Bu README dosyası, belirli kriterlere göre veri sorgulama işlemleri gerçekleştiren SQL sorgularını içermektedir. Veritabanı yönetimi ve analizine ilgi duyanlar için keyifli ve öğretici bir kaynak olmayı amaçlıyor. Aşağıda, her bir sorgunun amacı ve nasıl çalıştığı hakkında açıklamalar bulabilirsiniz.

📚 İçindekiler
Sorgu 1: 'A' ile Başlayıp 'a' ile Biten Ülkeler
Sorgu 2: En Az 6 Karakterden Oluşan ve 'n' ile Biten Ülkeler
Sorgu 3: Film Başlıklarında En Az 4 't' Harfi Geçen Filmler
Sorgu 4: 'C' ile Başlayan, 90 Dakikadan Uzun ve 2.99$ Kiralama Ücretli Filmler
🗺️ Sorgu 1: 'A' ile Başlayıp 'a' ile Biten Ülkeler
sql

Copy
SELECT country 
FROM country
WHERE country LIKE 'A%a';
Bu sorgu, 'A' harfi ile başlayıp 'a' harfi ile biten ülke adlarını döndürür. Örneğin, "Afganistan" ve "Arjantin" gibi ülkeler listelenecektir.

Neden Önemli?
Bu sorgu, ülkelerin isimleri üzerinde belirli desenleri arayarak, veri analizi ve raporlama için faydalı bilgiler sağlayabilir.

🔍 Sorgu 2: En Az 6 Karakterden Oluşan ve 'n' ile Biten Ülkeler
sql

Copy
SELECT country
FROM country
WHERE LENGTH(country) >= 6
  AND country LIKE '%n';
Bu sorgu, en az 6 karakterden oluşan ve 'n' harfi ile biten ülke adlarını getirir. Örneğin, "Almanya", "Hollanda" ve "Japonya" gibi ülkeler listelenecektir.

Neden Önemli?
Bu tür sorgular, belirli uzunluk ve son harf kriterlerine göre ülke gruplarını analiz etmek için kullanılabilir.

🎬 Sorgu 3: Film Başlıklarında En Az 4 't' Harfi Geçen Filmler
sql

Copy
SELECT title
FROM film
WHERE LOWER(title) LIKE '%t%t%t%t%';
Bu sorgu, film başlıklarında en az 4 adet 't' harfi (büyük/küçük harf duyarsız) geçen filmleri listeler. Örneğin, "The Matrix" ve "Letter to My Father" gibi filmler görüntülenecektir.

Neden Önemli?
Film başlıkları üzerindeki bu tür analizler, belirli kelime veya harf desenlerinin popülaritesini incelemek için oldukça faydalıdır.

🎥 Sorgu 4: 'C' ile Başlayan, 90 Dakikadan Uzun ve 2.99$ Kiralama Ücretli Filmler
sql

Copy
SELECT *
FROM film
WHERE title LIKE 'C%'
  AND length > 90
  AND rental_rate = 2.99;
Bu sorgu, 'C' harfi ile başlayan, 90 dakikadan uzun ve 2.99$ kiralama ücretine sahip filmlerin tüm verilerini döndürür. Örneğin, "Citizen Kane" ve "Chicago" gibi filmler listelenecektir.
