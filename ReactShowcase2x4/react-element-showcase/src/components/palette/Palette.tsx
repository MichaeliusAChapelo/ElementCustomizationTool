import { COLOURNAMES } from './colours';

export function Palette({ onColorSelect }: { onColorSelect: (color: string) => void; }) {

  const fontColor = (c: string) => (c === 'yellow' || c === 'white' ? 'black' : 'white');

  return (
    <div>
      {COLOURNAMES.map((c) => (
        <button
          key={c}
          style={{ background: c, color: fontColor(c), margin: 4 }}
          onClick={() => onColorSelect(c)}>

          {c.charAt(0).toUpperCase() + c.slice(1)}

        </button>
      ))}
    </div>
  );
}
