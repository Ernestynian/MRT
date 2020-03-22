import React, { Component } from 'react';

export class AccountManager extends Component {
    constructor(props) {
        super(props);
        this.state = { balance: 0, frozen: false, open: false, verified: false, outAmount: 0, inAmount: 0 };
        this.handleTransferIn = this.handleTransferIn.bind(this);
        this.handleTransferOut = this.handleTransferOut.bind(this);
    }

    async handleTransferIn(event) {
        event.preventDefault();
        let response = await fetch(
            '/account/transfermoneyin', 
            { 
                method: 'POST', 
                body: this.state.inAmount, 
                headers: {
                    'Content-Type': 'application/json'
                }
            });

        if(!response.ok)
        {
            response.text().then(r => { alert(r); });
        }

        this.fetchStatus();
    }

    async handleTransferOut(event) {
        event.preventDefault();
        let response = await fetch(
            '/account/transfermoneyout', 
            { 
                method: 'POST', 
                body: this.state.outAmount, 
                headers: {
                    'Content-Type': 'application/json'
                }
            });

        if(!response.ok)
        {
            response.text().then(r => { alert(r); });
        }

        this.fetchStatus();
    }

    async fetchStatus() {
        await fetch('/account')
        .then((response) => {
            return response.json();
          })
        .then((response) => {
            this.setState({ 
                balance: response.balance, 
                frozen: response.frozen, 
                open: response.open, 
                verified: response.verified
            });
        })
    }

    componentDidMount() {
        this.fetchStatus();
    }

    render() {
        let nie = <span className="no">Nie</span>;
        let tak = <span className="yes">Tak</span>;
        return (
            <div id="account_manager_root">
                <p><span>Saldo: {this.state.balance}</span></p>
                <p><span>Zweryfikowane: </span>{this.state.verified ? tak : nie}</p>
                <p><span>Otwarte: </span>{this.state.open ? tak : nie}</p>
                <p><span>Zamrożone: </span>{this.state.frozen ? tak : nie}</p>
                <form onSubmit={this.handleTransferIn}>
                    <input type="number" value={this.state.inAmount} onChange={(e) => this.setState({inAmount: e.target.value})}></input>
                    <input type="submit" value="Wpłać"></input>
                </form>
                <form onSubmit={this.handleTransferOut}>
                <input type="number" value={this.state.outAmount} onChange={(e) => this.setState({outAmount: e.target.value})}></input>
                    <input type="submit" value="Wypłać"></input>
                </form>
            </div>
        );
    }
}