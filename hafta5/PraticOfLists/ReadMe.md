# Patika Plus Gala Gecesi Davetli Listesi

Bu proje, Patika Plus Gala gecesine katılacak davetlilerin listesini oluşturmak ve ekrana yazdırmak için tasarlanmıştır.

## Proje Yapısı

- **Namespace**: `PatikaPlusGalaGecesi`
- **Program**: Ana sınıf, davetli listesini içerir ve yazdırma işlemini gerçekleştirir.

## Kullanılan Teknolojiler

- C#
- .NET

## Kod Açıklaması

### Ana Metot

C#
static void Main(string[] args)
Davetli listesini oluşturur.
PrintDavetlilerListesi(davetliler) metodu ile davetli listesini ekrana yazdırır.
Davetli Listesi
csharp

Copy
var davetliler = new List<string>
{
    "Bülent Ersoy",
    "Ajda Pekkan",
    "Ebru Gündeş",
    "Hadise",
    "Hande Yener",
    "Tarkan",
    "Funda Arar",
    "Demet Akalın"
};

Davetlilerin isimleri bir List<string> olarak tanımlanmıştır.
Yazdırma Metodu

static void PrintDavetlilerListesi(IReadOnlyList<string> davetliler)
Verilen davetli listesini konsola yazdırır.
Başlık ve ayırıcı çizgiler ile düzenli bir çıktı sağlar.
Çıktı
Davetlilerin isimleri yazdırılır.
Toplam davetli sayısı gösterilir.
Örnek Çıktı
asciidoc

Copy
** Patika Plus Gala Gecesi Davetlileri **
----------------------------------------
ForEach Döngüsü ile Yazdırma:
- Bülent Ersoy
- Ajda Pekkan
- Ebru Gündeş
- Hadise
- Hande Yener
- Tarkan
- Funda Arar
- Demet Akalın
----------------------------------------
Davetli Sayısı: 8
----------------------------------------
Sonuç
Bu kod, Patika Plus Gala gecesinde bir sürpriz yaşanmaması için her şeyin kontrol altında olduğunu garanti eder. Parti başlasın! 🎉