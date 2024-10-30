📖 dvdrental SQL Sorguları ✨
🎉 Hoş Geldiniz!
Bu belgede, dvdrental veri tabanındaki verileri analiz etmek için kullanılan SQL sorgularını keşfedeceksiniz. Amacımız, veri tabanındaki film, müşteri ve şehir bilgilerini etkili bir şekilde analiz etmektir. Her sorgu, belirli bir bilgi parçasını elde etmeyi hedefler ve açıklayıcı yorumlarla desteklenmiştir.

📊 İçindekiler
Giriş
Sorgular
1. Filmleri Rating Değerlerine Göre Gruplama
2. Replacement Cost'a Göre Gruplama
3. Store ID'ye Göre Müşteri Sayıları
4. Ülke ID'sine Göre Şehir Sayısı
Kullanım
Sonuç
📖 Giriş
dvdrental veri tabanı, film kiralama işlemlerini izlemek için kullanılan örnek bir veri kümesidir. Bu belge, veri analizi yaparken kullanabileceğiniz SQL sorgularını içermektedir. Sorgular, veri tabanındaki filmleri, müşterileri ve şehirleri analiz etmek için tasarlanmıştır.

📝 Sorgular
1. Filmleri Rating Değerlerine Göre Gruplama
sql

Copy
SELECT rating, COUNT(*) AS film_count  -- Rating ve film sayısını seçiyoruz
FROM film  -- film tablosundan
GROUP BY rating;  -- rating değerine göre grupluyoruz
-- Bu sorgu, her bir rating değeri için film sayısını döndürür.
2. Replacement Cost'a Göre Gruplama
sql

Copy
SELECT replacement_cost, COUNT(*) AS film_count  -- replacement_cost ve film sayısını seçiyoruz
FROM film  -- film tablosundan
GROUP BY replacement_cost  -- replacement_cost değerine göre grupluyoruz
HAVING COUNT(*) > 50;  -- Film sayısı 50'den fazla olan grupları filtreliyoruz
-- Bu sorgu, 50'den fazla filme sahip replacement_cost değerlerini ve film sayılarını döndürür.
3. Store ID'ye Göre Müşteri Sayıları
sql

Copy
SELECT store_id, COUNT(*) AS customer_count  -- store_id ve müşteri sayısını seçiyoruz
FROM customer  -- customer tablosundan
GROUP BY store_id;  -- store_id değerine göre grupluyoruz
-- Bu sorgu, her bir store_id için müşteri sayısını döndürür.
4. Ülke ID'sine Göre Şehir Sayısı
sql

Copy
SELECT country_id, COUNT(*) AS city_count  -- country_id ve şehir sayısını seçiyoruz
FROM city  -- city tablosundan
GROUP BY country_id  -- country_id değerine göre grupluyoruz
ORDER BY city_count DESC  -- Şehir sayısına göre azalan sırada sıralıyoruz
LIMIT 1;  -- En fazla şehir sayısına sahip olanı alıyoruz
-- Bu sorgu, en fazla şehir sayısına sahip olan country_id bilgisi ve şehir sayısını döndürür.
📌 Kullanım
Bu sorguları, SQL uyumlu bir veri tabanı yöneticisi (DBMS) kullanarak çalıştırabilirsiniz. Her sorgu, belirli bir bilgi parçasını elde etmek için tasarlanmıştır. İhtiyaçlarınıza göre sorguları düzenleyebilir veya genişletebilirsiniz.
