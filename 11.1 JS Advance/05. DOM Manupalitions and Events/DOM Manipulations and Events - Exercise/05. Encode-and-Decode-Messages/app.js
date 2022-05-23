function encodeAndDecodeMessages() {
    const buttons = Array.from(document.querySelectorAll('#main button'));
    buttons.find(b => b.textContent === 'Encode and send it')
        .addEventListener('click', encode);
    buttons.find(b => b.textContent === 'Decode and read it')
        .addEventListener('click', decode);

    function encode(e) {
        const parent = e.target.parentElement;
        const textToConvertElement = parent.querySelector('textarea');
        let messageText = Array.from(textToConvertElement.value)
            .map(l => l.charCodeAt(0) + 1)
            .map(c => String.fromCharCode(c))
            .join('');

        document.querySelectorAll('#main div')[1]
            .querySelector('textarea').value = messageText;

        textToConvertElement.value = '';
    }

    function decode(e) {
        const parent = e.target.parentElement;
        const textToDecodeElement = parent.querySelector('textarea');

        let decodedMessage = Array.from(textToDecodeElement.value)
            .map(l => l.charCodeAt(0) - 1)
            .map(c => String.fromCharCode(c))
            .join('');

        textToDecodeElement.value = decodedMessage;
    }
}