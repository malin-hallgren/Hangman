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

        //Runs the actual start menu logic
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

        //Selector for the start menu
        public int MakeMenuChoice(string title = "Hangman menu")
        {
            Console.CursorVisible = false;
            int selected = 0;
            int prevSelected = selected;

            DrawMenu(MenuOptions, selected, title);

            while (true)
            {
                var pressedKey = Console.ReadKey(true).Key; //Using true to avoid printing the key to console

                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        prevSelected = selected;
                        selected = (selected - 1 + MenuOptions.Length) % MenuOptions.Length;
                        ClearLine(MenuOptions, selected, prevSelected);
                        DrawMenu(MenuOptions, selected, title);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        prevSelected = selected;
                        selected = (selected + 1) % MenuOptions.Length;
                        ClearLine(MenuOptions, selected, prevSelected);
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

        private static void ClearLine(string[] options, int selected, int prevSelected)
        {
            Console.SetCursorPosition(0, selected + 2);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, prevSelected + 2);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, 0);
        }
    }
}

