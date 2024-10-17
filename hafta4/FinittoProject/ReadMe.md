💣 Hafta 4 - Kapanış Projesi
Bu proje, bir teknoloji mağazasında Telefon ve Bilgisayar kayıtlarını almak için geliştirilmiş bir C# konsol uygulamasıdır. Aşağıdaki C# konularını öğrenmek ve pekiştirmek amacıyla tasarlanmıştır:

🎯 Amaç
Bu proje ile öğrenilen C# kavramları:

Inheritance (Miras Alma)
Encapsulation (Kapsülleme)
Polymorphism (Çok Biçimlilik)
Abstraction (Soyutlama)
📝 Proje Açıklaması
Bu projede, kullanıcıdan alınan bilgiler doğrultusunda Telefon ve Bilgisayar nesneleri oluşturulmakta ve bu ürünlerin bilgileri ekrana yazdırılmaktadır.

Her iki cihazın da bazı ortak özellikleri ve kendilerine özgü özellikleri bulunmaktadır. BaseMakine adlı temel sınıftan türetilen Telefon ve Bilgisayar sınıflarında bu özellikler farklı şekillerde uygulanmıştır.

📦 Sınıf Yapısı
1. BaseMakine (Temel Sınıf)
Ortak özellikleri içeren temel sınıftır. Tüm cihazlar bu sınıftan türetilir.
Ortak Özellikler:

Üretim Tarihi (Otomatik atanır)
Seri Numarası
Ad
Açıklama
İşletim Sistemi
Metotlar:

BilgileriYazdir(): Ürün bilgilerini ekrana yazdırır. Derived class'lar (Telefon ve Bilgisayar) bu metodu ezerek kendi özelliklerini ekler.
UrunAdiGetir(): Soyut metot. Derived class'lar tarafından ezilerek ürün adını özelleştirir.
2. Telefon
Özellikler:

TRLisansli: Türkiye lisanslı olup olmama durumu (boolean).
Özelleştirilmiş Metotlar:

BilgileriYazdir(): Telefon özelliklerini ekrana yazdırır.
UrunAdiGetir(): "Telefonunuzun adı ---> ..." formatında konsol mesajı döner.
3. Bilgisayar
Özellikler:

UsbGirisSayisi: 2 veya 4 olabilir. Aksi durumda uyarı mesajı verilir ve -1 değeri atanır.
BluetoothVarMi: Bluetooth olup olmadığı (boolean).
Özelleştirilmiş Metotlar:

BilgileriYazdir(): Bilgisayar özelliklerini ekrana yazdırır.
UrunAdiGetir(): "Bilgisayarınızın adı ---> ..." formatında konsol mesajı döner.
🚀 Program Akışı
Kullanıcıya, telefon üretmek için 1, bilgisayar üretmek için 2 tuşlarına basması gerektiği söylenir.
Seçilen cihaza ait özellikler kullanıcıdan istenir:
Telefon için: Seri numarası, ad, açıklama, işletim sistemi ve TR lisanslı olup olmadığı.
Bilgisayar için: Seri numarası, ad, açıklama, işletim sistemi, USB giriş sayısı ve Bluetooth olup olmadığı.
Ürün başarıyla oluşturulduğunda, bilgileri ekrana yazdırılır.
Kullanıcıya başka bir ürün üretmek isteyip istemediği sorulur.
Kullanıcı "evet" derse, program tekrar başa döner. "hayır" derse, "İyi günler!" mesajı ile uygulama sonlandırılır.
📊 Örnek Çıktılar
📱 Telefon Üretimi:
yaml
Copy code
Telefon Adı: iPhone  
Seri Numarası: ABC123  
İşletim Sistemi: iOS  
Üretim Tarihi: 17.10.2024  
TR Lisanslı: Evet
💻 Bilgisayar Üretimi:
yaml
Copy code
Bilgisayar Adı: Lenovo  
Seri Numarası: XYZ456  
İşletim Sistemi: Windows  
Üretim Tarihi: 17.10.2024  
USB Giriş Sayısı: 2  
Bluetooth: Var
🔄 Tekrar Ürün Üretme
Programda, kullanıcıya tekrar başka bir ürün üretmek isteyip istemediği sorulur.

"Evet" yanıtı verildiğinde döngü başa döner ve yeni ürün üretimi başlar.
"Hayır" yanıtı verildiğinde program "İyi günler!" mesajı ile sonlandırılır.
🧑‍💻 Kullanılan Teknolojiler
C#
.NET Framework
Konsol Uygulaması
💡 Geliştirici Notları
Bu proje, temel OOP kavramlarını öğretmek ve pekiştirmek amacıyla tasarlanmıştır. Programın daha fazla özellik kazanması veya GUI tabanlı hale getirilmesi mümkündür.

