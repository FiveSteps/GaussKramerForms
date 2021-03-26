using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaussKramerProjectForms
{
    public partial class KramerPage : Form
    {
        public KramerPage()
        {
            InitializeComponent();
        }
        class Calculator
        {
            private int numberOfEquations;
            private char[] indeterminates;
            private List<string> equations;

            public Calculator()
            {
                SetNumberOfEquations(3);
                CreateIndeterminatesNames();
                InitializeEquations();
            }

            public int GetNumberOfEquations()
            {
                return numberOfEquations;
            }

            public void SetNumberOfEquations(int number)
            {
                if (number != 3)
                {
                    throw new NotImplementedException();
                }

                numberOfEquations = number;
            }

            private void CreateIndeterminatesNames()
            {
                indeterminates = new char[] { 'x', 'y', 'z' };
            }

            private void CalculateMatrxDeterminant(int dimension)
            {
                // To implement thae function you can use Chio's method (more info: [url]https://www.youtube.com/watch?v=_JetUVpvFAU[/url])
            }

            /// <summary>
            /// Temporary function replacing the generic one above
            /// </summary>
            private float Calculate3x3MatrixDeterminant(float[] matrix)
            {
                // Here I use single dimensional array for the matrix:
                // [0][1][2]
                // [3][4][5]
                // [6][7][8]

                if (matrix.Count() != 9)
                {
                    throw new IndexOutOfRangeException();
                }

                float first = matrix[4] * matrix[8] - matrix[5] * matrix[7];
                float second = matrix[3] * matrix[8] - matrix[5] * matrix[6];
                float third = matrix[3] * matrix[7] - matrix[4] * matrix[6];

                return matrix[0] * first - matrix[1] * second + matrix[2] * third;
            }

            public static string[] GetReadMeContent()
            {
                return new string[]
                {
                "Greetings, friend!",
                "I am a little program calculating the very simple system of equations (3 only yet).",
                "You will be prompted to enter the equations by the following scheme: ax+by+cz=d",
                "'x', 'y', 'z' characters represent indeterminates and all should be contained within the equation.",
                "Indeterminates should be contained within the equation only once and only on the left side of the equal sign",
                "Equal sign must be followed by the number only",
                "'a', 'b', 'c' and 'd' characters must be replaced with integer numbers with '+' or '-' sign in front of it only",
                "For example: 2x-5y+0.3z=25",
                "'a', 'b', 'c' or 'd' cannot be zeros, since they collapse the variable.",
                "Numbers with fraction or functions are not allowed either.",
                "You can use spaces within the equation."
                };
            }

            public Tuple<string, bool> TryAddEquation(string equation)
            {
                if (equation.Count(c => c == '=') != 1)
                {
                    return Tuple.Create("Equal sign should be appearing in the equation only once!", false);
                }

                int result;
                if (!int.TryParse(equation.Split('=').Last(), out result))
                {
                    return Tuple.Create("An integer number only must be followed by the '='", false);
                }

                foreach (char indeterminate in indeterminates)
                {
                    if (equation.Count(c => c == indeterminate) != 1)
                    {
                        return Tuple.Create("The " + indeterminate.ToString() + " must be appearing in the equationonly once!", false);
                    }
                }

                if (equation.Count(c => c == '*') > 0)
                {
                    return Tuple.Create("Cannot use multiplication here yet", false);
                }

                if (equation.Count(c => c == '/') > 0)
                {
                    return Tuple.Create("Cannot use division here yet", false);
                }

                // Add other tests to make sure the equations follows the rules:
                // 1). Make sure other characters not used
                // 2). Make sure equations are not the same
                // 3). Make sure variables follow the order (x first, y next and z last) or do the mapping when calculating results
                // 4). Consider some other validations maybe? 

                equations.Add(equation.Replace(" ", "").Replace("+", ""));

                return Tuple.Create("Equation was successfully read.", true);
            }

            public void InitializeEquations()
            {
                equations = new List<string>();
            }

            /// <summary>
            /// Remember, it works only on 3x3 matrices for now
            /// </summary>
            public string[] CalculateResults()
            {
                /*equations.Add("2x+5y+4z=30");
                equations.Add("x+3y+2z=150");
                equations.Add("2x+10y+9z=110");*/

                if (!equations.Any())
                {
                    throw new ArgumentOutOfRangeException();
                }

                var matrix = PopulateMatrix();

                var det = Generate3x3MatrixFrom3x4Matrix(matrix, new int[] { 0, 1, 2, 4, 5, 6, 8, 9, 10 });
                float[] determinants = new float[indeterminates.Length];
                determinants[0] = Generate3x3MatrixFrom3x4Matrix(matrix, new int[] { 3, 1, 2, 7, 5, 6, 11, 9, 10 });
                determinants[1] = Generate3x3MatrixFrom3x4Matrix(matrix, new int[] { 0, 3, 2, 4, 7, 6, 8, 11, 10 });
                determinants[2] = Generate3x3MatrixFrom3x4Matrix(matrix, new int[] { 0, 1, 3, 4, 5, 7, 8, 9, 11 });

                string[] results = new string[indeterminates.Length];

                for (int i = 0; i < indeterminates.Length; i++)
                {
                    float result = determinants[i] / det;
                    results[i] = indeterminates[i].ToString() + " = " + result.ToString();
                }

                return results;
            }

            private float Generate3x3MatrixFrom3x4Matrix(float[] matrix3x4, int[] indices)
            {
                int count = indeterminates.Count();
                int initialSize = count * (count + 1);
                int targetSize = count * count;

                if (matrix3x4.Length != initialSize)
                {
                    throw new IndexOutOfRangeException();
                }

                if (indices.Length != targetSize)
                {
                    throw new IndexOutOfRangeException();
                }

                float[] matrix = new float[targetSize];
                for (int i = 0; i < targetSize; i++)
                {
                    matrix[i] = matrix3x4[indices[i]];
                }

                return Calculate3x3MatrixDeterminant(matrix);
            }

            private float[] PopulateMatrix()
            {
                StringBuilder builder = new StringBuilder();
                int index = 0;
                int numberOfIndeterminates = indeterminates.Count();
                int matrixSize = numberOfIndeterminates * (numberOfIndeterminates + 1);
                float[] matrix = new float[matrixSize];

                foreach (string equation in equations)
                {
                    var parts = equation.Split('=');
                    string firstPart = parts[0];
                    var coefficients = firstPart.Split(indeterminates).ToList();
                    coefficients[coefficients.Count - 1] = parts[1];

                    for (int i = 0; i < coefficients.Count; i++)
                    {
                        if (coefficients[i] == string.Empty)
                        {
                            coefficients[i] = "1";
                        }
                        else if (coefficients[i] == "-")
                        {
                            coefficients[i] = "-1";
                        }

                        matrix[index] = float.Parse(coefficients[i]);
                        index++;
                    }
                }

                return matrix;
            }
        }
    }
}
