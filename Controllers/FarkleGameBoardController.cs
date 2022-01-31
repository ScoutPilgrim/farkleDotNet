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
    public static int startingDieId = 1;
    public static int[] dummyDiceTypeIds = new int[] {0,0,0,0,0,0};
    public Player dummyPlayer = new Player(dummyDiceTypeIds, startingDieId);

    [HttpGet("[action]")]
    public List<Die> GetDie()
    {
      return dummyPlayer.dieAllowance;
    }

    [HttpPost("[action]")]
    public int rollDice()
    {
      return 1;
    }
  }
}
