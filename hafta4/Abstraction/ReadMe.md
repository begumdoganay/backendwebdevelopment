Çalışan Yönetim Sistemi ile Soyutlama (Abstraction)
Genel Bakış
Bu program, bir şirketin çalışan yönetim sistemini simüle eder. Şirketteki her çalışanın ad, soyad ve departman gibi ortak özellikleri vardır. Ancak, her çalışan farklı bir pozisyona sahiptir (Örneğin, Yazılım Geliştirici, Proje Yöneticisi veya Satış Temsilcisi). Program, soyutlama kullanarak ortak özellikleri bir soyut sınıfta toplar ve her pozisyona özgü görevleri türetilmiş sınıflar aracılığıyla gerçekleştirir.

Temel Kavramlar
1. Soyutlama:
Soyutlama, detayları gizleyip sadece işlevselliği göstermektir. Bu örnekte, çalışan sınıfı soyutlanmıştır çünkü tüm çalışanların ortak özellikleri olsa da her biri farklı görevler yerine getirir.

2. Soyut Sınıflar:
Çalışan (Employee) soyut sınıfı, çalışanların ortak özelliklerini (ad, soyad, departman) tanımlar ve soyut bir Gorev() metodunu içerir. Bu metot, her türetilmiş sınıf tarafından ezilerek (override) çalışanların pozisyonlarına göre görev tanımları yapılır.

Sınıf Yapısı
1. Soyut Sınıf: Employee
Özellikler:
Ad
Soyad
Departman
Soyut Metot: Gorev() - Her türetilmiş sınıf bu metodu kendi görevi doğrultusunda ezmelidir.
csharp
Copy code
public abstract class Employee
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Department { get; set; }

    public Employee(string name, string surname, string department)
    {
        Name = name;
        Surname = surname;
        Department = department;
    }

    // Soyut metod, türetilmiş sınıflarda ezilecek
    public abstract void Gorev();
}
2. Türetilmiş Sınıflar
Her türetilmiş sınıf, şirket içindeki farklı pozisyonları temsil eder (örneğin, Yazılım Geliştirici, Proje Yöneticisi, Satış Temsilcisi). Bu sınıflar, Çalışan soyut sınıfından türemiştir ve Gorev() metodunu ezerek her pozisyonun görevini belirler.

Örnek: Proje Yöneticisi Sınıfı
csharp
Copy code
public class ProjectManager : Employee
{
    public ProjectManager(string name, string surname, string department) 
        : base(name, surname, department) { }

    // Proje Yöneticisinin görevini tanımlar
    public override void Gorev()
    {
        Console.WriteLine($"{Name} {Surname} şirketin Proje Yöneticisi olarak çalışıyor.");
    }
}
Örnek: Yazılım Geliştirici Sınıfı
csharp
Copy code
public class SoftwareDeveloper : Employee
{
    public SoftwareDeveloper(string name, string surname, string department) 
        : base(name, surname, department) { }

    // Yazılım Geliştiricisinin görevini tanımlar
    public override void Gorev()
    {
        Console.WriteLine($"{Name} {Surname} şirketin Yazılım Geliştiricisi olarak çalışıyor.");
    }
}
Örnek: Satış Temsilcisi Sınıfı
csharp
Copy code
public class SalesRepresentative : Employee
{
    public SalesRepresentative(string name, string surname, string department) 
        : base(name, surname, department) { }

    // Satış Temsilcisinin görevini tanımlar
    public override void Gorev()
    {
        Console.WriteLine($"{Name} {Surname} şirketin Satış Temsilcisi olarak çalışıyor.");
    }
}
Program Akışı
Program, farklı çalışan türlerinin örneklerini (Proje Yöneticisi, Yazılım Geliştirici, Satış Temsilcisi) oluşturur.
Her çalışanın Gorev() metodu çağrılır ve bu metodun sonucunda ilgili pozisyonun görev tanımı konsola yazdırılır.
Çıktı, her çalışanın pozisyonuna göre farklılık gösterir.
Programın Çalışma Örneği
csharp
Copy code
class Program
{
    static void Main(string[] args)
    {
        // Farklı rollerden çalışanlar oluşturuluyor
        List<Employee> employees = new List<Employee>
        {
            new ProjectManager("Hasan", "Çıldırmış", "Proje Yönetimi"),
            new SoftwareDeveloper("Ahmet", "Yılmaz", "Yazılım Geliştirme"),
            new SalesRepresentative("Selin", "Özdemir", "Satış")
        };

        // Her çalışanın görevini ekrana yazdır
        foreach (var employee in employees)
        {
            employee.Gorev();
        }

        // Programı durdurma
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
Örnek Çıktı:
css
Copy code
Hasan Çıldırmış şirketin Proje Yöneticisi olarak çalışıyor.
Ahmet Yılmaz şirketin Yazılım Geliştiricisi olarak çalışıyor.
Selin Özdemir şirketin Satış Temsilcisi olarak çalışıyor.
Çıkmak için bir tuşa basın...
Sonuç
Bu örnek, nesne yönelimli programlamada soyutlamanın gücünü gösterir. Farklı çalışan rollerine ortak bir arayüz sağlar ve her bir rolün özgün görev tanımını türetilmiş sınıflar aracılığıyla gerçekleştirilir. Bu yapı, kodun daha düzenli, modüler ve yeni roller eklenmesi gerektiğinde genişletilebilir olmasını sağlar.