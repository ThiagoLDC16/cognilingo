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
        // Material Design 3 color tokens
        md: {
          primary: '#4343d5',
          'primary-container': '#5d5fef',
          'primary-fixed': '#e1e0ff',
          'primary-fixed-dim': '#c1c1ff',
          'inverse-primary': '#c1c1ff',
          'on-primary': '#ffffff',
          'on-primary-container': '#faf7ff',
          'on-primary-fixed': '#07006c',
          'on-primary-fixed-variant': '#2e2bc2',

          secondary: '#00677f',
          'secondary-container': '#00ccf9',
          'secondary-fixed': '#b7eaff',
          'secondary-fixed-dim': '#4cd6ff',
          'on-secondary': '#ffffff',
          'on-secondary-container': '#005266',
          'on-secondary-fixed': '#001f28',
          'on-secondary-fixed-variant': '#004e60',

          tertiary: '#914300',
          'tertiary-container': '#b75600',
          'tertiary-fixed': '#ffdbc8',
          'tertiary-fixed-dim': '#ffb68b',
          'on-tertiary': '#ffffff',
          'on-tertiary-container': '#fff6f3',
          'on-tertiary-fixed': '#321200',
          'on-tertiary-fixed-variant': '#753400',

          error: '#ba1a1a',
          'error-container': '#ffdad6',
          'on-error': '#ffffff',
          'on-error-container': '#93000a',

          background: '#fcf8ff',
          'on-background': '#1b1b23',

          surface: '#fcf8ff',
          'surface-bright': '#fcf8ff',
          'surface-dim': '#dbd8e5',
          'surface-tint': '#4849da',
          'surface-variant': '#e4e1ed',
          'surface-container': '#efecf9',
          'surface-container-low': '#f5f2fe',
          'surface-container-high': '#e9e6f3',
          'surface-container-highest': '#e4e1ed',
          'surface-container-lowest': '#ffffff',
          'on-surface': '#1b1b23',
          'on-surface-variant': '#464555',

          'inverse-surface': '#302f39',
          'inverse-on-surface': '#f2effb',

          outline: '#767586',
          'outline-variant': '#c7c4d7',
        },
      },
      boxShadow: {
        card: '0 18px 50px rgba(15, 23, 42, 0.08)',
        'md-1': '0px 4px 15px rgba(93, 95, 239, 0.05)',
        'md-2': '0px 8px 30px rgba(93, 95, 239, 0.08)',
      },
      fontFamily: {
        'jakarta-bold': ['PlusJakartaSans_700Bold'],
      },
    },
  },
  plugins: [],
};
