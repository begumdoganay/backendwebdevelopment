﻿using PolymorphismExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismExample
    {
        public class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }

            public override void Draw()
            {
                Console.WriteLine($"Drawing a circle with radius {Radius}");
            }
        }
    }
}
}
