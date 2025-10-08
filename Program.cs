namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sets up the game objects for the first time
            var target = new TargetWord();
            var game = new GameLogic(target);
            var hangman = new HangmanArt();
            var menu = new Menu();
            bool isFreshStart = true;
            bool gameOngoing = menu.StartMenu(target);

            while (gameOngoing)
            {
                //resets the game objects if the player has played before
                if (!isFreshStart)
                {
                    target = target.ResetTargetWord(target);
                    game = game.ResetGameLogic(target, game);
                }

                //Core loop, clears console, displays current hangman picture,
                //prints the masked word with eventual correct guesses
                //prints previous guesses and takes a guess, disallowing
                //inputs that are not letters and letters that have already
                //been guessed
                while (game.FaultyGuess < 6 && !target.WordGuessed())
                {
                    Console.Clear();
                    Console.WriteLine($"{hangman.PrintHangman(game.FaultyGuess)}\n");
                    target.PrintMaskedWord();
                    game.PrintPreviousGuesses();
                    game.CheckGuess();
                }

                //One last printout to accompany end of game message
                Console.Clear();
                Console.WriteLine($"{hangman.PrintHangman(game.FaultyGuess)}\n");
                target.PrintMaskedWord();
                game.PrintPreviousGuesses();

                //Preints message based on how the player did and sends
                //player back to menu
                if (game.FaultyGuess >= 6)
                {
                    Console.WriteLine("\nYou failed to guess the word in time and the man has been hanged");
                }
                else
                {
                    Console.WriteLine("\nGood job! You guessed the word in time and the man's life has been spared!");
                }

                Console.WriteLine("Press Enter to continue to menu");
                Console.ReadLine();

                isFreshStart = false;
                gameOngoing = menu.StartMenu(target);
            }
        }
    }
}
