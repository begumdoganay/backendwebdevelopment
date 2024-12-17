using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
        // Öğretmen temel sözleşmesini oluşturalım. 
        // Bu interface, öğretmen nesnelerinin oluşturulması için temel yapıyı tanımlar
        public interface ITeacher
        {
            // Öğretmenin adını ekleyelim
            string FirstName { get; set; }

            // Öğretmenin soyadını ekleyelim 
            string LastName { get; set; }

            // Öğretmenin branşını belirtelim
            string Branch { get; set; }

            // Öğretmenin tam adını ve branşını döndüren metot
            string GetInfo();

            // Öğretmenin sadece ad-soyad bilgisini döndüren metot
            string GetFullName();

            // Öğretmenin branş bilgisini döndüren metot
            string GetBranch();
        }
    
}


