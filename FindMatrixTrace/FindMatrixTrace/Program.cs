using System;
using System.Text;
using System.Collections.Generic;
using FindMatrixTrace.Lib;
using FindMatrixTrace.Resources;

namespace FindMatrixTrace
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write(Messages.RequestHeightInput);
            var height = PromptUserMatrixDimension();
            Console.Write(Messages.RequestWidthInput);
            var width = PromptUserMatrixDimension();
            var matrix = new CustomMatrix(height, width);
            matrix.DisplayMatrix();
            Console.WriteLine($"\n{Messages.MatrixTraceSum} {matrix.GetTraceSum()}");
        }

        public static int PromptUserMatrixDimension()
        {
            var inputIsNumber = false;
            var number = 0;
            while (!(inputIsNumber && IsValidMatrixDimension(number)))
            {
                var userInput = Console.ReadLine();
                inputIsNumber = int.TryParse(userInput, out number);
                if (!inputIsNumber)
                {
                    Console.Write(Messages.InvalidInputFormat);
                }

                if (!IsValidMatrixDimension(number))
                {
                    Console.Write(Messages.InvalidInputValue);
                }
            }
            return number;
        }

        public static bool IsValidMatrixDimension(int number)
        {
            if (number >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
