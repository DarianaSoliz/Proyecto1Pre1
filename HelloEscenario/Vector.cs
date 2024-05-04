using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEscenarioRotatorio
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void SetVector(Vector vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(
            a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector operator *(Vector a, Matrix3 b) => new Vector(
            a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31,
            a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32,
            a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33);

        public static Vector operator /(Vector a, Vector b) => new Vector(
            a.X / b.X, a.Y / b.Y, a.Z / b.Z);

        public static Vector operator *(Vector a, Matrix4 b) => new Vector(
            a.X * b.M11 + a.Y * b.M21 + a.Z * b.M31 + 1f * b.M41,
            a.X * b.M12 + a.Y * b.M22 + a.Z * b.M32 + 1f * b.M42,
            a.X * b.M13 + a.Y * b.M23 + a.Z * b.M33 + 1f * b.M43);


    }
}
