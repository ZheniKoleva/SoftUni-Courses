function attachGradientEvents() {
    const gradientElement = document.querySelector('#gradient');
    gradientElement.addEventListener('mousemove', calculatePercent);

    function calculatePercent(e){
        const resultElement = document.querySelector('#result');

        const percent = Math.floor((e.offsetX / e.target.clientWidth) * 100);
        resultElement.textContent = `${percent}%`;
    }
}