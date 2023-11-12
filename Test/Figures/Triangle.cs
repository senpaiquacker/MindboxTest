using System;

namespace Figure
{
    public class Triangle: IFigure
    {
        private (float a, float b, float c) sides;

        public (float a, float b, float c) Sides
        {
            get => sides;
            set
            {
                float ab = value.a + value.b, bc = value.b + value.c, ac = value.a + value.c;
                if (ab <= value.c || bc <= value.a || ac <= value.b)
                    throw new Exception("Invalid triangle: sides do not follow triangle rules");
                else if (value.a <= 0 || value.b <= 0 || value.c <= 0)
                    throw new Exception("Can't pass non-positive values");
                else
                    sides = value;
                angles = (-1, -1, -1);
                var recalc = Angles;
            }

        }
        private (float ab, float ac, float bc) angles = (-1, -1, -1);
        public (float ab, float ac, float bc) Angles
        {
            get
            {
                if (angles.ab > 0)
                    return angles;
                var abcos = 
                    (sides.a * sides.a + 
                    sides.b * sides.b - 
                    sides.c * sides.c) / 
                    (2 * sides.a * sides.b);
                var accos =
                    (sides.a * sides.a +
                    sides.c * sides.c -
                    sides.b * sides.b) /
                    (2 * sides.a * sides.c);
                var bccos =
                    (sides.b * sides.b +
                    sides.c * sides.c -
                    sides.a * sides.a) /
                    (2 * sides.b * sides.c);
                angles = ((float)Math.Acos(abcos), (float)Math.Acos(accos), (float)Math.Acos(bccos));
                return angles;
            }
        }
        public Triangle(float a, float b, float c)
        {
            Sides = (a, b, c);
            var recalc = Angles;
        }

        public float Area => 0.5f * Sides.a * Sides.b * (float)Math.Sin(Angles.ab);

        public bool IsTriangleRight()
        {
            return 
                (Math.Abs(Angles.ab - MathF.PI / 2) < UtilityConstants.LocalEpsilon) ||
                (Math.Abs(Angles.ac - MathF.PI / 2) < UtilityConstants.LocalEpsilon) ||
                (Math.Abs(Angles.bc - MathF.PI / 2) < UtilityConstants.LocalEpsilon);
        }
    }
}
