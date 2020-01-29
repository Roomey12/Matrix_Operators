using System;

namespace Epam_1
{
    class Matrix
    {
        int Row { get; set; }
        int Column { get; set; }

        public double[,] Array;
        public Matrix(int row, int column)
        {
            Row = row;

            Column = column;

            Array = new double[Row, Column];

            bool status = !true;
            while (!status)
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        try
                        {
                            Console.Write("Enter matrix element: ");
                            Array[i, j] = double.Parse(Console.ReadLine());
                            status = true;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            status = false;
                            break;
                        }
                    }
                    Console.WriteLine();
                    if (!status) break;
                }
            }
        }
        public Matrix()
        {
        }
        public double this[int i, int j]
        {
            get
            {
                if (i > Row - 1 || j > Column - 1) 
                    throw new MatrixException("There are no such index in matrix!");
                return Array[i, j];
            }
            set
            {
                Array[i, j] = value;
            }
        }
        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < Column * 6; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Console.Write("{0:0.0}", Array[i, j]);
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < Column * 6; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        public void Fill()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    //Random rnd = new Random();
                    //Array[i, j] = 10 + rnd.NextDouble() * (50 - 10);
                    Console.Write("Enter matrix element: ");
                    Array[i, j] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if(m1.Row != m2.Row || m1.Column != m2.Column)
            {
                throw new Exception("Impossible to sum matrices with different count of rows or columns!");
            }
            else
            {
                Matrix matrix = new Matrix();
                matrix.Row = m1.Row;
                matrix.Column = m1.Column;
                matrix.Array = new double[m1.Row, m1.Column];
                for (int i = 0; i < matrix.Row; i++)
                {
                    for (int j = 0; j < matrix.Column; j++)
                    {
                        matrix[i, j] = m1.Array[i,j] + m2.Array[i, j];
                    }
                }
                return matrix;
            }
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Column != m2.Column)
            {
                throw new Exception("Impossible to substract matrices with different count of rows or columns!");

            }
            else
            {
                Matrix matrix = new Matrix();
                matrix.Row = m1.Row;
                matrix.Column = m1.Column;
                matrix.Array = new double[m1.Row, m1.Column];
                for (int i = 0; i < matrix.Row; i++)
                {
                    for (int j = 0; j < matrix.Column; j++)
                    {
                        matrix.Array[i, j] = m1.Array[i, j] - m2.Array[i, j];
                    }
                }
                return matrix;
            }
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if(m1.Column != m2.Row)
            {
                throw new Exception("Impossible to multiply matrices!");
            }
            else
            {
                Matrix matrix = new Matrix();
                matrix.Row = m1.Row;
                matrix.Column = m2.Column;
                matrix.Array = new double[m1.Row, m2.Column];
                Console.WriteLine(matrix.Row + "  " + matrix.Column);
                for (int i = 0; i < m1.Row; i++)
                {
                    for (int j = 0; j < m2.Column; j++)
                    {
                        for (int k = 0; k < m2.Column; k++)
                        {
                            matrix.Array[i, j] += m1.Array[i, k] * m2.Array[k, j];
                        }
                    }
                }
                return matrix;
            }
        }
        public static Matrix operator *(Matrix m1, double op)
        {
            Matrix matrix = new Matrix();
            matrix.Row = m1.Row;
            matrix.Column = m1.Column;
            matrix.Array = new double[m1.Row, m1.Column];
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Column; j++)
                {
                    matrix.Array[i, j] = m1.Array[i, j] * op;
                }
            }
            return matrix;
        }
        public void RecreateMatrix()
        {
            Console.Write("Enter number of rows in matrix 1: ");
            int r = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of columns in matrix 1: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Row = r;
            Column = c;
            Array = new double[r, c];
            Fill();
        }
        public Matrix DeepCopy()
        {
            Matrix matrix = new Matrix();
            matrix.Row = Row;
            matrix.Column = Column;
            matrix.Array = new double[Row, Column];
            for(int i = 0; i < Row; i++)
            {
                for(int j = 0; j < Column; j++)
                {
                    matrix[i, j] = Array[i, j];
                }
            }
            return matrix;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows in matrix 1: ");
            int r1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of columns in matrix 1: ");
            int c1 = Convert.ToInt32(Console.ReadLine());
            Matrix matrix1 = new Matrix(r1, c1);

            //Matrix mat = matrix1.DeepCopy();
            //matrix1[0, 0] = 100;
            //mat.Print();

            Console.Write("Enter number of rows in matrix 2: ");
            r1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of columns in matrix 2: ");
            c1 = Convert.ToInt32(Console.ReadLine());
            Matrix matrix2 = new Matrix(r1, c1);

            matrix1.Print();
            matrix2.Print();

            Matrix matrix3;
            Matrix matrixTemp = null;

            while (true)
            {
                Console.WriteLine("1. Add matrices.");
                Console.WriteLine("2. Subtract 2 matrices.");
                Console.WriteLine("3. Multiply 2 matrices.");
                Console.WriteLine("4. Multiply matrix by number.");
                Console.WriteLine("5. Recreate matrices.");
                Console.Write("Select menu item: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        matrix3 = matrix1 + matrix2;
                        matrix3.Print();
                        break;
                    case 2:
                        matrix3 = matrix1 - matrix2;
                        matrix3.Print();
                        break;
                    case 3:
                        matrix3 = matrix1 * matrix2;
                        matrix3.Print();
                        break;
                    case 4:
                        matrix1.Print();
                        matrix2.Print();
                        while (matrixTemp == null)
                        {
                            Console.WriteLine("Choose matrix to multiply (1 or 2):");
                            int m = Convert.ToInt32(Console.ReadLine());
                            if (m == 1)
                            {
                                matrixTemp = matrix1;
                            }
                            else if (m == 2)
                            {
                                matrixTemp = matrix2;
                            }
                            else
                            {
                                Console.WriteLine("There is no such matrix! \nPlease try again!");
                            }
                        }
                        Console.Write("Enter the number to be multiplied: ");
                        double value = Convert.ToDouble(Console.ReadLine());
                        matrix3 = matrixTemp * value;
                        matrix3.Print();
                        matrixTemp = null;
                        break;
                    case 5:
                        Console.WriteLine();
                        matrix1.RecreateMatrix();
                        matrix2.RecreateMatrix();
                        matrix1.Print();
                        matrix2.Print();
                        break;
                    default:
                        Console.WriteLine("\nThere are no such menu item!\nPlease try again!\n");
                        break;

                }
            }
        }
    }
}
