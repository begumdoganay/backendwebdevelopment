using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models.Entities
{
    public class Game : BaseEntity
    {
            public required string Name { get; set; }
            public required string Platform { get; set; }
            public decimal Rating { get; set; }
            public required string Developer { get; set; }
            public required string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public required string Genre { get; set; }
            public decimal Price { get; set; }
            public int AgeRating { get; set; } 
            public bool IsMultiplayer { get; set; }
        }
    }