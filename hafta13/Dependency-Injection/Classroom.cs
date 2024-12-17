namespace Dependency_Injection
{
    // Sınıf bilgilerini tutan ve öğretmen bağımlılığını yöneten sınıf
    public class Classroom
    {
  
        private readonly ITeacher _teacher;
        private readonly string _className;

        // Constructor - Dependency Injection burada gerçekleşir
        public Classroom(ITeacher teacher, string className)
        {
            // Parametre kontrolleri
            ValidateParameters(teacher, className);

            // Değer atamalarını belirtelim
            _teacher = teacher;
            _className = className;
        }

        // Sınıf bilgisini döndüren metot, devam edelim 
        public string GetClassInfo()
        {
            return $"Sınıf: {_className}";
        }

        // Öğretmen bilgisini döndüren metot
        public string GetTeacherInfo()
        {
            return _teacher.GetInfo();
        }

        // Detaylı sınıf bilgisini döndüren metot
        public string GetDetailedInfo()
        {
            return $"Sınıf: {_className}\nÖğretmen: {_teacher.GetFullName()}\nBranş: {_teacher.GetBranch()}";
        }

        // Parametre doğrulama metodu
        private static void ValidateParameters(ITeacher teacher, string className)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher), "Öğretmen nesnesi boş olamaz!");

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException(nameof(className), "Sınıf adı boş olamaz!");
        }

        // ToString metodu override
        public override string ToString()
        {
            return GetDetailedInfo();
        }
    }
}