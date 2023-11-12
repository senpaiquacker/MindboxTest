using System;
using System.Collections.Generic;
using System.Text;

namespace Figure
{
    public class Circle: IFigure
    {
        private float radius;
        public float Radius
        {
            get => radius;
            set
            {
                if (value <= 0)
                    throw new Exception("Can't pass non-positive value to radius");
                radius = value;
            }
        }

        public float Area
        {
            get => (float)Math.PI * Radius * Radius;
        }

        public Circle(float radius) => Radius = radius;
    }
}
