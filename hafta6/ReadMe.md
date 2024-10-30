# 🎬 DVD Kiralama Veritabanı SQL Rehberi

Merhaba! 👋 Bu rehber, DVD kiralama veritabanımızda sıkça kullanılan SQL sorgularını ve püf noktalarını içeriyor. İster yeni başlayan ister deneyimli bir geliştirici olun, bu döküman size yardımcı olmak için hazırlandı.

## 📚 Neler Öğreneceksiniz?

1. [💰 Film Fiyatlarını Akıllıca Filtreleme](#film-kiralama-ücreti-filtreleme)
2. [🌟 Favori Aktörlerinizi Bulma](#aktör-isim-filtreleme)
3. [🔍 Detaylı Film Arama](#çoklu-koşul-film-filtreleme)
4. [⏱️ Film Süresi ve Fiyat Filtreleme](#film-uzunluğu-ve-ücret-filtreleme)
5. [📅 Tarih Bazlı Kiralama Arama](#tarih-aralığı-kiralama-filtreleme)

## 🎯 Sorgular ve Kullanım Örnekleri

### 💰 Film Kiralama Ücreti Filtreleme

SELECT *
FROM film
WHERE rental_rate BETWEEN 2.99 AND 4.99;
```

**Ne İşe Yarar?** 
Bütçenize uygun filmleri bulmak için harika bir sorgu! Mesela öğrenci indirimleri için 2.99-4.99 arası filmleri listeleyebilirsiniz.

### 🌟 Aktör İsim Filtreleme

```sql
SELECT first_name, last_name 
FROM actor
WHERE first_name IN ('Nick', 'Penelope', 'Ed');
```

**Ne İşe Yarar?** 
En sevdiğiniz aktörlerin filmlerini mi arıyorsunuz? Bu sorgu tam size göre! Birden fazla aktörü aynı anda arayabilirsiniz.

### 🔍 Çoklu Koşul Film Filtreleme

```sql
SELECT title, rental_rate, replacement_cost
FROM film
WHERE 
    rental_rate IN (0.99, 2.99, 4.99)
    AND
    replacement_cost IN (12.99, 15.99, 28.99);
```

**Ne İşe Yarar?** 
Hem bütçe dostu hem de değer kaybı az filmler mi arıyorsunuz? Bu sorgu size iki kriteri birden sunuyor!

### ⏱️ Film Uzunluğu ve Ücret Filtreleme

```sql
SELECT 
    title,
    length,
    rental_rate
FROM film
WHERE 
    length BETWEEN 60 AND 120
    AND
    rental_rate IN (2.99, 4.99);
```

**Ne İşe Yarar?** 
Öğle aranızda izleyebileceğiniz, uygun fiyatlı filmler mi arıyorsunuz? Bu sorgu tam size göre! 1-2 saatlik filmler arasından seçim yapabilirsiniz.

### 📅 Tarih Aralığı Kiralama Filtreleme

```sql
SELECT 
    rental_id,
    rental_date,
    customer_id,
    return_date
FROM rental
WHERE 
    rental_date BETWEEN '2005-05-24' AND '2005-05-31';
```

**Ne İşe Yarar?** 
Hangi hafta daha çok kiralama yapıldığını merak mı ediyorsunuz? Bu sorgu ile istediğiniz tarih aralığındaki kiralamaları görebilirsiniz!

## 💡 Faydalı İpuçları

1. **Hız İpuçları:**
   - Çok fazla `IN` değeri kullanmak sorguyu yavaşlatabilir 🐌
   - Tarih sorgularında index kullanımı süper hızlar sağlar 🚀
   - En dar kapsamlı filtreyi başa yazmak performansı artırır ⚡

2. **Format İpuçları:**
   - Tarihleri her zaman 'YYYY-MM-DD' formatında yazın 📅
   - Ondalık sayılarda nokta kullanın (örn: 2.99) 💲
   - `BETWEEN` kullanırken başlangıç ve bitiş değerleri dahildir! 🎯

## 🤔 Sık Sorulan Sorular

1. **S: Bu sorguları nasıl özelleştirebilirim?**
   C: Fiyat, tarih ve isim değerlerini kendi ihtiyacınıza göre değiştirebilirsiniz!

2. **S: Performans sorunları yaşıyorum, ne yapmalıyım?**
   C: İlk olarak indekslerinizi kontrol edin ve filtrelerinizi daraltmayı deneyin.

## 🎉 Son Notlar

Bu sorguları dilediğiniz gibi özelleştirebilir ve kendi ihtiyaçlarınıza göre uyarlayabilirsiniz. Herhangi bir sorunuz olursa veya yardıma ihtiyacınız varsa, sormaktan çekinmeyin!

Mutlu sorgulama! 🚀✨
