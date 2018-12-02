using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Collections;

namespace RobertHalfProblem2
{
    class Program
    {
        /*
My completion of this task is was very much colored my my background in mathematics.  
I covered matrix rotation in linear algebra and I initially wanted to use matrix multiplication to get a nice robust matrix rotator.
Then I realized that nowhere in the prompt did it say that the contents had to be numbers, and with it being an image there might be some hex digits in there.
So plan A was out.


Coming back to it the second time, the way the problem was worded made it sound like I was supposed to be using the actual MAtrix object from System.Drawing.Drawing2D which required an assembly reference. 
The initial instructions said not to use anything unusual, so I clarified with Ryan that this was not the way the input was being given.  

The third (and most obvious) approach was make a new matrix and populate it with the correct pieces from the original matrix.  
I assume that this is what was explicitly banned in the prompt. The wording on the ban was a bit confusing.

My fourth approach was simply using Linq to take an array of arrays and reorder them. 
Give everything an index and use it to make your rows your columns. Then just flip each subList around. 
I ran into a lot of problems making the multidimensional arrays want to convert to lists without just creating a blank list of lists to hold the results.

So I googled in situ transpositions and read the wiki article.  https://en.wikipedia.org/wiki/In-place_matrix_transposition
It had the psudo code for making a diagonal reflection and then I remembered from my math class that every rotation is just 2 reflections.  
So I did two reflections.

I wanted to include my thought process on this so that you can see the development process on this problem even though the result is not what I set out looking for.
It's probably not the best way to do it but I learned a lot on the way.


*/
        private static string[,] Test1
        {
            get
            {
                //The input type is string to allow for Hex Values
                string[,] input = new string[3, 3] {
                    { "1", "2", "3" },
                    { "4", "5", "6" },
                    { "7", "8", "9" }};
                return input;
            }
        }

        private static double[,] Test2
        {
            get
            {
                //If I was wrong and the input type was numbers, I need to be able to rotate them too.
                double[,] input = new double[3, 3] {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }};
                return input;
            }
        }
        private static double[,] Test3
        {
            get
            {
                //I wanted to test a bigger matrix square, and with an even number of boxes
                double[,] input = new double[4, 4] {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 10, 11, 12 },
                    {13, 14, 15, 16 } };
                return input;
            }
        }


        static void Main(string[] args)
        {
            //var input = Test1;
            //var input = Test2;
            var input = Test3;

            input = FlipDiagonally(input);
            input = FlipHorizontally(input);
            ShowResult(input);
        }

        public static T[,] FlipDiagonally<T>(T[,] input)
        {
            var ret = input;
            int columnCount = ret.GetLength(0);
            for (int x = 0; x <= columnCount - 2; x++)
            {
                for (int y = x + 1; y <= columnCount - 1; y++)
                {
                    var temp = ret[x, y];
                    ret[x, y] = ret[y, x];
                    ret[y, x] = temp;
                }
            }
            return ret;
        }
        public static T[,] FlipHorizontally<T>(T[,] input)
        {
            var ret = input;
            int columnCount = ret.GetLength(0);
            for (int y = 0; y <= columnCount - 1; y++)
            {
                for (int x = 0; x <= (columnCount / 2) - 1; x++)
                {
                    var z = columnCount - 1 - x;
                    var temp = ret[y, x];
                    ret[y, x] = ret[y, z];
                    ret[y, z] = temp;
                }
            }
            return ret;
        }

        public static void ShowResult<T>(T[,] result)
        {
            int columnCount = result.GetLength(0);
            for (int x = 0; x < columnCount; x++)
            {
                for (int y = 0; y < columnCount; y++)
                {
                    Console.Write(result[x, y] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
