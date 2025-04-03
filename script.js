
const board = document.getElementById('game-board');
const resetButton = document.getElementById('reset-button');

const icons = ['🍎', '🍌', '🍇', '🍉', '🍓', '🍋', '🍍', '🍑',
                '🍎', '🍌', '🍇', '🍉', '🍓', '🍋', '🍍', '🍑'];

let firstCard = null;
let secondCard = null;
let lockBoard = false;

function shuffle(array) {
    for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
    }
}

function createBoard() {
    shuffle(icons);
    board.innerHTML = '';
    icons.forEach(icon => {
        const card = document.createElement('div');
        card.classList.add('card');
        card.dataset.icon = icon;
        card.addEventListener('click', flipCard);
        board.appendChild(card);
    });
}

function flipCard() {
    if (lockBoard || this === firstCard || this.classList.contains('flipped')) return;

    this.classList.add('flipped');
    this.textContent = this.dataset.icon;

    if (!firstCard) {
        firstCard = this;
        return;
    }

    secondCard = this;
    lockBoard = true;

    checkMatch();
}

function checkMatch() {
    if (firstCard.dataset.icon === secondCard.dataset.icon) {
        firstCard.classList.add('matched');
        secondCard.classList.add('matched');
        resetBoard();
        return;
    }

    setTimeout(() => {
        firstCard.classList.remove('flipped');
        secondCard.classList.remove('flipped');
        firstCard.textContent = '';
        secondCard.textContent = '';
        resetBoard();
    }, 1000);
}

function resetBoard() {
    [firstCard, secondCard] = [null, null];
    lockBoard = false;
}

function resetGame() {
    createBoard();
}

resetButton.addEventListener('click', resetGame);

createBoard();