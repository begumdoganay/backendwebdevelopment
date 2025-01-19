using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Entities.Common
{
    public interface IDeletedEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
        string? DeletedBy { get; set; }
    }
}
