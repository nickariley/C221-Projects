using System;
using System.Collections.Generic;


namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            PigLatinTranslator();
            Console.ReadLine();
        } //End Main Method Block

        static void PigLatinTranslator()
        {
            Console.WriteLine("PigLatinTranslator! Type in a word or sentence and I will return the PigLatin translation");
            //If word Starts & Ends w/Vowel add yay to end

            //If word Starts w/Vowel & Ends in Cons, move all letters before initial Vowel to End then ad ay to end of that

            //If word has no Vowel add ay to end

            //If word has a Vowel but starts with a consonant, move all letters before initial vowel to end then add ay

            string sentence = Console.ReadLine();
            Console.Write("\n");

            char[] vowel = { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };

            string ay = "ay";

            string yay = "yay";

            string[] splitSentence = sentence.Split(' ');

            foreach (string word in splitSentence)
            {
                //get first letter
                string firstLetter = word.Substring(0, 1);

                //get last letter
                string lastLetter = word.Substring(word.Length - 1);

                //no vowels 
                if (word.IndexOfAny(vowel) == -1)/*-1 equals false 0 = true*/
                {
                    Console.Write($"{word}{ay} ");

                }//End If in ForEach Block

                //else if 1st letter is a vowel
                else if (firstLetter.IndexOfAny(vowel) == 0)
                {
                    //and if last letter is a vowel
                    if (lastLetter.IndexOfAny(vowel) == 0)
                    {
                        Console.Write($"{word}{yay} ");
                    }

                    //and if last letter is a consonant
                    else /*if*/ //(_lastLetter.IndexOfAny(_consonant) == 0)
                    {
                        Console.Write($"{word}{ay} ");
                    }
                }//End Else If in ForEach Block

                else
                {   //find first vowel
                    int findFirstVowel = word.IndexOfAny(vowel);

                    //get the consonants before first vowel in a string 
                    string consToBeforeFirstVowel = word.Substring(0, findFirstVowel);

                    //get the letters from first vowel to end of word
                    string remainingWord = word.Substring(findFirstVowel);

                    Console.Write($"{remainingWord}{consToBeforeFirstVowel}{ay} ");

                }//End Else of ForEach Block



            }//End ForEach Loop Block

        }//End PigLatinTranslator Method Block

    }//End Program Class Block

}//End Namespace Block
