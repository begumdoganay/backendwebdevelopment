using BookStore_Web_Application.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Entities
{
    public class Author : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Biography { get; set; }

        // Navigation Properties
        public ICollection<Book>? Books { get; set; }
    }
}
