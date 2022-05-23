function solve() {
    const textToConvert = document.querySelector('#text').value;
    const namingConvention = document.querySelector('#naming-convention').value;
    const resultElement = document.querySelector('#result');

    const resultText = convertText(textToConvert, namingConvention);
    resultElement.textContent = resultText;

    function convertText(input, convention) {
        const conventions = ['Camel Case', 'Pascal Case'];

        if (!conventions.includes(convention)) {
            return 'Error!';
        }

        let transformed = input.split(' ')
            .map(x => x[0].toUpperCase() + x.substring(1).toLowerCase())
            .join('');

        if (convention == conventions[0]) {
            transformed = transformed.
                replace(transformed[0], transformed[0].toLowerCase())
        }

        return transformed;
    }
}