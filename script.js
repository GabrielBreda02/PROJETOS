 let currentQuestionIndex = 0;
        let score = 0;

        const questions = [
            {
                question: "Escolha a forma correta de lavar as mãos:",
                options: [
                    { text: "Deixar os dedos sujos", isCorrect: false },
                    { text: "Não usar sabonete", isCorrect: false },
                    { text: "Lavar só a palma da mão", isCorrect: false },
                    { text: "Lavar toda a mão com água e sabão, esfregando bem as palmas, os dedos e as costas das mãos", isCorrect: true }
                ]
            },
            {
                question: "Escolha a forma correta de lavar as mãos:",
                options: [
                    { text: "Molhar as mãos, mas não usar sabão", isCorrect: false },
                    { text: "Lavar as mãos rapidamente", isCorrect: false },
                    { text: "Esfregar as mãos com sabão por pelo menos 20 segundos", isCorrect: true },
                    { text: "Lavar as mãos apenas com água quente", isCorrect: false }
                ]
            },
            {
                question: "Escolha a forma correta de lavar as mãos:",
                options: [
                    { text: "Lavar as mãos apenas por 5 segundos", isCorrect: false },
                    { text: "Lavar apenas as palmas das mãos", isCorrect: false },
                    { text: "Lavar bem entre os dedos e as costas das mãos", isCorrect: true },
                    { text: "Lavar as mãos apenas com sabonete em barra", isCorrect: false }
                ]
            },
            {
                question: "Escolha a forma correta de lavar as mãos:",
                options: [
                    { text: "Lavar as mãos uma vez e pronto", isCorrect: false },
                    { text: "Lavar as mãos antes e depois de comer, ao sair do banheiro e ao tocar em superfícies públicas", isCorrect: true },
                    { text: "Lavar as mãos somente quando estiver visivelmente sujas", isCorrect: false },
                    { text: "Lavar as mãos uma vez ao dia", isCorrect: false }
                ]
            }
        ];

        // Função para mostrar a pergunta atual
        function displayQuestion() {
            const questionContainer = document.getElementById('question-container');
            questionContainer.innerHTML = '';

            // Pergunta atual
            const question = questions[currentQuestionIndex];

            const questionText = document.createElement('p');
            questionText.textContent = question.question;
            questionContainer.appendChild(questionText);

            // Opções de resposta
            question.options.forEach((option, index) => {
                const optionDiv = document.createElement('div');
                optionDiv.classList.add('option');
                
                const radio = document.createElement('input');
                radio.type = 'radio';
                radio.id = `option${index}`;
                radio.name = 'answer';
                radio.value = option.isCorrect;
                
                const label = document.createElement('label');
                label.setAttribute('for', `option${index}`);
                label.textContent = option.text;
                
                optionDiv.appendChild(radio);
                optionDiv.appendChild(label);
                questionContainer.appendChild(optionDiv);
            });
        }

        // Função para verificar a resposta
        function checkAnswer() {
            const selectedOption = document.querySelector('input[name="answer"]:checked');
            const resultElement = document.getElementById('result');
            const nextButton = document.getElementById('next-btn');

            if (!selectedOption) {
                resultElement.textContent = "Por favor, selecione uma opção antes de enviar!";
                resultElement.style.color = "#ff6347"; // Vermelho
                return;
            }

            if (selectedOption.value === 'true') {
                score++;
                resultElement.textContent = "Resposta correta!";
                resultElement.style.color = "#32cd32"; // Verde claro
            } else {
                resultElement.textContent = "Resposta incorreta. Tente novamente!";
                resultElement.style.color = "#ff6347"; // Vermelho
            }

            // Mostrar o botão de "Próxima Pergunta"
            nextButton.style.display = 'inline-block';
            document.getElementById('submit-btn').style.display = 'none';
        }

        // Função para avançar para a próxima pergunta
        function nextQuestion() {
            currentQuestionIndex++;

            // Verifica se há mais perguntas
            if (currentQuestionIndex < questions.length) {
                displayQuestion();
                document.getElementById('next-btn').style.display = 'none';
                document.getElementById('submit-btn').style.display = 'inline-block';
                document.getElementById('result').textContent = '';
            } else {
                // Se não houver mais perguntas, exibe a pontuação final
                const resultElement = document.getElementById('result');
                resultElement.textContent = `Fim do Quiz! Você acertou ${score} de ${questions.length} perguntas.`;

                // Exibir o botão de reiniciar
                document.getElementById('restart-btn').style.display = 'inline-block';
                document.getElementById('next-btn').style.display = 'none';
                document.getElementById('submit-btn').style.display = 'none';
            }
        }

        // Função para reiniciar o jogo
        function restartGame() {
            // Resetando o formulário
            const radioButtons = document.querySelectorAll('input[type="radio"]');
            radioButtons.forEach(button => {
                button.checked = false;
            });

            // Limpando o resultado e ocultando os botões
            document.getElementById('result').textContent = '';
            document.getElementById('submit-btn').style.display = 'inline-block';
            document.getElementById('next-btn').style.display = 'none';
            document.getElementById('restart-btn').style.display = 'none';

            // Resetando variáveis de jogo
            currentQuestionIndex = 0;
            score = 0;

            // Exibindo novamente a primeira pergunta
            displayQuestion();
        }

        // Inicializa a primeira pergunta
        displayQuestion();

        // Evento de envio de resposta
        document.getElementById('submit-btn').addEventListener('click', checkAnswer);

        // Evento para avançar para a próxima pergunta
        document.getElementById('next-btn').addEventListener('click', nextQuestion);

        // Evento para reiniciar o jogo
        document.getElementById('restart-btn').addEventListener('click', restartGame);
