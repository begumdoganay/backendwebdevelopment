
// Açıklamalar:

// 1. Araba Sınıfı:
//    - Araba sınıfı, bir arabanın temel özelliklerini (Marka, Model, Renk, Kapı Sayısı) içeriyor.
//    - Bu sınıf, arabayla ilgili bilgileri tutmak ve işlemek için bir şablon görevi görüyor.

// 2. Özellikler (Properties):
//    - Marka, Model ve Renk için basit get/set özellikleri kullanıldı.
//    - KapiSayisi için özel bir kapsülleme işlemi yapıldı.

// 3. Kapsülleme (Encapsulation):
//    - KapiSayisi özelliği için özel bir kontrol mekanizması oluşturuldu.
//    - get bloğu, _kapiSayisi özel alanının değerini döndürür.
//    - set bloğu, yeni değeri kontrol eder:
//      * Eğer değer 2 veya 4 ise, _kapiSayisi'na atanır.
//      * Değilse, bir hata mesajı yazdırılır ve _kapiSayisi -1 olarak ayarlanır.

// 4. Constructor:
//    - Araba nesnesi oluşturulurken tüm özelliklerin değerlerini alan bir yapıcı metot tanımlandı.
//    - Bu, her yeni araba oluşturulduğunda tüm bilgilerin hemen atanmasını sağlar.

// 5. ToString Metodu:
//    - Araba nesnesinin özelliklerini okunabilir bir string olarak döndürmek için override edildi.
//    - Bu, Console.WriteLine ile araba nesnesini yazdırırken otomatik olarak çağrılır.

// 6. Main Metodu:
//    - Üç farklı araba örneği oluşturuldu.
//    - İki tanesi geçerli kapı sayısıyla (2 ve 4), bir tanesi geçersiz kapı sayısıyla (3).
//    - Her araba örneği yazdırıldı, böylece kapsülleme işleminin nasıl çalıştığı gözlemlendi.

// Bu kod, nesne yönelimli programlamanın temel prensiplerinden biri olan kapsüllemeyi gösteriyor.
// Kapı sayısı gibi kritik bir özelliği kontrol altında tutarak, geçersiz değerlerin atanmasını engelliyoruz.