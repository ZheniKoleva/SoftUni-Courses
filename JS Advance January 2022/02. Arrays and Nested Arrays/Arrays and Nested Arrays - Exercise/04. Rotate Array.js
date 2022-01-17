function rotateArray(inputArray, rotations) {
    const realRotations = rotations > inputArray.length
        ? Math.floor(rotations / inputArray.length)
        : rotations;

    for (let i = 0; i < realRotations; i++) {
        inputArray.unshift(inputArray.pop());
    }

    console.log(inputArray.join(' '));
}

rotateArray(['1', '2', '3', '4'], 2);

rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 15);
