/**
 * QMath.cs for Unity - uses Mathf.Sqrt for float maths instead of doubles, so suitable for Unity
 */

using UnityEngine;

namespace QMathLib
{
    public static class Quadratic
    {
        public static float Discriminant(float a, float b, float c)
        {
            return b * b - 4 * a * c;
        }


        public static float[] Roots(float a, float b, float c)
        {
            float d = Discriminant(a, b, c);

            // precondition - if discriminant is less than 0 then no real roots
            if (d < 0.0) return null;

            float[] x = new float[2];

            x[0] = (-b + Mathf.Sqrt(d)) / (2 * a);
            x[1] = (-b - Mathf.Sqrt(d)) / (2 * a);

            return x;
        }
    }
}
