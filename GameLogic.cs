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
        private TargetWord TargetWord { get; set;  } //these two are not to be accessed from the outside. 
        private HashSet<char> _guessedLeters = new HashSet<char>(); //_guessedLetter is fully private, it should not be touched!
        public int FaultyGuess { get; set; }
        private string[] MenuOptions = { "Start Game", "Add Words", "Exit Game" }; //The menu options will neever change at runtime
        public GameLogic(TargetWord targetWord) 
        { 
            TargetWord = targetWord;
            FaultyGuess = 0;
        }

        public GameLogic ResetGameLogic(TargetWord targetWord, GameLogic gameLogic) 
        {
            TargetWord = targetWord;
            _guessedLeters.Clear();
            FaultyGuess = 0;

            return gameLogic;
        }

        //Asks player to input their guess, checks if correct, if not correct itterates the faulty guess
        //error manages input
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
                    if(!TargetWord.RevealLetter(guess))
                    {
                        FaultyGuess++;
                    }
                    validGuess = true;
                }
                else
                {
                    Console.WriteLine("Erroneous input, try again");
                }
            }
        }

        //prints previously guessed letter
        public void PrintPreviousGuesses()
        {
            Console.Write("\nYou have previously guessed: ");
            foreach (char letter in _guessedLeters)
            {
                
                Console.Write($"{letter} ");
            }
        }

        //Runs the actual start menu logic
        public bool StartMenu()
        {
            while (true)
            {
                int selected = MakeMenuChoice();

                switch(selected)
                {
                    case 0:
                        return true;
                    case 1:
                        TargetWord.AddWord();
                        break;
                    case 2:
                        return false;
                }
            }
                
        }

        //Selector for the start menu
        public int MakeMenuChoice(string title = "Hangman menu")
        {
            Console.CursorVisible = false;
            int selected = 0;
            Console.Clear();
            

            DrawMenu(MenuOptions, selected, title);

            while (true)
            { 
                var pressedKey = Console.ReadKey(true).Key; //Using true to avoid printing the key to console

                switch(pressedKey)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        selected = (selected - 1 + MenuOptions.Length) % MenuOptions.Length;
                        DrawMenu(MenuOptions, selected, title);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        selected = (selected + 1) % MenuOptions.Length;
                        DrawMenu(MenuOptions, selected, title);
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return selected;
                }
            }
            
        }

        //Highlights for the selected element
        private void DrawMenu(string[] options, int selected, string title)
        {
            Console.Clear();
            Console.WriteLine($"{title}\n");

            for (int i = 0; i < options.Length; i++)
            {
                //Checks if we should highlight the option
                if (i == selected)
                {
                    //Saves original colours
                    ConsoleColor originalBackground = Console.BackgroundColor;
                    ConsoleColor originalForeground = Console.ForegroundColor;

                    //Inverts colours for highlight
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(options[i]);

                    //resets colour to prevent permanent higlighting of this option
                    Console.BackgroundColor = originalBackground;
                    Console.ForegroundColor = originalForeground;
                }
                else
                {
                    //write without the 
                    Console.WriteLine(options[i]);
                }
            }
        }
    }
}
