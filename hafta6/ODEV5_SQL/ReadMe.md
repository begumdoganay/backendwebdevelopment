Bu README dosyası, dvdrental veri tabanındaki bazı heyecan verici SQL sorgularını içeriyor. Bu sorgular, film ve müşteri verilerini analiz etmemize yardımcı olur. Her sorgunun ne yaptığını ve nasıl çalıştığını anlamanızı sağlamak için detaylı açıklamalar ekledik. Hadi, veritabanının derinliklerine dalalım!

📚 İçindekiler
Giriş
Sorgular
1. En Uzun 5 Film
2. En Kısa İkinci 5 Film
3. Store ID 1 Olan Müşteriler
Kullanım
Sonuç
🌟 Giriş
Bu sorgular, dvdrental veri tabanındaki film ve müşteri bilgilerini analiz etmemize yardımcı olur. Her sorgu belirli kriterlere göre verileri seçer ve sıralar. Hadi başlayalım!

📝 Sorgular
1. En Uzun 5 Film

SELECT title, length  -- Filmin başlığı ve uzunluğu
FROM film  -- film tablosundan
WHERE title LIKE '%n'  -- 'n' ile biten filmleri seçiyoruz
ORDER BY length DESC  -- En uzun olanlardan başlayarak sıralıyoruz
LIMIT 5;  -- İlk 5 sonucu alıyoruz
Açıklama: Bu sorgu, film isimleri 'n' ile biten en uzun 5 filmi getirir. Uzunluk kriterine göre azalan bir sıralama yaparak, en uzun filmleri öne çıkarır.

2. En Kısa İkinci 5 Film

SELECT title, length  -- Yine film başlığı ve uzunluğu
FROM film  -- film tablosundan
WHERE title LIKE '%n'  -- 'n' ile biten filmleri seçiyoruz
AND length IN (6, 7, 8, 9, 10)  -- Uzunluğu 6, 7, 8, 9 veya 10 olan filmleri filtreliyoruz
ORDER BY length ASC  -- En kısa olanlardan başlayarak sıralıyoruz
LIMIT 5 OFFSET 1;  -- İkinci 5 sonucu almak için 1 kaydırıyoruz
Açıklama: Bu sorgu, 'n' ile biten ve uzunluğu 6, 7, 8, 9 veya 10 karakter olan en kısa 5 filmi getirir. Sıralama artan bir şekilde yapılır ve ikinci 5 sonuç alınır.

3. Store ID 1 Olan Müşteriler

SELECT *  -- Tüm müşteri bilgilerini
FROM customer  -- customer tablosundan
WHERE store_id = 1  -- Sadece Store ID 1 olanları seçiyoruz
ORDER BY last_name DESC  -- Soyada göre azalan sırada sıralıyoruz
LIMIT 4;  -- İlk 4 sonucu alıyoruz
Açıklama: Bu sorgu, store ID'si 1 olan müşteri kayıtlarını listeler. Soyada göre azalan bir sıralama yapılır ve ilk 4 kayıt alınır.
