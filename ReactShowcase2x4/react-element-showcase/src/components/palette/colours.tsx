export const COLOURS = {
  red: [1, 0, 0],
  orange: [1, 0.33, 0],
  yellow: [1, 0.7, 0],
  green: [0, 0.25, 0],
  blue: [0.05, 0.05, 0.7],
  purple: [0.33, 0, 0.33],
  white: [1, 1, 1],
  gray: [0.33, 0.33, 0.33],
  black: [0.1, 0.1, 0.1],
} as const;

export type ColourMap = keyof typeof COLOURS;

export const COLOURNAMES = Object.keys(COLOURS) as ColourMap[];