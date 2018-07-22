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

    public static class Tools
    {
        // functions to convert Radians to Degrees and vice versa. 
        public static float DegToRad(float angle)
        {
            return angle * Mathf.PI / 180;
        }

        public static float RadToDeg(float radian)
        {
            return radian * 180 / Mathf.PI;
        }

        public static float Sum(Vector3 vec)
        {
            return vec.x + vec.y + vec.z;
        }


        public static float Mult(Vector3 vec)
        {
            return vec.x * vec.y * vec.z;
        }


        public static float Max(float[] xs)
        {
            float max = xs[0];
            for (int i = 1; i < xs.Length; ++i)
            {
                if (max < xs[i]) max = xs[i];
            }

            return max;
        }

        public static float Min(float[] xs)
        {
            float min = xs[0];
            for (int i = 1; i < xs.Length; ++i)
            {
                if (min > xs[i]) min = xs[i];
            }

            return min;
        }
    }

    /**
 * Solve scalene triangle with three arguments
 */
    public static class Triangle
    {
        public static class ABC
        {
            public static float Alpha(float a, float b, float c)
            {
                return Mathf.Acos((b * b + c * c - a * a) / (2 * b * c));
            }

            public static float Beta(float a, float b, float c)
            {
                return Mathf.Acos((a * a + c * c - b * b) / (2 * a * c));
            }

            public static float Gamma(float a, float b, float c)
            {
                return Mathf.Acos((a * a + b * b - c * c) / (2 * a * b));
            }
        }


        public static class ABGamma
        {
            public static float C(float a, float b, float gamma)
            {
                return Mathf.Sqrt(a * a + b * b - 2 * a * b * Mathf.Cos(gamma));
            }

            public static float Alpha(float a, float b, float gamma)
            {
                return Mathf.Atan(a * Mathf.Sin(gamma) / (b - a * Mathf.Cos(gamma)));
            }

            public static float Beta(float a, float b, float gamma)
            {
                return Mathf.Atan(b * Mathf.Sin(gamma) / (a - b * Mathf.Cos(gamma)));
            }
        }
        /* Class with methods to solve "SSA Triangles" (two sides and an angle that is 
         * not the angle between the sides)
         * The methods work with Radians. There's converting functions above
         * TODO: In the calculation for alpha, Asin can give two different values (negative
         * and positive, or x so that alpha + x = 180). Account for that. 
         */
        public static class ACGamma
        {
            public static float Alpha(float a, float c, float gamma)
            {
                return Mathf.Asin((a * Mathf.Sin(gamma)) / c);
            }

            public static float Beta(float a, float c, float gamma)
            {
                return Mathf.PI - (Alpha(a, c, gamma) + gamma);
            }
            // overload to use in case we have already calculated alpha
            public static float Beta(float alpha, float gamma)
            {
                return Mathf.PI - (alpha + gamma);
            }

            public static float B(float a, float c, float gamma)
            {
                float alpha = Alpha(a, c, gamma);
                float beta = Beta(alpha, gamma);
                return (Mathf.Sin(beta) * c) / Mathf.Sin(gamma);
            }
        }
    }

}