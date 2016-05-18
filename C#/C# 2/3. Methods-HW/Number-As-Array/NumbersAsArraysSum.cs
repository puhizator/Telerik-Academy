﻿/*  8. Number as array
    Write a method that adds two positive integer numbers represented as arrays of digits 
    (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
    Write a program that reads two arrays representing positive integers and outputs their sum.
    Input:
    On the first line you will receive two numbers separated by spaces - the size of each array
    On the second line you will receive the first array
    On the third line you will receive the second array
    Output: Print the sum as an array of digits (as described)
            Digits should be separated by spaces
    Constraints: Each of the numbers that will be added could have up to 10 000 digits.
    Sample tests:
                    Input 	        Output
                    3 4
                    8 3 3
                    6 2 4 2 	    4 6 7 2

                    5 5
                    0 3 9 3 2
                    5 9 5 1 7 	    5 2 5 5 9                            */

using System;
using System.Collections.Generic;
using System.Linq;

class NumbersAsArraysSum
{
    static void Main()
    {
        Console.Write("Enter the first positive positive number: ");
        string firstNum = Console.ReadLine();
        Console.Write("Enter the second positive positive number: ");
        string secondNum = Console.ReadLine();

        if (IsCorrectNumber(firstNum) && IsCorrectNumber(secondNum))
        {
            List<int> result = AccumulateTwoNumbers(firstNum, secondNum);
            Console.WriteLine("Sum:");
            PrintResult(result);
        }
        else
        {
            Console.WriteLine("\nYou have entered invalid number(s).\n");
        }
    }

    static bool IsCorrectNumber(string number)
    {
        return number.All(t => t >= '0' && t <= '9');
    }

    static List<int> AccumulateTwoNumbers(string firstNum, string secondNum)
    {
        // Convert string to int[] according to the assignment to represent numbers as array of digits
        var firstArray = firstNum.Select(ch => ch - '0').ToArray();
        var secondArray = secondNum.Select(ch => ch - '0').ToArray();

        Array.Reverse(firstArray);
        Array.Reverse(secondArray);

        List<int> result = new List<int>(Math.Max(firstArray.Length, secondArray.Length));

        int left = 0;

        for (int i = 0; i < result.Capacity; i++)
        {
            int num = (i < firstArray.Length ? firstArray[i] : 0) + (i < secondArray.Length ? secondArray[i] : 0) + left;            
            result.Add(num % 10);
            left = num / 10;
        }

        if (left > 0) result.Add(left);

        return result;
    }

    static void PrintResult(List<int> result)
    {
        for (int i = result.Count - 1; i >= 0; i--)
        {
            Console.Write(result[i]);
        }
        Console.WriteLine("\n");
    }

}