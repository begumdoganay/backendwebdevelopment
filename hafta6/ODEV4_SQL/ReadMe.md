Bu README dosyası, dvdrental veri tabanındaki belirli bilgileri almak için hazırlanan SQL sorgularını içermektedir. Her sorgunun ne yaptığını ve nasıl çalıştığını anlamanızı sağlamak için detaylı açıklamalar ekledik. Hadi başlayalım!

📚 İçindekiler
Farklı Replacement Cost Değerlerini Sıralama
Farklı Replacement Cost Sayısını Bulma
'T' ile Başlayan ve Rating 'G' Olan Film Sayısı
5 Karakterden Oluşan Ülke Sayısı
'R' veya 'r' ile Biten Şehir Sayısı
🔍 Sorgular
Farklı Replacement Cost Değerlerini Sıralama

SELECT DISTINCT replacement_cost  -- film tablosundaki benzersiz replacement_cost değerlerini alıyoruz
FROM film  -- film tablosundan verileri alıyoruz
ORDER BY replacement_cost;  -- değerleri artan düzende sıralıyoruz
Bu sorgu, film tablosundaki birbirinden farklı replacement_cost değerlerini alır ve bunları artan düzende sıralar. Böylece, hangi değerlerin kullanıldığını görebiliriz.

Farklı Replacement Cost Sayısını Bulma

SELECT COUNT(DISTINCT replacement_cost) AS unique_replacement_cost_count  -- benzersiz değerlerin sayısını alıyoruz
FROM film;  -- film tablosunu kullanarak verileri alıyoruz
Bu sorgu, replacement_cost sütunundaki benzersiz değerlerin sayısını döndürür. Bu, veri setimizdeki çeşitliliği anlamamıza yardımcı olur.

'T' ile Başlayan ve Rating 'G' Olan Film Sayısı

SELECT COUNT(*) AS title_starting_with_T_and_rating_G  -- 'T' ile başlayan ve 'G' rating'e sahip filmleri sayıyoruz
FROM film  -- film tablosundan verileri alıyoruz
WHERE title LIKE 'T%' AND rating = 'G';  -- başlık 'T' ile başlamalı ve rating 'G' olmalı
Bu sorgu, başlığı 'T' harfi ile başlayan ve rating değeri 'G' olan filmlerin sayısını verir. Çocuklar için uygun içeriklere odaklanmak isteyenler için faydalıdır.

5 Karakterden Oluşan Ülke Sayısı

SELECT COUNT(*) AS countries_with_5_characters  -- 5 karakterden oluşan ülkelerin sayısını alıyoruz
FROM country  -- country tablosunu kullanarak verileri alıyoruz
WHERE LENGTH(country) = 5;  -- ülke adı 5 karakter olmalı
Bu sorgu, country tablosundaki 5 karakterden oluşan ülke isimlerinin sayısını döndürür. Kısa isimli ülkeleri merak edenler için oldukça ilginç!

'R' veya 'r' ile Biten Şehir Sayısı

SELECT COUNT(*) AS cities_ending_with_R_or_r  -- 'R' veya 'r' ile biten şehirlerin sayısını alıyoruz
FROM city  -- city tablosunu kullanarak verileri alıyoruz
WHERE city LIKE '%R' OR city LIKE '%r';  -- şehir adı 'R' veya 'r' ile bitmeli
Bu sorgu, şehir isimlerinin 'R' veya 'r' ile bitenlerinin sayısını verir. Şehir isimlerine biraz eğlence katmak isteyenler için harika!

🤔 Sonuç
Bu sorguları çalıştırarak, dvdrental veri tabanındaki bilgileri daha iyi anlayabiliriz. Her sorgu, belirli bir amaca hizmet eder ve sonuçları hızlıca elde etmemizi sağlar. Veri analizi yaparken bu sorgular oldukça işinize yarayabilir.

Herhangi bir sorunuz olursa sormaktan çekinmeyin! SQL ile eğlenceli ve öğretici bir yolculuk dileriz! 🚀
