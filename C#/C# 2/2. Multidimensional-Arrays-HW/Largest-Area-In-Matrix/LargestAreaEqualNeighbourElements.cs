﻿/*  Problem 7. Largest area in matrix
    Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
    Input: On the first line you will receive the numbers N and M separated by a single space
    On the next N lines there will be M numbers separated with spaces - the elements of the matrix
    Output: Print the size of the largest area of equal neighbour elements
    Constraints: 3 <= N, M <= 1024
    Sample test:
                    Input 	        Output
                    5 6             13
                    1 3 2 2 2 4
                    3 3 3 2 4 4
                    4 3 1 2 3 3
                    4 3 1 3 3 1
                    4 3 3 3 1 1 	
   Hint: you can use the algorithm Depth-first search or Breadth-first search.  */

using System;

class LargestAreaEqualNeighbourElements
{
    static int answer = 0;
    static int absolutemax = 0;
    static int[,] matrix;

    static void Main()
    {
        // Read the matrix dimensions
        string[] sizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(sizes[0]);
        int cols = int.Parse(sizes[1]);

        // Create (Allocate) the matrix
        matrix = new int[rows, cols];

        // Enter the matrix elements
        for (int row = 0; row < rows; row++)
        {
            string[] inputRows = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0, count = 0; col < cols; col++, count++)
            {
                matrix[row, col] = int.Parse(inputRows[count]);
            }
        }

        // Find the largest area of equal neighbour elements
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                FindTheArea(i, j, matrix[i, j]);
                answer = 0;
            }
        }

        // Output
        Console.WriteLine(absolutemax);
    }

    private static void FindTheArea(int i, int j, int currelement)
    {
        //returns if we are out of the matrix or the element is not the same
        if ((currelement == 0) || (i < 0) || (i >= matrix.GetLength(0)) || (j < 0) || (j >= matrix.GetLength(1)))
        {
            return;
        }

        if (matrix[i, j] == currelement)
        {
            matrix[i, j] = 0;

            answer++;

            if (absolutemax < answer)
            {
                absolutemax = answer;
            }

            FindTheArea(i + 1, j, currelement);

            FindTheArea(i - 1, j, currelement);

            FindTheArea(i, j + 1, currelement);

            FindTheArea(i, j - 1, currelement);

            matrix[i, j] = currelement;
        }
    }

}