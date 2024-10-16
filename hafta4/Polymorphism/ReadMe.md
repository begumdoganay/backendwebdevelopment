Patika+ Week4 Fundamentals Project
Merhaba, Bu proje C# ile Patika+ 4. hafta Fundamentals Projesidir. Proje kapsamında basit C# konsol uygulamaları yazılmıştır.

İçerik
Kurulum
Kullanım
Proje Hakkında
Uygulama ve Kodlar
📚 Kurulum
Projeyi çalıştırmak için şu adımları takip edebilirsiniz:

Klonlama:https://github.com/begumdoganay/backendwebdevelopment/tree/main/hafta4

ZIP Dosyası:

Sağ üst köşedeki "Code" butonuna tıklayın ve "Download ZIP" seçeneğini seçin.
ZIP dosyasını bilgisayarınıza indirin ve bir klasöre çıkartın.
Çalıştırma:

Proje klasörünü Visual Studio veya başka bir C# geliştirme ortamında açın.
Program.cs dosyasını çalıştırarak uygulamayı başlatın.

Şekil Galerisi
Bu proje, polimorfizm kavramını C# dilinde farklı şekiller (Daire, Dikdörtgen, Üçgen) üzerinden göstermektedir. Bu şekiller, ortak bir soyut temel sınıf olan Shape'ten türetilmiştir. Her şekil, kendi alan hesaplama ve çizim metodunu uygulamaktadır.

Özellikler
Polimorfizm: Tüm şekiller Shape sınıfından miras alır ve kendi CalculateArea (alan hesaplama) ve Draw (çizim) metodlarını uygular.
Nesne Yönelimli Programlama (OOP): Proje, miras alma ve soyutlama gibi OOP prensiplerini uygular.
Program, polimorfizm gücünü göstermek amacıyla farklı şekilleri ortak bir arayüz (Shape) ile dinamik olarak yönetir.
Sınıf Genel Bakışı
1. Shape (Soyut Temel Sınıf)
Tüm şekil sınıfları için yapıyı tanımlar.
İki soyut metot içerir:
CalculateArea(): Şeklin alanını hesaplar.
Draw(): Şeklin bilgisini konsola yazdırır.
2. Circle (Daire)
Shape sınıfından miras alır.
Yarıçapı alan bir yapıcı (constructor) içerir.
CalculateArea metodunu şu formülle uygular: π * r^2.
Draw metodunu, dairenin yarıçapını göstermek için uygular.
3. Rectangle (Dikdörtgen)
Shape sınıfından miras alır.
Genişlik ve yüksekliği alan bir yapıcı içerir.
CalculateArea metodunu şu formülle uygular: genişlik * yükseklik.
Draw metodunu, dikdörtgenin boyutlarını göstermek için uygular.
4. Triangle (Üçgen)
Shape sınıfından miras alır.
Taban ve yüksekliği alan bir yapıcı içerir.
CalculateArea metodunu şu formülle uygular: 0.5 * taban * yükseklik.
Draw metodunu, üçgenin taban ve yüksekliğini göstermek için uygular.
Nasıl Çalıştırılır
Bu deposunu klonlayın ya da proje dosyalarını indirin.
Projeyi tercih ettiğiniz C# IDE'sinde açın (örneğin, Visual Studio, JetBrains Rider).
Projeyi derleyin ve çalıştırın.
Program çalıştığında:

Hoş geldiniz mesajı gösterilecektir.
Şekillerin yer aldığı bir liste üzerinden döngü ile geçilecek, her bir şeklin alanı hesaplanacak ve konsolda gösterilecektir.
Şekil çizilecek (yani, bir tanım mesajı yazdırılacaktır).
Program kapanmadan önce kullanıcının bir tuşa basması beklenecektir.


Şekil Galerisine Hoş Geldiniz!
Şekillerimizi keşfedelim ve alanlarını inceleyelim:

5 birim yarıçaplı bir daire çiziliyor
Alan: 78.54

4x6 boyutlarında bir dikdörtgen çiziliyor
Alan: 24.00

3 birim tabanlı ve 4 birim yüksekliğinde bir üçgen çiziliyor
Alan: 6.00

Şekil Galerisinden çıkmak için herhangi bir tuşa basın...
