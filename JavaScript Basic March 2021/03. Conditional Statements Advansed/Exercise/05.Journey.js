function journey(input) {
    let budget = Number(input[0]);
    let season = input[1];

    let accommodation = season === "summer" ? "Camp" : "Hotel";
    let destination = null;
    let moneySpend = 0.00;

    if (budget <= 100) {
        destination = "Bulgaria";
        moneySpend = season === "summer" ? budget * 0.30 : budget * 0.70;

    } else if (budget <= 1000) {
        destination = "Balkans";
        moneySpend = season === "summer" ? budget * 0.40 : budget * 0.80;

    }else {
        destination = "Europe";
        accommodation = "Hotel";
        moneySpend = budget * 0.90;
    }

    console.log(`Somewhere in ${destination}\n` + `${accommodation} - ${moneySpend.toFixed(2)}`);    
}
journey(["50", "summer"]);

journey(["75", "winter"]);

journey(["312", "summer"]);

journey(["678.53", "winter"]);

journey(["1500", "summer"]);