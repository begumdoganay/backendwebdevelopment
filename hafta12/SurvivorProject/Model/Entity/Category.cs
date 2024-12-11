using System;
using System.Collections.Generic;

namespace SurvivorProject.Model.Entity
{
    // Kategori bilgilerini ve o kategoriye bağlı yarışmacıları temsil eden bir sınıf.
    public class Category : BaseEntity
    {
        // Kategorinin adı, kısaca "Bu kategori ne?" sorusunun cevabı.
        public string Name { get; set; }

        // Kategorinin açıklaması, "Bu kategori hakkında daha fazla bilgi?" diyorsanız buraya bakabilirsiniz.
        public string Description { get; set; }

        // Bu kategoriyle ilişkilendirilmiş yarışmacıların listesi. Boş mu? Yeni yarışmacılar eklemeyi düşünebilirsiniz!
        public ICollection<Competitors> Competitors { get; set; }

        // Bu kategori ne kadar popüler? 1 ile 10 arasında bir değer düşünün.
        public int PopularityRank { get; set; }

        // Bu kategoriye ait bir ikon ya da görsel URL. Kategoriyi temsil eden görsel bir şey düşünün.
        public string IconUrl { get; set; }

        // Kategori aktif mi? Yoksa dinlenmeye mi alınmış?
        public bool IsActive { get; private set; }

        // Yeni bir kategori oluşturduğunuzda her şey varsayılan olarak ayarlanır. Yarışmacılar listesi boş başlar.
        public Category()
#pragma warning restore CS8618 // Null atanamaz alan, oluşturucudan çıkış yaparken null olmayan bir değer içermelidir. 'Gerekli' değiştiricisini ekleyin veya null atanabilir olarak bildirmeyi göz önünde bulundurun.
        {
            Competitors = new List<Competitors>();
            IsActive = true;
            PopularityRank = 1; // Başlangıçta popülerlik düşük başlasın, sonra artar belki?
        }

        // Bu kategori artık aktif değil mi? Hemen pasif yapıyoruz.
        public void Deactivate()
        {
            IsActive = false;
            UpdateModifiedDate();
        }

        // Pasif olan kategoriyi tekrar aktif hale getirmek ister misiniz? İşte bu metot tam bunun için.
        public void Activate()
        {
            IsActive = true;
            UpdateModifiedDate();
        }

        private new void UpdateModifiedDate()
        {
            throw new NotImplementedException();
        }

        // Kategorinin adı, açıklaması ve durumuyla ilgili hızlıca bilgi almak için buraya bakın.
        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, PopularityRank: {PopularityRank}, IsActive: {IsActive}, CompetitorsCount: {Competitors?.Count ?? 0}";
        }
    }
}
