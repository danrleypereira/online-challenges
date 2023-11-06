import React, { useState } from 'react';
import { createRoot } from 'react-dom/client';

function Toggle() {
const [state, setState] = useState(true)
  
  return (
    <button onClick={() => setState(!state)}>{state == true ? 'ON' : 'OFF'}</button>
  );
}

const container = document.getElementById('root');
const root = createRoot(container);
root.render(<Toggle />);