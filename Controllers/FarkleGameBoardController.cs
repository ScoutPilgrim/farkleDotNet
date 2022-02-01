using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using farkleDotNet.Models;

namespace farkleDotNet.Controllers
{
  [Route("api/[controller]")]
  public class FarkleGameBoardController: Controller
  {
    public Gameboard gameboard = new Gameboard();

    [HttpGet("[action]")]
    public List<Die> GetDie()
    {
      return gameboard.HumanPlayer.dieAllowance;
    }

    [HttpGet("[action]")]
    public int[] RollDice()
    {
      int[] returnArr = new int[Player.maxDie];
      int returnArrPointer = 0;
      foreach(Die die in gameboard.HumanPlayer.dieAllowance)
      {
        int thisRoll = die.rollDie();
        returnArr[returnArrPointer] = thisRoll;
        returnArrPointer++;
      }
      return returnArr;
    }
  }
}
