using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace farkleDotNet.Models
{
  public class Player
  {
    public int playerScore { get; set; }
    public static int maxDie { get; } = 6;
    public List<Die> dieAllowance { get; set; } = new List<Die>();

    public Player( int[] dieTypeIds, int startingDieId )
    {
      if (dieTypeIds.Count() != 6)
      {
        return;
      }
      for (int i = 0; i < maxDie; i++)
      {
        if (dieTypeIds[i] == 0)
        {
          FairDie dieToAdd = new FairDie();
          dieToAdd.dieId = startingDieId;
          startingDieId++;
          this.dieAllowance.Add(dieToAdd);
        }
        else if ( dieTypeIds[i] == 1)
        {
          OddDie dieToAdd = new OddDie();
          dieToAdd.dieId = startingDieId;
          startingDieId++;
          this.dieAllowance.Add(dieToAdd);
        }
        else
        {
          break;
        }
      }
    }

    public void resetScore()
    {
      if(this.playerScore == 0)
      {
        return;
      }
      this.playerScore = 0;
    }
  }
}
