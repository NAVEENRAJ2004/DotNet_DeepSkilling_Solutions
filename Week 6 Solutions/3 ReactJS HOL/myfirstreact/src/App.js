import React from 'react';
import { CalculateScore } from './Components/CalculateScore';

function App() {
  return (
    <div>
      <CalculateScore Name= {"Naveen"}
        School= {"DAV Public School"}
        Total= {350}
        Goal= {4} />
    </div>
  );
}

export default App;
