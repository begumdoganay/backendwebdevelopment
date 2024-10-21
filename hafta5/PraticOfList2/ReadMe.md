Pratik - Lists 2
Bir Kahve İçsek Bize İyi Gelecek!
Bu uygulama, kullanıcıdan konsoldan gireceği 5 farklı kahve ismi ile bir liste oluşturarak, bu listeyi ekrana yazdırmayı amaçlamaktadır. Kahve tutkunları için hazırlandığı bu program, kullanıcı etkileşimi ile kahve çeşitlerini kaydeder ve gösterir.

# Kahve Menüsü Uygulaması

## İçindekiler
1. [Proje Hakkında](#proje-hakkında)
2. [Özellikler](#özellikler)
3. [Kurulum](#kurulum)
4. [Kullanım](#kullanım)
5. [Örnek Çıktı](#örnek-çıktı)
6. [Teknik Detaylar](#teknik-detaylar)
7. [Katkıda Bulunma](#katkıda-bulunma)
8. [Lisans](#lisans)

## Proje Hakkında

"Bir Kahve İçsek Bize İyi Gelecek!" uygulaması, kahve tutkunları için tasarlanmış interaktif bir C# konsol programıdır. Bu uygulama, kullanıcıların kendi kahve menülerini oluşturmalarına ve görüntülemelerine olanak tanır.

## Özellikler

- Kullanıcıdan 5 farklı kahve çeşidi girişi alma
- Girilen kahve isimlerini bir listede saklama
- Oluşturulan kahve menüsünü konsola yazdırma
- Boş girişlere karşı hata kontrolü

## Kurulum

1. Bu projeyi klonlayın:
   ```
   git clone https://github.com/kullaniciadi/kahve-menu-uygulamasi.git
   ```
2. Proje dizinine gidin:
   ```
   cd kahve-menu-uygulamasi
   ```
3. Projeyi derleyin:
   ```
   dotnet build
   ```

## Kullanım

1. Uygulamayı çalıştırın:
   ```
   dotnet run
   ```
2. Konsol ekranında beliren yönergeleri takip edin.
3. İstenilen 5 kahve çeşidini sırayla girin.
4. Girdiğiniz kahvelerden oluşan menüyü görüntüleyin.

## Örnek Çıktı

```
Bir kahve çeşidi girin (#1): Espresso
Bir kahve çeşidi girin (#2): Cappuccino
Bir kahve çeşidi girin (#3): Latte
Bir kahve çeşidi girin (#4): Americano
Bir kahve çeşidi girin (#5): Mocha

Kahve Menüsü:
===>>> Espresso
===>>> Cappuccino
===>>> Latte
===>>> Americano
===>>> Mocha
```

## Teknik Detaylar

- **Programlama Dili**: C#
- **Hedef Framework**: .NET Core 3.1 / .NET 5.0+
- **Kullanılan Kütüphaneler**: 
  - System
  - System.Collections.Generic
- **Veri Yapıları**: List<string>
- **Kullanıcı Girişi**: Console.ReadLine()
- **Döngüler**: for, foreach
- **Hata Kontrolü**: Boş giriş kontrolü

## Katkıda Bulunma

1. Bu projeyi fork edin
2. Yeni bir özellik dalı oluşturun (`git checkout -b yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik: Özet'`)
4. Dalınıza push yapın (`git push origin yeni-ozellik`)
5. Bir Pull Request oluşturun

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır. Detaylar için LICENSE dosyasını inceleyebilirsiniz.


Geliştirici: Begüm DOĞANAY
İletişim: begum.doganay@icloud.com
