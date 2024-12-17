using System;

namespace Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Dependency Injection Örneği ===\n");

                // İlk öğretmen örneği oluşturuluyor
                Console.WriteLine("1. Öğretmen Örneği:");
                ITeacher mathTeacher = new Teacher("Ahmet", "Yılmaz", "Matematik");
                Classroom mathClass = new Classroom(mathTeacher, "12-A");
                DisplayTeacherInfo(mathClass);

                // İkinci öğretmen örneği oluşturuluyor
                Console.WriteLine("\n2. Öğretmen Örneği:");
                ITeacher scienceTeacher = new Teacher("Ayşe", "Kaya", "Fen Bilgisi");
                Classroom scienceClass = new Classroom(scienceTeacher, "11-B");
                DisplayTeacherInfo(scienceClass);

                // Hatalı örnek - null öğretmen ile sınıf oluşturma denemesi
                Console.WriteLine("\n3. Hatalı Örnek (Null Öğretmen):");
                try
                {
                    Classroom invalidClass = new Classroom(null!, "10-C");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Hata yakalandı: {ex.Message}");
                }

                Console.WriteLine("\nÖrnek başarıyla tamamlandı!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nBir hata oluştu: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgramı kapatmak için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        // Yardımcı metot: Sınıf ve öğretmen bilgilerini görüntüler
        private static void DisplayTeacherInfo(Classroom classroom)
        {
            Console.WriteLine($"Sınıf Bilgisi: {classroom.GetClassInfo()}");
            Console.WriteLine($"Öğretmen Bilgisi: {classroom.GetTeacherInfo()}");
        }
    }
}