
document.getElementById('submit-btn').addEventListener('click', function () {
    const selects = document.querySelectorAll('.organ-select');
    let correctAnswers = 0;

    selects.forEach(select => {
        const selectedValue = select.value.trim().toLowerCase(); // Normaliza o valor
        const correctValue = select.dataset.answer.trim().toLowerCase(); // Normaliza a resposta

        // Verifica se a resposta está correta
        if (selectedValue === correctValue) {
            correctAnswers++;
            select.style.borderColor = '#32cd32'; // Verde para respostas corretas
            select.style.backgroundColor = '#d4edda';
        } else {
            select.style.borderColor = '#ff6347'; // Vermelho para respostas erradas
            select.style.backgroundColor = '#f8d7da';
        }
    });

    // Mensagem de resultado
    const resultText = correctAnswers === selects.length
        ? "Parabéns! Você acertou todos os benefícios das frutas! 🎉"
        : `Você acertou ${correctAnswers} de ${selects.length}. Tente novamente!`;

    const resultElement = document.getElementById('result');
    resultElement.textContent = resultText;

    // Animação para o resultado
    resultElement.style.opacity = 0;
    resultElement.style.transition = "opacity 0.5s";
    setTimeout(() => {
        resultElement.style.opacity = 1;
    }, 100);

    // Limpa as cores após 3 segundos
    setTimeout(() => {
        selects.forEach(select => {
            select.style.borderColor = '#00796b';
            select.style.backgroundColor = '#ffffff';
        });
    }, 3000);
});
document.getElementById('retry-btn').addEventListener('click', function () {
    const selects = document.querySelectorAll('.organ-select');

    // Reseta todas as seleções para o valor inicial
    selects.forEach(select => {
        select.value = ""; // Voltar para "Selecione..."
        select.style.borderColor = ""; // Remove as bordas coloridas
        select.style.backgroundColor = ""; // Remove os fundos coloridos
    });

    // Limpa o texto do resultado
    const resultElement = document.getElementById('result');
    resultElement.textContent = "";
    resultElement.style.opacity = 0;

    // Esconde o botão de jogar novamente
    this.style.display = "none";

    // Reaparece o botão de "Vamos ver se você foi bem!"
    document.getElementById('submit-btn').style.display = "inline-block";
});

// Modificação no botão de "Vamos ver se você foi bem!" para exibir o botão de "Jogar Novamente"
document.getElementById('submit-btn').addEventListener('click', function () {
    const retryButton = document.getElementById('retry-btn');

    // Exibe o botão de "Jogar Novamente" após o resultado
    retryButton.style.display = "inline-block";

    // Opcional: Ocultar o botão de "Vamos ver se você foi bem!"
    this.style.display = "none";
});