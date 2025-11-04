using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Menu
    {
        private string[] MenuOptions = { "Start Game", "Add Words", "Exit Game" }; //The menu options will neever change at runtime

        /// <summary>
        /// Runs the start menu, returns true if option to start is selected, fals if option to quit is selected. 
        /// If option to add a new word to the pool is selected, runs the AddWord() method on the word object passed
        /// </summary>
        /// <param name="word">The word object to run AddWord() on in case that option is selected</param>
        /// <returns></returns>
        public bool StartMenu(TargetWord word)
        {
            while (true)
            {
                int selected = MakeMenuChoice();

                switch (selected)
                {
                    case 0:
                        return true;
                    case 1:
                        word.AddWord();
                        break;
                    case 2:
                        return false;
                }
            }

        }

        /// <summary>
        /// Displays menu and allows user to to navigate options with W/Up arrow and S/Down arrow, pressing enter to select
        /// </summary>
        /// <param name="title">The title displayed on top of the menu</param>
        /// <returns>Integer representing selected menu option</returns>
        public int MakeMenuChoice(string title = "Hangman menu")
        {
            Console.CursorVisible = false;
            int selected = 0;
            int prevSelected = selected;

            DrawMenu(MenuOptions, selected, title);

            while (true)
            {
                var pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        prevSelected = selected;
                        selected = (selected - 1 + MenuOptions.Length) % MenuOptions.Length;
                        ClearLine(selected, prevSelected);
                        DrawMenu(MenuOptions, selected, title);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        prevSelected = selected;
                        selected = (selected + 1) % MenuOptions.Length;
                        ClearLine(selected, prevSelected);
                        DrawMenu(MenuOptions, selected, title);
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return selected;
                }
            }

        }
        //The menu was largely constructed by AI, but the first version it presented used Console.Clear 
        // which caused flickering. further prompting took place to figure out how to reduce this and the method ClearLine was made
        /// <summary>
        /// Highlights the option user is currently on, updates when currently selected option is changed
        /// </summary>
        /// <param name="options">Array of options on the menu</param>
        /// <param name="selected">Currently selected option</param>
        /// <param name="title">Title of the menu to be displayed on top of the menu</param>
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


        // AI helped me write this, but completely forgot to reset the cursor, it also did not account for the title 
        // in determining the position of the lines to clear but rather just tried to clear the lines 
        // corresponding to selected and prevSelected, which naturally had to be changed
        /// <summary>
        /// Clears lines for the highlight method to work properly
        /// </summary>
        /// <param name="selected">Currently selected option</param>
        /// <param name="prevSelected">Previously selected option</param>
        private static void ClearLine(int selected, int prevSelected)
        {
            Console.SetCursorPosition(0, selected + 2);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, prevSelected + 2);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, 0);
        }
    }
}

