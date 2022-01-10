function attachGradientEvents() {
    let element = document.querySelector('#gradient');
    element.addEventListener('mousemove', calculatePersentage);

    function calculatePersentage(e){
        let percent = Math.floor((e.offsetX / element.clientWidth) * 100);
        document.querySelector('#result').textContent = `${percent}%`;        
    }
}