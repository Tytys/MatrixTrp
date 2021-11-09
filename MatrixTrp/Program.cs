using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTrp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("какой тип матрицы будет транспонирован?\nКвадратная / Не квадратная");
            string usl = Console.ReadLine();
            if (usl == "Квадратная")
            {
                SqrMatrix();
            }
            else if (usl == "Не квадратная")
            {
                NeSqrMatrix();
            }
        }
        static int[,] trpNonSqr(int[,] x)
        {
            int[,] arr1 = new int[x.GetLength(1), x.GetLength(0)];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    arr1[j, i] = x[i, j];
                }
            }
            return arr1;
        }
        static void NeSqrMatrix()
        {
            int N = In("Введите число строк"), N1 = In("Введите число столбцов");
            int[,] arr = new int[N, N1];
            arr = GetVal(arr);
            Console.WriteLine("Вывод готового массива");
            Print(arr);
            arr = trpNonSqr(arr);
            Console.WriteLine("Транспонированый\n");
            Print(arr);
            Console.ReadKey();
        }
        static int[,] GetValSqr(int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                string str = Console.ReadLine();
                int[] now = str.Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    x[i, j] = now[j];
                }
            }
            return x;
        }
        /* 
         * Если ввести что джитый эл равен итому, то тода программа
         * делает только первый столбец строкой, этот код изначально 
         * не работал потому что пробегал по всему массиву сначала перемещал, а потом возвращал на место
         * Сейчас код работает правильно потому что матрица квадратная и задавая условие
         * что j < i я пробегаюсь не по всему массиву и элементы правильно перемещаются 
         */
        static int[,] GetVal(int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.WriteLine("Введите значение элемента {0},{1}" , i , j);
                    x[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return x;
        }
        static void SqrMatrix()
        {
            int N = In("Введите размер квадратной матрицы");
            int[,] arr = new int[N, N];
            arr = GetValSqr(arr);
            arr = Trp(arr);
            Print(arr);
            Console.ReadKey();
        }
        static int[,] Trp(int[,] x)
        {
            int buffer;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    buffer = x[i, j];
                    x[i, j] = x[j, i];
                    x[j, i] = buffer;
                }
            }
            return x;
        }
        static void Print(int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.Write(x[i, j] + " ");
                }
            }
        }
        static int In(string str)
        {
            bool True;
            int x;
            do
            {
                Console.WriteLine(str);
                True = int.TryParse(Console.ReadLine(), out x);
            } while (!True);
            return x;
        }
    }
}
