/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{ts,tsx}'],
  presets: [require('nativewind/preset')],
  theme: {
    extend: {
      colors: {
        brand: {
          50: '#eef8ff',
          100: '#d8efff',
          200: '#b9e3ff',
          300: '#88d1ff',
          400: '#4db5ff',
          500: '#1f95ff',
          600: '#0874f0',
          700: '#0b5dd1',
          800: '#124ca9',
          900: '#163f85',
        },
      },
      boxShadow: {
        card: '0 18px 50px rgba(15, 23, 42, 0.08)',
      },
    },
  },
  plugins: [],
};
