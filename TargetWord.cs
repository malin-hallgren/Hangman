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

        //Resets the inputted object for a game restart
        public TargetWord ResetTargetWord(TargetWord targetWord)
        {
            var random = new Random();
            CurrentWord = PossibleWords[random.Next(0, PossibleWords.Count - 1)].ToLower();
            MaskedCurrentWord = MaskWord();
            return targetWord;
        }

        //Masks the current target word to _ by creating a char array the length of the word and filling with _
        public char[] MaskWord()
        {
            return new string('_', CurrentWord.Length).ToCharArray();
        }

        //checks guess against current word, and if the guess matches, exchanges the corresponding _ for the guessed letter
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

        //Prints the masked, or partially masked, word from the array with a slight delay for a dramatic effect
        public void PrintMaskedWord()
        {
            for(int i = 0; i < MaskedCurrentWord.Length; i++)
            {
                Console.Write(MaskedCurrentWord[i]);
                Thread.Sleep(100);
            }
        }

        //creates a string from the current masked word and compares against current word
        public bool WordGuessed()
        {
            string guessedWord = new string(MaskedCurrentWord);
            
            return guessedWord == CurrentWord;
        }

        //Allows player to input a new word into the pool
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
