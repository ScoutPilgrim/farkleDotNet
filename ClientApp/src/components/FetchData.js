import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { dice: [], loading: true };

    fetch('api/FarkleGameBoard/GetDie')
      .then(response => response.json())
      .then(data => {
        this.setState({ dice: data, loading: false });
        console.log(data)
      });
  }

  static renderDiceTable (dice) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>DieId</th>
            <th>Current Value</th>
          </tr>
        </thead>
        <tbody>
          {dice.map(die =>
            <tr key={die.dieId}>
              <td>{die.dieId}</td>
              <td>{die.currVal}</td>
              <div className="col">
                  <button type="button" id="diceBut1" className="btn btn-primary clickable">0</button>
              </div>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderDiceTable(this.state.dice);

    return (
      <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
