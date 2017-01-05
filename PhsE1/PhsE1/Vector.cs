using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhsE1
{
    public interface IVector
    {
        Vector Add(Vector v2);
        Vector Subtract(Vector v2);
        Vector Negate();
        Vector Multiply(double s);
        double Magnitude();
        double DotProduct(Vector v2);
        Vector CrossProduct(Vector v2);
    }

    public class Vector : IVector
    {
        private double x;
        private double y;
        private double z;
        private const double DegToRad = Math.PI/180;

        public Vector()
        {
            x = 0.0;
            y = 0.0;
            //z = 0.0;
        }

        public Vector(double t1, double t2)//, double t3)
        {
            x = t1;
            y = t2;
            //z = t3;
        }

        public Vector Add(Vector v2)
        {
            return new Vector(x + v2.x, y + v2.y);//, z + v2.z);
        }

        public Vector Subtract(Vector v2)
        {
            var vNeg = v2.Negate();
            return Add(vNeg);
        }

        public Vector Negate()
        {
            return new Vector(-x, -y);//, -z);
        }

        public Vector Multiply(double s)
        {
            return new Vector(x*s, y*s);//, z*s);
        }

        public double Magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));// + Math.Pow(z,2));
        }

        public double DotProduct(Vector v2)
        {
            return ((x*v2.x) + (y*v2.y));
        }

        public Vector CrossProduct(Vector v2)
        {

        }

        public Vector Rotate(double degrees)
        {
            return RotRadians(degrees*DegToRad);
        }

        public double Angle()
        {
            return Math.Atan(y/x);
        }

        public Vector RotRadians(double rad)
        {
            var ca = Math.Cos(rad);
            var sa = Math.Sin(rad);
            return new Vector(ca*x - sa*y, sa*x + ca*y);
        }
    }
}
