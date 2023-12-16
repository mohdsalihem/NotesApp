const baseFontSize = 10;

const convert = (value) => {
  return value + "rem";
};

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      fontSize: {
        xs: [
          `${convert(1.2)}`,
          {
            lineHeight: `${convert(1.6)}`,
          },
        ],
        sm: [
          `${convert(1.4)}`,
          {
            lineHeight: `${convert(2)}`,
          },
        ],
        base: [
          `${convert(1.6)}`,
          {
            lineHeight: `${convert(2.4)}`,
          },
        ],
        lg: [
          `${convert(1.8)}`,
          {
            lineHeight: `${convert(2.8)}`,
          },
        ],
        xl: [
          `${convert(2)}`,
          {
            lineHeight: `${convert(2.8)}`,
          },
        ],
        "2xl": [
          `${convert(2.4)}`,
          {
            lineHeight: `${convert(3.2)}`,
          },
        ],
        "3xl": [
          `${convert(3)}`,
          {
            lineHeight: `${convert(3.6)}`,
          },
        ],
        "4xl": [
          `${convert(3.6)}`,
          {
            lineHeight: `${convert(4)}`,
          },
        ],
        "5xl": [
          `${convert(4.8)}`,
          {
            lineHeight: 1,
          },
        ],
        "6xl": [
          `${convert(6)}`,
          {
            lineHeight: 1,
          },
        ],
        "7xl": [
          `${convert(7.2)}`,
          {
            lineHeight: 1,
          },
        ],
        "8xl": [
          `${convert(9.6)}`,
          {
            lineHeight: 1,
          },
        ],
        "9xl": [
          `${convert(12.8)}`,
          {
            lineHeight: 1,
          },
        ],
      },
      lineHeight: {
        3: `${convert(1.2)}`,
        4: `${convert(1.6)}`,
        5: `${convert(2)}`,
        6: `${convert(2.4)}`,
        7: `${convert(2.8)}`,
        8: `${convert(3.2)}`,
        9: `${convert(3.6)}`,
        10: `${convert(4)}`,
      },
      borderRadius: {
        sm: `${convert(0.2)}`,
        DEFAULT: `${convert(0.4)}`,
        md: `${convert(0.6)}`,
        lg: `${convert(0.8)}`,
        xl: `${convert(1.2)}`,
        "2xl": `${convert(1.6)}`,
        "3xl": `${convert(2.4)}`,
      },
      minWidth: (theme) => ({
        ...theme("spacing"),
      }),
      maxWidth: (theme) => ({
        ...theme("spacing"),
        xs: `${convert(32)}`,
        sm: `${convert(38.4)}`,
        md: `${convert(44.8)}`,
        lg: `${convert(51.2)}`,
        xl: `${convert(57.6)}`,
        "2xl": `${convert(67.2)}`,
        "3xl": `${convert(76.8)}`,
        "4xl": `${convert(89.6)}`,
        "5xl": `${convert(102.4)}`,
        "6xl": `${convert(115.2)}`,
        "7xl": `${convert(128)}`,
      }),
    },
    screens: {
      sm: "640px",
      md: "768px",
      lg: "1024px",
    },
    spacing: () => ({
      ...Array.from({ length: 502 }, (_, index) => index)
        .filter((i) => i % 2 == 0)
        .reduce((acc, i) => ({ ...acc, [i]: `${i / baseFontSize}rem` }), {}),
    }),
  },
  plugins: [],
};
