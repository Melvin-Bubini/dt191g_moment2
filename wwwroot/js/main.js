// Hämtar knapparna och menyn
const menuToggleButton = document.getElementById('menu-toggle');
const closeMenuButton = document.getElementById('close-menu');
const smallMenu = document.getElementById('small-menu');

// Funktion för att öppna menyn
function toggleMenu() {
    smallMenu.classList.toggle('open'); // Lägg till eller ta bort 'open' klassen
}

// När användaren klickar på knappen för att öppna menyn
menuToggleButton.addEventListener('click', toggleMenu);

// När användaren klickar på stängknappen i menyn
closeMenuButton.addEventListener('click', toggleMenu);

// Stäng menyn om användaren klickar utanför menyn
window.addEventListener('click', function (e) {
    if (!smallMenu.contains(e.target) && !menuToggleButton.contains(e.target)) {
        smallMenu.classList.remove('open'); // Ta bort 'open' klassen om man klickar utanför
    }
});

// Gör headern seethru
document.addEventListener("DOMContentLoaded", () => {
    const header = document.querySelector("header");

    window.addEventListener("scroll", () => {
        if (window.scrollY > 50) {
            header.classList.add("scrolled");
        } else {
            header.classList.remove("scrolled");
        }
    });
});

// Pilarna för att skrolla ner på sidan
document.querySelector('.scroll-down').addEventListener('click', function (e) {
    e.preventDefault(); // Förhindra standardlänkens beteende
    const target = document.querySelector(this.getAttribute('href')); // Hämta målet från href-attributet
    target.scrollIntoView({ behavior: 'smooth', block: 'start' }); // Smooth scrolling
});





// Välj alla knappar med klassen '.read-more-btn'
const buttons = document.querySelectorAll('.read-more-btn');

buttons.forEach(button => {
    button.addEventListener('click', function () {
        const section = this.closest('section'); // Hitta förälderelementet som är en section
        const textContainer = section.querySelector('.text-container');
        const fadeOut = section.querySelector('.fade-out');

        // Om texten redan är expanderad, återställ till ursprungligt läge
        if (textContainer.style.maxHeight === 'none') {
            textContainer.style.maxHeight = '100px'; // Återställ begränsad höjd
            fadeOut.style.display = 'block'; // Visa gradienten
            this.innerHTML = 'Läs mer <i class="fa fa-chevron-down"></i>'; // Ändra knappens text och ikon
        } else {
            textContainer.style.maxHeight = 'none'; // Ta bort begränsning
            fadeOut.style.display = 'none'; // Dölj gradienten
            this.innerHTML = 'Visa mindre <i class="fa fa-chevron-up"></i>'; // Ändra knappens text och ikon
        }
    });
});