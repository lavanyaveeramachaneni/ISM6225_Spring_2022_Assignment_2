/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1  = "horse";
            string word2 = "ros";
            int minLen = MinDistance( word1,  word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        /* Recomendations: https://www.khanacademy.org/computing/computer-science/algorithms/binary-search/a/binary-search#:~:text=Binary%20search%20is%20an%20efficient,possible%20locations%20to%20just%20one. 
         */
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int left = 0, right= nums.Length-1;
                //looping over the given array from left to right
                while(left < right)
                {
                    //Finding the Mid element of the array and returning mid element if is is target element
                    int mid = left+(right-left)/2;
                    if(nums[mid] == target)
                        return mid;
                    //travelling to the right as target is smaller than mid
                    if (nums[mid] > target)
                        right = mid - 1;
                    //travelling to the right as target is larger than mid
                    else
                        left = mid + 1;
                }
                return left;
             }//whhile end here
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        /* https://www.tutorialspoint.com/csharp/csharp_regular_expressions.htm 
         https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
         */
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                paragraph = paragraph.ToLower();
                //using Regular expression for replacing characters other than a-z with space
                var regexItem = new Regex(@"[^a-z ]+");
                paragraph = regexItem.Replace(paragraph, String.Empty);
                //replacing banned words with empty
                foreach (string b in banned)
                    paragraph = paragraph.Replace(b, string.Empty);
                //Creating dictonary for storing string and it's occurance.
                Dictionary<string, int> dict = new Dictionary<string, int>();
                //paragraph array to remove empty entries of banned words and spliiting with space
                string[] paraArray = paragraph.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //Adding strings to the dictonary 
                foreach (string item in paraArray)
                {
                    if (!dict.ContainsKey(item))
                        dict.Add(item, 1);
                    else
                        dict[item]++;
                }//foreach ends here
                //returning Maximum repeated non banned key value
                return dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        /* https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/ */

        public static int FindLucky(int[] arr)
        {
            try
            {
                int luckyNum = -1;
                var dict = new Dictionary<int, int>();
                //Adding elemnts and updating element keys with their frequency
                foreach (var n in arr)
                {
                    //element is repeated, incrmenating value
                    if (dict.ContainsKey(n))
                        dict[n]++;
                    else
                        dict.Add(n, 1);
                }
                foreach (var li in dict)
                {
                    //comparing Key and values which are added in dictonary and returing max key
                    if (li.Key == li.Value)
                        luckyNum = Math.Max(luckyNum, li.Key);
                }
                return luckyNum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        /* Learned how to use loops efficiently and learned about different strings operations */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                string tmp1, tmp2;
                tmp1 = secret;
                tmp2 = guess;
                int bulls = 0;
                int cows = 0;
                int currentIndex = 0;
                int index = 0;
                //Looping on secret string
                while (index < tmp1.Length)
                {
                    //if both secret and guess values are equal, removing it from string and incrementing bull value
                    if (tmp1[index] == tmp2[index])
                    {
                        secret = secret.Remove(currentIndex, 1);
                        guess = guess.Remove(currentIndex, 1);
                        bulls++;
                    }
                    else//incrementing currentindex and index value t0 go to the next location
                        currentIndex++;
                    index++;
                }
                //If secret string modified, looping on it otherwise travelling on original secret string 
                for (int i = 0; i < secret.Length; i++)
                {
                    //if guess number is in secret string remove that from guess string and incrment cow value
                    if (guess.Any(k => k == secret[i]))
                    {
                        guess = guess.Remove(guess.IndexOf(secret[i]), 1);
                        cows++;
                    }
                }
                return $"{bulls}A{cows}B";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        /* Learned how to use loops efficiently and learned about different strings operations 
         https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/ 
        */
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int lastIndex = 0;
                int currentIndex = 0;
                int start = 0;
                List<int> result = new List<int>();
                //storing original string into tmp
                string tmp = s;
                while (s.Length > 0)
                {
                    //identify the last index of each character on temporary string
                    if (lastIndex < tmp.LastIndexOf(s[0]))
                        lastIndex = tmp.LastIndexOf(s[0]);
                    //remove charcater after setting of lastindex
                    s = s.Remove(0, 1);
                    if (lastIndex == currentIndex)
                    {
                        //storing the remaining string after each partition
                        tmp = s;
                        //adding the index value to the list
                        result.Add((currentIndex) + 1);
                        //resetting index values to 0
                        lastIndex = currentIndex = 0;
                    }
                    else
                        currentIndex++;
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        /* 
         https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
        https://www.c-sharpcorner.com/article/get-string-ascii-value/
         */
        public static List<int> NumberOfLines(int[] widths,string s)
        {
            try
            {
                //write your code here.
                List<int> lines = new List<int>();
                Dictionary<char, int> dict = new Dictionary<char, int>();
                int j = 0;
                int currentPixelCount = 0;
                int linesCount = 1;
                //Adding Ascii characters to dictonary with the given widths as values
                for (int i = 97; i < 123; i++, j++)
                    dict.Add((char)i, widths[j]);
                foreach (var item in s.ToCharArray())
                {
                    //adding each item value untill it's total is 100
                    if (currentPixelCount + dict[item] <= 100)
                        currentPixelCount += dict[item];
                    //if it's more than 100 with given input, add remaining items in another line
                    else
                    {
                        currentPixelCount = 0;
                        currentPixelCount += dict[item];
                        linesCount++;
                    }
                }
                return new List<int>() { linesCount, currentPixelCount };//returing last line and it's pixel count
              }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        /* https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
         https://www.tutorialsteacher.com/csharp/csharp-dictionary 
         */
        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //if string is odd return false
                if (bulls_string10.Length % 2 == 1) return false;
                //Creating dictonary and adding combinations to dictonary as Key,values
                Dictionary<char, char> combinations = new Dictionary<char, char>();
                combinations.Add('(', ')');
                combinations.Add('{', '}');
                combinations.Add('[', ']');
                List<char> list = new List<char>();
                foreach (char begin in bulls_string10.ToCharArray())
                {
                    //Adding all open braces to the list
                    if (begin == '[' || begin == '{' || begin == '(')
                        list.Add(begin);
                    else if (list.Count > 0)
                    {
                        //Comparing braces and, both the characters represent one complete combination, remove that combination from list
                        if (list[list.Count - 1] == combinations.Where(k => k.Value == begin).Select(p => p.Key).Single())
                            list.RemoveAt(list.Count - 1);
                        //otherwise break
                        else
                            break;
                    }
                    else return false;//returing false if ther is no open braces.
                }
                return list.Count == 0;//returning true if final list count is 0.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */
        /* https://www.programmersranch.com/2013/05/c-basics-morse-code-converter-using.html 
         https://www.tutorialsteacher.com/csharp/csharp-stringbuilder
         */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //Adding all morse charcaters into string array
                string[] morseCharacter = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                HashSet<string> hs = new HashSet<string>();
                //traversing on given string array
                for (int i = 0; i < words.Length; i++)
                {
                    var sb = new StringBuilder();
                    //appending each charcater into string builder
                    foreach (var ch in words[i])
                        sb.Append(morseCharacter[ch - 'a']);
                    //Adding it to hashset to remove duplicates
                    hs.Add(sb.ToString());
                }
                return hs.Count();//returning count of hashset
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }

        }

      


        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
