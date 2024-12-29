document.addEventListener("DOMContentLoaded", function () {
    LoadTheme();
    const themeToggler = document.querySelector("#theme-toggler");
    if (themeToggler) {
        themeToggler.addEventListener("click", ToggleTheme);
    }
});

function LoadTheme() {
    const theme = localStorage.getItem('theme'); // Get the theme from localStorage

    // If theme is "dark", apply "dark" class to <html>
    if (theme === 'dark') {
        document.documentElement.classList.add('dark');
    } else {
        document.documentElement.classList.remove('dark');
    }
}

function ToggleTheme() {
    const currentTheme = document.documentElement.classList.contains('dark') ? 'dark' : 'light';

    if (currentTheme === 'dark') {
        document.documentElement.classList.remove('dark');
        localStorage.setItem('theme', 'light');
    } else {
        document.documentElement.classList.add('dark');
        localStorage.setItem('theme', 'dark');
    }
}