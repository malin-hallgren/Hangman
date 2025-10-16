GameLogic.cs
  - Contains the setting and resetting of the game state as well as the final check on guesses
  - Anything that affects how the game runs should go in this file

HangmanArt.cs
  - Contains ASCII art and methods related to the printing of these
  - Do not change! If more ASCII is to be added, make a new file.

Menu.cs
  - All things menu related
  - Currently there is no base menu to inherit from
    - if more menus are added consider breaking out the general parts (MakerMenuChoice(), DrawMenu() and ClearLine() to a separate base Menu file)

Program.cs
  - Only used for main flow of program, do not alter unless something is added to core loop

TargetWord.cs
  - Everything concerning the word and it's display to the player
    - PrintMaskedWord(), RevealLetter() and WordGuessed() may be broken out to GameLogic.cs in future refactor
