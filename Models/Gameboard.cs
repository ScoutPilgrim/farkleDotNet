using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace farkleDotNet.Models
{
  public class Gameboard
  {
      public static int winningScore = 2000; //Should be 4000 for real game
      public static int startingDieId = 0;
      public static int[] dummyDiceTypeIds = new int[] {0,0,0,0,0,0};
      public Player HumanPlayer =  new Player(dummyDiceTypeIds, startingDieId);

      public bool IsWin(int playerScore)
      {
        if (playerScore >= winningScore)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
  }
}
