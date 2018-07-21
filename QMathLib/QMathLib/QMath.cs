using System;

namespace QMathLib
{
    public class Point2D
    {
        public double x, y;
        
        public Point2D() { }
        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
    }

    public static class Quadratic
    {
        public static double Discriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }


        public static double[] Roots(double a, double b, double c)
        {
            double d = Discriminant(a, b, c);

            // precondition - if discriminant is less than 0 then no real roots
            if (d < 0.0) return null;

            double[] x = new double[2];

            x[0] = (-b + Math.Sqrt(d)) / (2 * a);
            x[1] = (-b - Math.Sqrt(d)) / (2 * a);

            return x;
        }

        public static Point2D Extreme(double a, double b, double c)
        {
            double x = -b / (2 * a);
            double y = a * x * x + b * x + c;
            return new Point2D(x, y);
        }
    }

    /**
     * Solve scalene triangle with three arguments
     */
    public static class Triangle
    {
        public static class ABC
        {
            public static double Alpha(double a, double b, double c)
            {
                return Math.Acos((b * b + c * c - a * a) / (2 * b * c));
            }

            public static double Beta(double a, double b, double c)
            {
                return Math.Acos((a * a + c * c - b * b) / (2 * a * c));
            }

            public static double Gamma(double a, double b, double c)
            {
                return Math.Acos((a * a + b * b - c * c) / (2 * a * b));
            }
        }


        public static class ABGamma
        {
            public static double C(double a, double b, double gamma)
            {
                return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(gamma));
            }

            public static double Alpha(double a, double b, double gamma)
            {
                return Math.Atan(a * Math.Sin(gamma) / (b - a * Math.Cos(gamma)));
            }

            public static double Beta(double a, double b, double gamma)
            {
                return Math.Atan(b * Math.Sin(gamma) / (a - b * Math.Cos(gamma)));
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double[] xs = Quadratic.Roots(5, 6, 1);
            double[] ys = Quadratic.Roots(6, 7, -3);


            Console.WriteLine("x1 = {0}, x2 = {1}\n", xs[0], xs[1]);

            if (ys != null)
                Console.WriteLine("x1 = {0}, x2 = {1}\n", ys[0], ys[1]);

            double[] zs = Quadratic.Roots(10, -1, -2);
            if (zs != null)
                Console.WriteLine("x1 = {0}, x2 = {1}\n", zs[0], zs[1]);

            Point2D pt = Quadratic.Extreme(5, 6, 1);
            Console.WriteLine("x = {0}, y = {1}\n", pt.x, pt.y);

            // prevent closing of terminal when started from IDE/double-clicked in Windows
            Console.ReadLine();
        }
    }
}
