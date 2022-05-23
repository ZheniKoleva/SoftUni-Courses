function solve() {
    document.querySelector('#quizzie').addEventListener('click', takeAnswer);
    const questionsSection = Array.from(document.querySelectorAll('section'));
    const resultSection = document.querySelector('#results');

    let index = 0;
    let correctAnswers = 0;
    const rightAnswers = [
        "onclick",
        "JSON.stringify()",
        "A programming API for HTML and XML documents"
    ];   

    function takeAnswer(e) {
        if (e.target.tagName !== 'P') {
            return;
        }

        const currentAnswer = e.target.textContent;
        if (rightAnswers.includes(currentAnswer)) {
            correctAnswers++;
        }

        questionsSection[index].style.display = 'none';             

        if (index < 2) {
            questionsSection[index + 1].style.display = 'block';
            index++;            
        } else {
            const result = correctAnswers == 3
                ? 'You are recognized as top JavaScript fan!'
                : `You have ${correctAnswers} right answers`;

            resultSection.querySelector('.results-inner h1').textContent = result;
            resultSection.style.display = 'block';
        }        
    }
}
