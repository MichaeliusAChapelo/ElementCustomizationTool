import '../styles/App.css';
import { useState } from 'react';
import { Palette } from '../components/palette/Palette';
import { Canvas3D } from '../components/Canvas3D';


function App() {
  const [color, setColor] = useState('red');

  return (
    <div className="App">
      <Canvas3D color={color} />
      <Palette onColorSelect={setColor} />
    </div>
  )
}
export default App
