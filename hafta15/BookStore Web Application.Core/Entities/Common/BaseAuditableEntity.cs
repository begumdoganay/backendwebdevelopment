using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Entities.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
