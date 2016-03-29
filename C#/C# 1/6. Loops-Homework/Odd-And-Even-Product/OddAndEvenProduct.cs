﻿/*  Problem 10. Odd and Even Product
    You are given n integers (given in a single line, separated by a space).
    Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
    Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
Examples:
numbers 	        result
2 1 1 6 3 	        yes
product = 6 	
	
3 10 4 6 5 1 	    yes
product = 60 	
	
4 3 2 5 2 	        no
odd_product = 16 	
even_product = 15 	                                                 */

using System;
using System.Numerics;                                                  // must be added in References; needed for BigInteger

class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Enter integer numbers given in a single line, separated by a space: ");
        string line = Console.ReadLine();
        // define array of characters-separators ' '    [can be also { ' ', ',', '.' } - for space, comma and dot]
        char[] separators = new char[] { ' ' };
        /* define array of strings and using the built-in functionality of the method Split(…) from the class String, 
         * split the contents of a given Input (which is String) by array of characters–separators, 
           which are passed as an argument of the method. 
           All substrings among which is space will be removed and stored in the splitNumbers array.
         * For removing the empty elements after splitting, we add as a second parameter (argument) the constant 
           StringSplitOptions.RemoveEmptyEntries         so we instruct the method Split(…) to: 
         * Return all substrings from the variable that are split by given list of separators. 
         * Consider two or more neighboring separators as one. */
        string[] splitNumbers = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        BigInteger oddProduct = 1;
        BigInteger evenProduct = 1;
        for (int i = 0; i < splitNumbers.Length; i += 2)
        {
            oddProduct *= int.Parse(splitNumbers[i]);
        }
        for (int i = 1; i < splitNumbers.Length; i += 2)
        {
            evenProduct *= int.Parse(splitNumbers[i]);
        }
        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = " + oddProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = " + oddProduct);
            Console.WriteLine("even_product = " + evenProduct);
        }
    }
}