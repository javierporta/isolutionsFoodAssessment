import React from 'react';

import './App.css';
import FoodList from './components/foods/FoodList';
import ServiceContextProvider from './context/providers/ServiceContextProvider';

function App() {
  return (
    <ServiceContextProvider>
    <div className="App">
      <header className="App-header">
       <h1>ISolutions Junior Assessment</h1>
       <FoodList></FoodList>
      </header>
    </div>
    </ServiceContextProvider>
  );
}

export default App;
