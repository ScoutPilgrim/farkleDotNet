using System;
using System.Collections.Generic;

namespace farkleDotNet.Models
{
  public class OddDie : Die
  {
    public OddDie ()
    {
      //Init dieTypeId
      this.dieTypeId = 1;

      //Init Weights of Die
      this.sideOneWeight   = 4;
      this.sideTwoWeight   = 2;
      this.sideThreeWeight = 4;
      this.sideFourWeight  = 2;
      this.sideFiveWeight  = 4;
      this.sideSixWeight   = 2;

      //Init Side Objs
      Side sideOne   = new Side(this.sideOneWeight,   1);
      Side sideTwo   = new Side(this.sideTwoWeight,   2);
      Side sideThree = new Side(this.sideThreeWeight, 3);
      Side sideFour  = new Side(this.sideFourWeight,  4);
      Side sideFive  = new Side(this.sideFiveWeight,  5);
      Side sideSix   = new Side(this.sideSixWeight,   6);

      //Add Sides to sizeOfDice ArrayList
      this.sidesOfDice.Add(sideOne);
      this.sidesOfDice.Add(sideTwo);
      this.sidesOfDice.Add(sideThree);
      this.sidesOfDice.Add(sideFour);
      this.sidesOfDice.Add(sideFive);
      this.sidesOfDice.Add(sideSix);

      //Initialize the RollWeightArray used for calculation Controllers
      this.initializeRollWeightArray();
    }
  }
}
