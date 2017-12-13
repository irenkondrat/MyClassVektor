using System.Collections.Generic;

namespace KVector
{
    public class BaseVector
    {
        /// <summary>
        /// Сoordinates of the vector
        /// </summary>
        internal int[] Coordinates { get; set; }

        /// <summary>
        /// Constructor class BaseVector
        /// </summary>
        /// <param name="coordinates">coordinates of the vector</param>
        protected BaseVector(int[]coordinates)
        { 
            Coordinates = new int[coordinates.Length];
            Coordinates = coordinates;
        }

        /// <summary>
        /// Constructor class BaseVector
        /// </summary>
        /// <param name="countCoordinate">number of coordinates of the vector</param>
        protected BaseVector(int countCoordinate)
        {
            Coordinates = new int[countCoordinate];
        }
        /// <summary>
        /// Returns scalar product of vectors.
        /// </summary>
        /// <param name="vectors">vectors</param>
        /// <param name="countCoordinate">number of coordinates of the vecto</param>
        /// <returns></returns>
        protected static double Multiply(List<BaseVector> vectors, int countCoordinate)
        {
            double sum = 0;
        
            for (var i = 0; i < countCoordinate; ++i)
            {
                double mult = 1;
                foreach (var t in vectors)
                {
                    mult *=  t.Coordinates[i];
                }
                sum += mult;
            }
            return sum;
        }
        /// <summary>
        /// Returns the scalar product of the vector 
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="values">scalar</param>
        /// <returns></returns>
        protected static BaseVector Multiply(BaseVector vector, int values)
        {
            BaseVector resultVector = new BaseVector(vector.Coordinates.Length);

            for (var i = 0; i < vector.Coordinates.Length; ++i)
            {
                resultVector.Coordinates[i] = values * vector.Coordinates[i];
            }
            return resultVector;
        }
        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="vectors">vectors</param>
        /// <param name="countCoordinate">number of coordinates of the vecto</param>
        /// <returns></returns>
        protected static BaseVector Subtraction(List<BaseVector> vectors, int countCoordinate)
        {
            BaseVector resultVector = new BaseVector(countCoordinate);
            for (var i = 0; i < countCoordinate; ++i)
            {
                    resultVector.Coordinates[i] = vectors[0].Coordinates[i]- vectors[1].Coordinates[i];
            }
            return resultVector;
        }
        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="vectors">vectors</param>
        /// <param name="countCoordinate">number of coordinates of the vecto</param>
        /// <returns></returns>
        protected static BaseVector Addition(List<BaseVector> vectors, int countCoordinate)
        {
            BaseVector resultVector= new BaseVector(countCoordinate);
            for (var i = 0; i < countCoordinate; ++i)
            {
                foreach (var t in vectors)
                {
                    resultVector.Coordinates[i] += t.Coordinates[i];
                }
            }
            return resultVector;
        }
        
    }
}

