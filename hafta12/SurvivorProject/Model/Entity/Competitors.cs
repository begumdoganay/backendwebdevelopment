// Yarışmacıyı temsil eden sınıf, her yarışmacının bilgilerini burada tutuyoruz.
using SurvivorProject.Model.Entity;

public class Competitors : BaseEntity
{
    // Yarışmacının adı. "Adını öğrenelim?" dediğinizde bu alan kullanılır.
    public string? FirstName { get; set; }

    // Yarışmacının soyadı. "Soyadı neydi?" diye soruyorsanız buraya bakabilirsiniz.
    public string? LastName { get; set; }

    // Yarışmacının yaşı. Bu kişi genç mi yoksa deneyimli mi?
    public int Age { get; set; }

    // Yarışmacının yaşadığı şehir. "Nereden katılıyor?" sorusunun cevabı burada.
    public string? City { get; set; }

    // Yarışmacının ait olduğu kategori ID. Hangi kategoriye bağlı olduğunu belirtir.
    public int CategoryId { get; set; }

    // Yarışmacının bağlı olduğu kategori bilgisi. Daha fazla bilgiye erişmek istersek bu alanı kullanıyoruz.
    public Category? Category { get; set; }

    // Yarışmacının bilgilerini hızlıca almak için bir metin döner.
    public override string ToString()
    {
        return $"FirstName: {FirstName}, LastName: {LastName}, Age: {Age}, City: {City}, CategoryId: {CategoryId}";
    }
}

