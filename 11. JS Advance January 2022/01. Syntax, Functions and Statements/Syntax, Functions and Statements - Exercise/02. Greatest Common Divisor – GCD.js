function greatestCommonDivisor(first, second) { 
    while(second) {
      const temp = second;
      second = first % second;
      first = temp;
    }

    console.log(first);
  }

  greatestCommonDivisor(15, 5);
  greatestCommonDivisor(2154, 458);
  greatestCommonDivisor(20,28);