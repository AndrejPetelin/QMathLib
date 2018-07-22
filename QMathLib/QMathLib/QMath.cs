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


    public static class Tools
    {
        // functions to convert Radians to Degrees and vice versa. 
        public static double DegToRad(double angle)
        {
            return angle * Math.PI / 180;
        }

        public static double RadToDeg(double radian)
        {
            return radian * 180 / Math.PI;
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
        /* Class with methods to solve "SSA Triangles" (two sides and an angle that is 
         * not the angle between the sides)
         * The methods work with Radians. There's converting functions above
         * TODO: In the calculation for alpha, Asin can give two different values (negative
         * and positive, or x so that alpha + x = 180). Account for that. 
         */
        public static class ACGamma
        {
            public static double Alpha(double a, double c, double gamma)
            {
                return Math.Asin((a * Math.Sin(gamma)) / c);
            }

            public static double Beta(double a, double c, double gamma)
            {
                return Math.PI - (Alpha(a, c, gamma) + gamma);
            }
            // overload to use in case we have already calculated alpha
            public static double Beta(double alpha, double gamma) 
            {
                return Math.PI - (alpha + gamma);
            }

            public static double B(double a, double c, double gamma)
            {
                double alpha = Alpha(a, c, gamma);
                double beta = Beta(alpha, gamma);
                return (Math.Sin(beta) * c) / Math.Sin(gamma);
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


            Double alpha = Triangle.ACGamma.Alpha(7.6, 12.4, Tools.DegToRad(125));
            Double beta = Triangle.ACGamma.Beta(7.6, 12.4, Tools.DegToRad(125));
            Double len = Triangle.ACGamma.B(7.6, 12.4, Tools.DegToRad(125));
            Console.WriteLine("Length: {0}\n", len);
            Console.WriteLine("alpha: {0}\n", Tools.RadToDeg(alpha));
            Console.WriteLine("beta: {0}\n", Tools.RadToDeg(beta));

            // prevent closing of terminal when started from IDE/double-clicked in Windows
            Console.ReadLine();
        }
    }
}
