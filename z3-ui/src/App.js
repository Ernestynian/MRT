import React from 'react';
import './App.css';
import { AccountManager } from './AccountManager';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Switch>
          <Route exact path='/' component={AccountManager} />
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
