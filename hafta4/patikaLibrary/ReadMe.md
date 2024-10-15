Pratik - Patika Kütüphane
Patika Kütüphanesi için bir kitap kayıt uygulaması oluşturmak istiyoruz. Bu nedenle bu aşamada kitap nesneleri oluşturmamız gerekiyor.

Ad, Yazar Adı, Yazar Soyadı, Sayfa Sayısı, Yayınevi, Kayit Tarihi bilgileri ile kitaplar kaydetmek istiyoruz.


Kütüphane - Kitap Kayıt Uygulaması

Bu proje, **Patika Kütüphanesi** için bir kitap kayıt uygulaması geliştirmek amacıyla tasarlanmıştır. Kullanıcılar bu uygulama sayesinde kitapların bilgilerini sisteme kaydedebilir ve kayıtlı kitap bilgilerini görüntüleyebilirler.

### Proje İçeriği

#### 1. Kitap Sınıfı (Book Class)
Kitap nesnelerini temsil eden bir **Book** sınıfı oluşturulmuştur. Bu sınıf, kitaplara dair temel bilgileri tutar ve şu özellikleri içerir:
- **Kitap Adı (bookTitle)**
- **Yazar Adı (authorFirstName)**
- **Yazar Soyadı (authorLastName)**
- **Sayfa Sayısı (pageCount)**
- **Yayınevi (publisher)**
- **Kayıt Tarihi (registrationDate)**: Bu alan otomatik olarak kitabın kayıt anında atanır.

#### 2. Constructor'lar
**Parametreli Constructor:**
Kullanıcının kitap bilgilerini girerek nesne oluşturmasına imkan tanır ve kayıt tarihini otomatik olarak atar.

**Default Constructor:**
Parametre almadan bir kitap nesnesi oluşturulmasını sağlar ve kayıt tarihini otomatik olarak belirler.

#### 3. Properties
Sınıfın içindeki alanlara doğrudan erişimi kapatıp, güvenli bir şekilde bu alanlara erişim sağlar. Kullanıcılar, doğrudan değişkenler yerine bu özellikler aracılığıyla kitap bilgilerini okuyabilir ya da değiştirebilir.

#### 4. Metotlar
- **DisplayInfo()**: Kitap bilgilerini ekrana yazdırmak için kullanılır. Bu metot, kitabın tüm bilgilerini kullanıcıya gösterir.

Bu uygulama sayesinde kullanıcılar, kitapları sisteme kolayca ekleyip görüntüleyebilir, kitap bilgilerini yönetebilirler.