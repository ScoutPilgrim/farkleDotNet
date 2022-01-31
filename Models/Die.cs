using System;
using System.Collections.Generic;
using System.Collections;

namespace farkleDotNet.Models
{
  public class Die
  {
    // To calculate a weighted random chance, used 'https://gamedev.stackexchange.com/questions/162976/how-do-i-create-a-weighted-collection-and-then-pick-a-random-element-from-it' as ref
    protected class Side
    {
      public double weight;
      public int    value;
      public Side(double weight, int value)
      {
        this.weight = weight;
        this.value  = value;
      }
    }

    private Random        rand        = new Random();
    private static double totalWeight = 18;

    protected int[]     rollArray   { get; set; } = new int[(int)totalWeight];
    protected ArrayList sidesOfDice = new ArrayList();

    protected double    sideOneWeight   { get; set; }
    protected double    sideTwoWeight   { get; set; }
    protected double    sideThreeWeight { get; set; }
    protected double    sideFourWeight  { get; set; }
    protected double    sideFiveWeight  { get; set; }
    protected double    sideSixWeight   { get; set; }
    protected int       dieTypeId       { get; set; }

    public int          currVal         { get; set; }
    public int          dieId           { get; set; }

    protected void initializeRollWeightArray()
    {
      if (sidesOfDice.Count < 6){
        return;
      }
      int rollArrayPointer = 0;
      while(rollArrayPointer < totalWeight - 1)
      {
        foreach(Side side in sidesOfDice)
        {
          for (int i = 0; i < side.weight; i++)
          {
            rollArray[rollArrayPointer] = side.value;
            rollArrayPointer++;
          }
        }
      }
    }

    public int rollDie()
    {
      double rollArryIndex = rand.Next((int)totalWeight+1);
      if (rollArray[(int)rollArryIndex] == 0)
      {
        return 0;
      }
      currVal = rollArray[(int)rollArryIndex];
      return  rollArray[(int)rollArryIndex];
    }
  }
}
