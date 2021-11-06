function salary(input) {
    let tabsOpen = parseInt(input[0]);
    let salary = parseInt(input[1]);

    const facebookFine = 150;
    const instagramFine = 100;
    const redditFine = 50;
    let isLostSalary = false;

    for (let index = 2; index < input.length; index++) {
       
        switch (input[index]) {
            case "Facebook": salary -= facebookFine; break;
            case "Instagram": salary -= instagramFine; break;
            case "Reddit": salary -= redditFine; break;
        }

        if (salary <= 0) {
            isLostSalary = true;
            break;
        }        
    }
    
    if (isLostSalary) {
        console.log("You have lost your salary.");

    } else {
       console.log(salary); 
    }    
}
salary(["10", "750", "Facebook", "Dev.bg", "Instagram", "Facebook", "Reddit", "Facebook", "Facebook"]);
salary(["3", "500", "Github.com", "Stackoverflow.com", "softuni.bg"]);
salary(["3", "500", "Facebook", "Stackoverflow.com", "softuni.bg"]);
