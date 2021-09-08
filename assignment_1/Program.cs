using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace assignment_1_DIS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is "+ rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */


        // write your code here
        private static bool HalvesAreAlike(string s)
        {
            try
            {
                int count = 0;    //declaring integer count to use in the loop.
                String vowels = "aeiouAEIOU";    //declaring the vowels small as well as capitalize one
                for (int i = 0, j = s.Length / 2; i < s.Length / 2; i++, j++)      //starting for loop and intializing i from zero to first half of the entered string and j from second half to end.
                {
                    if (vowels.IndexOf(s[i]) >= 0)      //applying if statement to check the string for first half vowel and then counting it
                    {
                        count++;
                    }
                    if (vowels.IndexOf(s[j]) >= 0)      // applying if statemnet to check the string for the second half of the vowel 
                    {
                        count--;
                    }
                }                               //ending of for loop
                return count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/

        // write your code here.
        private static bool CheckIfPangram(string str)
        {
            /*
             * the code takes a boolean array of size 26 to store flags if the english alphabets occur in the given sentence
             * for loop is used to traverse through the all the characters of given sentence.
             * We have a if condition to check it matches to the letter between A to Z OR if it matches to the letter between a to z.
             * If it matches then we put true at index value of this character in the sentence.
             * if in total we have 26 true values then the fuction returns TRUE else it returns FALSE.
             */

            try
            {
                bool[] pan = new bool[26]; //array of boolean of size 26

                int index = 0;

                for (int i = 0; i < str.Length; i++)     // starting for loop to check for panagram
                {      
                    if ('A' <= str[i] && str[i] <= 'Z')         //checking the capital alphabet
                        index = str[i] - 'A';

                    else if ('a' <= str[i] && str[i] <= 'z')     //checking the small aplhabet
                        index = str[i] - 'a';

                    else
                        continue;

                    pan[index] = true;
                }

                for (int i = 0; i <= 25; i++)
                    if (pan[i] == false)
                        return (false);

                return (true);
            }
            catch (Exception)
            {

                throw;
            }

        }



        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */

        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                int max = 0;
                for (int row = 0; row < accounts.GetLength(0); row++) //get length(0) returns index of last element in the row
                {
                    int sum = 0;
                    for (int col = 0; col < accounts.GetLength(1); col++) //get length(1) returns index of last element in the column 
                    {
                        sum += accounts[row, col];

                    }
                    max = Math.Max(max, sum);
                }
                return max;


            }
            catch (Exception)
            {
                throw;
            }
        }




        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */

        //the code traverse to length of stone and jewel and check if the letter in stone is equal to the letter in jewel
        //if yes then the counter is incremented by 1. and we return the couter.
        
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < stones.Length; i++)
                {
                    for (int j = 0; j < jewels.Length; j++)
                    {
                        if (jewels[j] == stones[i])
                        {
                            count++;
                        }

                    }
                }

                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("There is an error: " + e.Message);
                throw;
            }

        }






        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */


        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                int n;
                bool checklower;

                //constraints check 
                if (s.Length == indices.Length) //check 1 for the same entered length
                {
                    n = s.Length;
                    if (n >= 1 && n <= 100) //check 2 of all values between 1 and 100.
                    {
                        var regex = new Regex("^[a-z]+$");
                        checklower = regex.IsMatch(s); //check 3 string contains only small english alphabet
                        if (checklower == true)
                        {
                            bool isduplicate = false;
                            for (int k = 0; k < indices.Length; k++) //check 4 unique elements in indices 
                            {
                                //bool isduplicate = false;
                                for (int j = 0; j < k; j++)
                                {
                                    if (indices[k] == indices[j])
                                    {
                                        isduplicate = true;
                                        break;
                                    }
                                    else
                                        isduplicate = false;
                                }
                            }
                            if (isduplicate == false)
                            {
                                //convert string to char array 
                                char[] res = new char[s.Length];

                                //assigning values as per indices 
                                for (int i = 0; i < s.Length; i++)
                                    res[indices[i]] = s[i];
                                //getting array to string again
                                string result = new string(res);

                                return result;
                            }
                            else
                                Console.WriteLine("Constraint check for unique array of indices fails"); //check 4 ends 
                            return null;
                        }
                        else
                            Console.WriteLine("Constraint check for lower case english letters fails");
                        return null;//check 3 ends 
                    }
                    else
                        Console.WriteLine("Constraint check for indices values beteen 1 to 100 fails");
                    return null;//check 2 ends 
                }
                else
                    Console.WriteLine("Constraint check for length of input string and indices fails");
                return null; //check 1 ends              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }



        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {
                int[] target = new int[index.Length];
                List<int> newTarget = new List<int>(index.Length);  //
                for (int i = 0; i < index.Length; i++)
                {
                    newTarget.Insert(index[i], nums[i]);
                }
                target = newTarget.ToArray();
                return target;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
// self reflection-
/*
 *It took me 6 days to complete the coding excercise, I tried one problem in a day as it takes time to get accustomed to a new language and syntax.
 *I learned the use of Leetcode, stackoverflow, github tried to solve some extra problems using this platfor before attempting the above poblems
 *It was very healthy excercise as it made me understanding the concepts and logic from very elementary level.
 *I would recommend to add some more problem of same kind but with different tweaks in it. I learned several kind of approaches as I started solving the above excercise.
 */