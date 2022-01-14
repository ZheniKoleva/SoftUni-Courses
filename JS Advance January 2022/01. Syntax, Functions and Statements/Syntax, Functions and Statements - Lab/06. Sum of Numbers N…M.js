function numbersSum(first, second) {
    const start = Number(first);
    const end = Number(second);

    let result = start > end ? 0
        : [...Array(end - start + 1).keys()]
            .map(x => x + start)
            .reduce((a, b) => a + b, 0);

    console.log(result);    
}

numbersSum('1', '5' );
numbersSum('-8', '20');
numbersSum('20', '5');
