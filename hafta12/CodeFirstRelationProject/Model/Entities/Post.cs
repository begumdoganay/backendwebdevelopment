using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstRelationProject.Model.Entities
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Başlık 3-100 karakter arasında olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        [StringLength(4000, MinimumLength = 10, ErrorMessage = "İçerik 10-4000 karakter arasında olmalıdır.")]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        [StringLength(50)]
        public string Category { get; set; }

        public int ViewCount { get; set; } = 0;

        public int LikeCount { get; set; } = 0;

        // Constructor
        public Post()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
            ViewCount = 0;
            LikeCount = 0;
        }
    }
}