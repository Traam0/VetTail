/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml',
        './Views/**/*.html',
        './wwwroot/**/*.html'
    ],
    darkMode: "selector",
    theme: {
      extend: {
            colors: {
                primary: "#3a7ca7",
                "primary-content": "#e9f2f7",
                "primary-dark": "#2d6081",
                "primary-light": "#5196c3",

                secondary: "#3aa79b",
                "secondary-content": "#000000",
                "secondary-dark": "#2d8178",
                "secondary-light": "#51c3b6",

                background: "#ebf1f5",
                foreground: "#fafbfc",
                border: "#d5e1ea",

                copy: "#1a2933",
                "copy-light": "#446d88",
                "copy-lighter": "#6694b2",

                success: "#3aa73a",
                warning: "#a7a73a",
                error: "#a73a3a",

                "success-content": "#e9f7e9",
                "warning-content": "#000000",
                "error-content": "#f7e9e9"
            },
      },
  },
    plugins: [
        require("tailwind-scrollbar")
    ],
}

