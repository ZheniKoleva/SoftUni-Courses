function evenPositions(input){
    const filtered = input
        .filter((x, i) => i % 2 == 0)
        .join(' ');
        
    console.log(filtered);
}

evenPositions(['20', '30', '40', '50', '60']);
evenPositions(['5', '10']);