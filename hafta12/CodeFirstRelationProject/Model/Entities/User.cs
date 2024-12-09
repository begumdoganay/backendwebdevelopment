using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstRelationProject.Model.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-50 karakter arasında olmalıdır.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string ProfileImageUrl { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }

        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(20)]
        public string Role { get; set; } = "User";

        // Navigation property
        public virtual ICollection<Post> Posts { get; set; }

        // Hesaplanan özellik - Tam Ad
        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}".Trim(); }
        }

        // Hesaplanan özellik - Yaş
        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                    age--;
                return age;
            }
        }

        // Constructor

        public User()

        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
            Posts = [];
            Role = "User";
        }
    }
}