using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class GameLogic
    {
        private TargetWord TargetWord { get; set; } //these two are not to be accessed from the outside. 
        private HashSet<char> _guessedLeters = new HashSet<char>(); //_guessedLetter is fully private, it should not be touched!
        public int FaultyGuess { get; set; }
        
        public GameLogic(TargetWord targetWord)
        {
            TargetWord = targetWord;
            FaultyGuess = 0;
        }

        /// <summary>
        /// Resets game properties to restart game
        /// </summary>
        /// <param name="targetWord">The word object to use</param>
        /// <param name="gameLogic">The GameLogic object to use, and return</param>
        /// <returns>The same GameLogic object as was inputted, but modified</returns>
        public GameLogic ResetGameLogic(TargetWord targetWord, GameLogic gameLogic)
        {
            TargetWord = targetWord;
            _guessedLeters.Clear();
            FaultyGuess = 0;

            return gameLogic;
        }

        /// <summary>
        /// Checks player guess against target word
        /// </summary>
        public void CheckGuess()
        {
            bool validGuess = false;
            Console.Write("\nYour current guess is: ");
            while (!validGuess)
            {
                Console.WriteLine();
                char guess = Console.ReadKey().KeyChar;

                if (char.IsLetter(guess) && _guessedLeters.Add(guess))
                {
                    guess = char.ToLower(guess);
                    if (!TargetWord.RevealLetter(guess))
                    {
                        FaultyGuess++;
                    }
                    validGuess = true;
                }
                else
                {
                    Console.WriteLine("\nErroneous input, try again");
                }
            }
        }

        /// <summary>
        /// Prints all previously guessed letters to console
        /// </summary>
        public void PrintPreviousGuesses()
        {
            Console.Write("\nYou have previously guessed: ");
            foreach (char letter in _guessedLeters)
            {

                Console.Write($"{letter} ");
            }
        }

    }
}
