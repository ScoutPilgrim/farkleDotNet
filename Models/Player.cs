using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace farkleDotNet.Models
{
  public class Player
  {
    protected int playerScore { get; set; }
    protected static int maxDie      = 6;
    public List<Die> dieAllowance { get; set; } = new List<Die>();
    public List<Die> dieActive    = new List<Die>();
    public List<Die> dieBenched   = new List<Die>();
    public List<Die> dieSelected  = new List<Die>();

    public Player( int[] dieIds, int startingDieId )
    {
      if (dieIds.Count() != 6)
      {
        return;
      }
      for (int i = 0; i < maxDie; i++)
      {
        if (dieIds[i] == 0)
        {
          FairDie dieToAdd = new FairDie();
          dieToAdd.dieId = startingDieId;
          startingDieId++;
          this.dieAllowance.Add(dieToAdd);
        }
        else if ( dieIds[i] == 1)
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

    public void initDieActive( List<Die> dieAllowance )
    {
      if (!dieAllowance.Any())
      {
        return;
      }
      this.dieActive.Clear();
      foreach(Die die in dieAllowance)
      {
        this.dieActive.Add(die);
      }
    }

    public void initDieSelected()
    {
      if(!this.dieSelected.Any())
      {
        return;
      }
      this.dieSelected.Clear();
    }

    public void initDieBenched()
    {
      if(!this.dieBenched.Any())
      {
        return;
      }
      this.dieBenched.Clear();
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
