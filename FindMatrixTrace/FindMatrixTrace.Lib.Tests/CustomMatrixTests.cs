using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindMatrixTrace.Lib;
namespace FindMatrixTrace.Lib.Tests
{
    [TestClass]
    public class CustomMatrixTests
    {
        [DataTestMethod]
        [DataRow(5,4)]
        [DataRow(6, 6)]
        [DataRow(1, 1)]
        [DataRow(3, 40)]
        public void CalculateTraceSumTest_ShouldReturnCorrectSumOfTraceElements(int height, int width)
        {
            var matrix = new CustomMatrix(height,width);
            int expected = 0;
            int shortestDimension = 0;
            if (height < width)
            {
                shortestDimension = height;
            }
            else
            {
                shortestDimension = width;
            }
            for (var i = 0; i < shortestDimension; i++)
            {
                expected += matrix.Matrix[i, i];
            }

            var actual = matrix.GetTraceSum();
            Assert.AreEqual(expected,actual);
        }

        [DataTestMethod]
        [DataRow(5, 4)]
        [DataRow(6, 6)]
        [DataRow(1, 1)]
        [DataRow(3, 40)]
        public void ConstructorTest_ShouldReturnCorrectMatrixDimensions(int height, int width)
        {
            var matrix = new CustomMatrix(height, width);
            var expected = (height, width);
            var actual = (matrix.Matrix.GetLength(0), matrix.Matrix.GetLength(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorTest_PopulationMethod_ShouldReturnMatrixWithValuesBetween0and100()
        {
            int height = 10;
            int width = 10;
            var matrix = new CustomMatrix(height, width);
            var expected = true;
            bool actual = true;
            foreach (var element in matrix.Matrix)
            {
                if (element < 0 || element > 100)
                {
                    actual = false;
                }
            }
            Assert.AreEqual(expected, actual);
        }

    }
}
