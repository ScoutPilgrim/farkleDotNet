import React, { Component } from 'react';
import $ from 'jquery';
import '../../node_modules/bootstrap/dist/css/bootstrap.css';
import '../../node_modules/bootstrap/dist/js/bootstrap.js';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { dice: [], newValues: [], diceBenched:[], diceSelected: [], loading: true };

    fetch('api/FarkleGameBoard/GetDie')
      .then(response => response.json())
      .then(data => {
        this.setState({ dice: data, loading: false });
        console.log(data)
      });
      this.rollDice = this.rollDice.bind(this);
      this.submitDice = this.submitDice.bind(this);
      this.selectDice = this.selectDice.bind(this);
      this.isBust = this.isBust.bind(this);
  }

 isBust(){
   console.log("isBust is being hit");

 }

 submitDice(e) {
   e.preventDefault();
   console.log("submitDice is being called")
 }

 selectDice(e,id) {
   e.preventDefault();
  var buttonId = "#activeDiceBut" + id;
  var dummyDiceSelected = this.state.diceSelected;
  var dummyDice = this.state.dice;
   console.log("selectDice is being called for dice of id "+id)
   for (var i = 0; i < this.state.dice.length; i++){
     if (dummyDice[i].dieId === id){
       if(dummyDice[i].isSelected === false){
         dummyDice[i].isSelected = true;
         this.setState({dice: dummyDice})
         dummyDiceSelected.push(this.state.dice[i]);
         this.setState({diceSelected: dummyDiceSelected});
         console.log(this.state.diceSelected);
         $(buttonId).addClass("isSelected");
         break;
       } else {
         dummyDice[i].isSelected = false;
         this.setState({dice: dummyDice});
         for(var j = 0; j < dummyDiceSelected.length; j++){
           if(dummyDiceSelected[j].dieId === id){
             dummyDiceSelected.splice(j, 1);
             this.setState({diceSelected: dummyDiceSelected});
             console.log(this.state.diceSelected);
             break;
           }
         }
         $(buttonId).removeClass("isSelected");
         break;
       }
     }
   }
 }

 rollDice(e) {
   e.preventDefault();
   console.log("I am being called")
   var stateDiceCopy = [...this.state.dice];
   fetch('api/FarkleGameBoard/RollDice')
      .then(response => response.json())
      .then(data => {
        this.setState({newValues: data})
        console.log(data);
        for (var i = 0; i < stateDiceCopy.length; i++){
          var dieToChange = {...stateDiceCopy[i]};
          dieToChange.currVal = this.state.newValues[i]
          stateDiceCopy[i] = dieToChange;
        }
        this.setState({dice: stateDiceCopy});
        console.log(this.state.dice)
        for(var j = 0; j < this.state.dice.length; j++){
          var elemId = "#activeDiceBut" + this.state.dice[j].dieId;
          $(elemId).text(this.state.dice[j].currVal);
        }
        $('#rollDice').prop('disabled', true)
    });
 }

 static renderActiveDice (dice, passThis) {
    return (
      <div className="row" id="activeDice">
        <div className="col">
          <button type="button" id="activeDiceBut0" onClick={(e) => passThis.selectDice(e,0)} className="btn btn-primary">0</button>
        </div>
        <div className="col">
          <button type="button" id="activeDiceBut1" onClick={(e) => passThis.selectDice(e,1)} className="btn btn-primary">0</button>
        </div>
        <div className="col">
          <button type="button" id="activeDiceBut2" onClick={(e) => passThis.selectDice(e,2)} className="btn btn-primary">0</button>
        </div>
        <div className="col">
          <button type="button" id="activeDiceBut3" onClick={(e) => passThis.selectDice(e,3)} className="btn btn-primary">0</button>
        </div>
        <div className="col">
          <button type="button" id="activeDiceBut4" onClick={(e) => passThis.selectDice(e,4)} className="btn btn-primary">0</button>
        </div>
        <div className="col">
          <button type="button" id="activeDiceBut5" onClick={(e) => passThis.selectDice(e,5)} className="btn btn-primary">0</button>
        </div>
      </div>
    );
  }

  static renderBenchedDice (dice) {
     return (
       <div className="row" id="benchedDice">
         <div className="col">
           <button type="button" id="benchedDiceBut0" className="btn btn-primary">0</button>
         </div>
         <div className="col">
           <button type="button" id="benchedDiceBut1" className="btn btn-primary">0</button>
         </div>
         <div className="col">
           <button type="button" id="benchedDiceBut2" className="btn btn-primary">0</button>
         </div>
         <div className="col">
           <button type="button" id="benchedDiceBut3" className="btn btn-primary">0</button>
         </div>
         <div className="col">
           <button type="button" id="benchedDiceBut4" className="btn btn-primary">0</button>
         </div>
         <div className="col">
           <button type="button" id="benchedDiceBut5" className="btn btn-primary">0</button>
         </div>
       </div>
     );
  }
  render () {
    let passThis = this;
    console.log('render is called')
    let activeDice = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderActiveDice(this.state.dice, passThis);
    /*let benchedDice = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderBenchedDice(this.state.diceBenched)*/
    return (
      <div>
        {activeDice}
        <div className="row pad">
          <div className="col">
            <button type="button" id="rollDice" onClick={(e) => this.rollDice(e)} className="btn btn-primary clickable">Roll the Dice</button>
          </div>
          <div className="col">
            <button type="button" id="submitDice" onClick={(e) => this.submitDice(e)} className="btn btn-primary clickable">Submit Dice</button>
          </div>
        </div>

      </div>
    );
  }
}
