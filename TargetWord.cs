using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class TargetWord
    {
        private List <string> PossibleWords { get; set; } = new List<string> { "Desk", "Computer", "Duck", "Keyboard", "Terminal", "Input", "Feedback", "Bottle", "Deadline" };

        private string CurrentWord { get; set; }

        public char[] MaskedCurrentWord { get; set; }

        public TargetWord()
        {
            var random = new Random ();
            CurrentWord = PossibleWords[random.Next(0, PossibleWords.Count - 1)].ToLower();
            MaskedCurrentWord = MaskWord();
        }

        /// <summary>
        /// Resets current TargetWord object to game start state
        /// </summary>
        /// <param name="targetWord">Current TargetWord Object</param>
        /// <returns></returns>
        public TargetWord ResetTargetWord(TargetWord targetWord)
        {
            var random = new Random();
            CurrentWord = PossibleWords[random.Next(0, PossibleWords.Count - 1)].ToLower();
            MaskedCurrentWord = MaskWord();
            return targetWord;
        }

        /// <summary>
        /// Masks the current target word to _
        /// </summary>
        /// <returns></returns>
        public char[] MaskWord()
        {
            return new string('_', CurrentWord.Length).ToCharArray();
        }

        /// <summary>
        /// Reveals correct letters 
        /// </summary>
        /// <param name="guess">The player's currenttly guessed letter</param>
        /// <returns></returns>
        public bool RevealLetter(char guess)
        {
            bool isCorrect = false;
            for (int i = 0; i < CurrentWord.Length; i++)
            {
                if (CurrentWord[i] == guess)
                {
                    MaskedCurrentWord[i] = guess;
                    isCorrect = true;
                }
            }
            return isCorrect;
        }

        /// <summary>
        /// Prints the masked word in it's current state with correct letters revealed
        /// </summary>
        public void PrintMaskedWord()
        {
            for(int i = 0; i < MaskedCurrentWord.Length; i++)
            {
                Console.Write(MaskedCurrentWord[i]);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Checks if the word has been completely guessed
        /// </summary>
        /// <returns>Bool denominating whether the word has been guessed</returns>
        public bool WordGuessed()
        {
            string guessedWord = new string(MaskedCurrentWord);
            
            return guessedWord == CurrentWord;
        }

        /// <summary>
        /// Allows player to type in a new word to be added to the pool of possible words
        /// </summary>
        public void AddWord()
        {
            Console.WriteLine("Enter a new word:");
            while (true)
            {
                string? word = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(word) )
                {
                    PossibleWords.Add(word);
                    Console.WriteLine($"{word} was added to the list of the possible words");
                    Console.WriteLine("Press Enter to return to menu");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Erroneous input, try again");
                    continue;
                }
            }
        }
    }
}
