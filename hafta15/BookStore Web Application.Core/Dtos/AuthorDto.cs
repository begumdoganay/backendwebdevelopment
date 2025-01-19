using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
    }
}
