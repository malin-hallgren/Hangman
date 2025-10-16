using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HangmanArt
    {

        //Ascii art, indentation is weird cause it has to be or else the display in console is weird
        private readonly string[] _stages = new string[]
        {
@"+---+
 |   |
     |
     |
     |
     |
   =====
  /     \
 /       \
/         \",
@" +---+
 |   |
 0   |
     |
     |
     |
   =====
  /     \
 /       \
/         \",
@" +---+
 |   |
 0   |
 |   |
     |
     |
   =====
  /     \
 /       \
/         \",
@" +---+
 |   |
 0   |
/|   |
     |
     |
   =====
  /     \
 /       \
/         \",
@" +---+
 |   |
 0   |
/|\  |
     |
     |
   =====
  /     \
 /       \
/         \",
@" +---+
 |   |
 0   |
/|\  |
/    |
     |
   =====
  /     \
 /       \
/         \",
@" +---+
 |   |
 0   |
/|\  |
/ \  |
     |
   =====
  /     \
 /       \
/         \"
        };

        ///<summary>
        ///Prints current Hangman to Console
        ///</summary> 
        public string PrintHangman(int currentStage)
        {
            if(currentStage > 6)
            {
                currentStage = 6;
            }
            return _stages[currentStage];
        }
    }
}
