using System;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                if(StringExtensions.IsAnagram(word,possibleAnagram))
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found
            var unique = word.ToCharArray().Distinct();
            foreach (char cr in unique)
            {

                int freq = 0;
                foreach (char c in word)
                {
                    if (c == cr)
                    {
                        freq++;
                    }
                }
                Console.WriteLine(string.Format("Char:{0}  Count:{1}", cr, freq));
            }
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b
            if (a.Length != b.Length)
                return false;
            var str1Array = a.ToLower().ToCharArray();
            var str2Array = b.ToLower().ToCharArray();
            Array.Sort(str1Array);
            Array.Sort(str2Array);
            a = new string(str1Array);
            b = new string(str2Array);
            return a == b;
        }
    }
}
