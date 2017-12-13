using System;
using System.Collections.Generic;
using System.Globalization;

namespace KVector.Vector
{
    public class Vector : BaseVector,IEquatable<Vector>, IFormattable
    {
        /// <summary>
        /// X coordinate of the 3D vector.
        /// </summary>
        public int X
        {
            get { return Coordinates[0]; }
            set { Coordinates[0] = value; }
        }
        /// <summary>
        /// Y coordinate of the 3D vector.
        /// </summary>
        public int Y
        {
            get { return Coordinates[1]; }
            set { Coordinates[1] = value; }
        }

        /// <summary>
        /// Z coordinate of the 3D vector.
        /// </summary>
        public int Z
        {
            get { return Coordinates[2]; }
            set { Coordinates[2] = value; }
        }

        /// <summary>
        /// Length of the 3D vector.
        /// </summary>
        public double Length
        {
            get
            {
                double sum = 0;
                foreach (var coordinate in Coordinates)
                {
                    sum += Math.Pow(coordinate, 2);
                }
                return Math.Round(Math.Sqrt(sum), 2);
            }
        }
        /// <summary>
        /// Constructor class Vector
        /// </summary>
        public Vector() : this(0, 0, 0)
        {
        }
        /// <summary>
        /// Constructor class Vector
        /// </summary>
        /// <param name="x">X coordinate of the vector</param>
        /// <param name="y">Y coordinate of the vector</param>
        /// <param name="z">Z coordinate of the vector</param>
        public Vector(int x, int y, int z) : base(new [] {x, y, z})
        {
        }

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="firstVector">First vector</param>
        /// <param name="secondVector">Second vecrot</param>
        /// <returns></returns>
        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            var result = Addition(new List<BaseVector>() {firstVector, secondVector}, 3);
            return new Vector(result.Coordinates[0], result.Coordinates[1], result.Coordinates[2]);
        }
        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="firstVector">First vector</param>
        /// <param name="secondVector">Second vecrot</param>
        /// <returns></returns>
        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            var result = Subtraction(new List<BaseVector>() { firstVector, secondVector }, 3);
            return new Vector(result.Coordinates[0], result.Coordinates[1], result.Coordinates[2]);
        }

        /// <summary>
        /// Returns scalar product of vectors
        /// </summary>
        /// <param name="firstVector">First vector</param>
        /// <param name="secondVector">Second vecrot</param>
        /// <returns></returns>
        public static double operator *(Vector firstVector, Vector secondVector)
        {
            return Multiply(new List<BaseVector>(){firstVector,secondVector},3 );
        }

        /// <summary>
        /// Returns a new vector as a result of vector product of two vectors
        /// </summary>
        /// <param name="other">Second vecrot</param>
        /// <returns></returns>
        public Vector CrossProduct(Vector other)
        {
            return new Vector()
            {
                X = Coordinates[1] * other.Coordinates[2] -
                    Coordinates[2] * other.Coordinates[1],
                Y = 0 - (Coordinates[0] * other.Coordinates[2] -
                         Coordinates[2] * other.Coordinates[0]),
                Z = Coordinates[0] * other.Coordinates[1] -
                    Coordinates[1] * other.Coordinates[0],
            };
        }

        /// <summary>
        /// Returns mixed product of three vectors
        /// </summary>
        /// <param name="secondVector">Second vector</param>
        /// <param name="thirdVector">Third vector</param>
        /// <returns></returns>
        public double TripleProduct(Vector secondVector, Vector thirdVector)
        {
            return Coordinates[0] * secondVector.Coordinates[1] * thirdVector.Coordinates[2] +
                   Coordinates[1] * secondVector.Coordinates[2] * thirdVector.Coordinates[0] +
                   Coordinates[2] * secondVector.Coordinates[0] * thirdVector.Coordinates[1] -
                   Coordinates[2] * secondVector.Coordinates[1] * thirdVector.Coordinates[0] -
                   Coordinates[1] * secondVector.Coordinates[0] * thirdVector.Coordinates[2] -
                   Coordinates[0] * secondVector.Coordinates[2] * thirdVector.Coordinates[1];
        }
        /// <summary>
        /// Returns the angle value between two vectors
        /// </summary>
        /// <param name="other">Second vector</param>
        /// <returns></returns>
        public double AngleBetweenVectors(Vector other)
        {
            return Math.Round((this * other) /(Length* other.Length),2);
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object
        /// </summary>
        /// <param name="other">Second vector</param>
        /// <returns></returns>
        public bool Equals(Vector other)
        {
            if (other != null && (X == other.X && Y == other.Y && Z == other.Z))
            {
                return true;
            }
                return false;
        }

        public override string ToString()
        {
            return ToString("",CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"X={X}, Y={Y}, Z={Z}";
        }
    }
}
