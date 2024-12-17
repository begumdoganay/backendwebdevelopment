namespace Dependency_Injection
{
    // ITeacher interface'ini uygulayan öğretmen sınıfı
    public class Teacher : ITeacher
    {
        // Öğretmen özelliklerini sınıflandıralım 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }

        // Varsayılan constructor
        public Teacher()
        {
            FirstName = "Belirsiz";
            LastName = "Belirsiz";
            Branch = "Belirsiz";
        }

        // Parametreli constructor
        public Teacher(string firstName, string lastName, string branch)
        {
            // Parametre kontrolleri
            ValidateParameters(firstName, lastName, branch);

            // Değer atamaları
            FirstName = firstName;
            LastName = lastName;
            Branch = branch;
        }

        // Öğretmenin tüm bilgilerini döndüren metot
        public string GetInfo()
        {
            return $"{GetFullName()} - {Branch} Öğretmeni";
        }

        // Öğretmenin tam adını döndüren metot
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Öğretmenin branşını döndüren metot
        public string GetBranch()
        {
            return Branch;
        }

        // Parametre doğrulama metodu
        private static void ValidateParameters(string firstName, string lastName, string branch)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName), "Öğretmen adı boş olamaz!");

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName), "Öğretmen soyadı boş olamaz!");

            if (string.IsNullOrEmpty(branch))
                throw new ArgumentNullException(nameof(branch), "Öğretmen branşı boş olamaz!");
        }

        // ToString metodu override
        public override string ToString()
        {
            return GetInfo();
        }
    }
}