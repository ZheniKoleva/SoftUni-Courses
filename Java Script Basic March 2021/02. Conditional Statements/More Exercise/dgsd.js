function scholarship(input){  
  let income = Number(input[0]);
  let success = Number(input[1]);
  let salary = Number(input[2]);
  
  let scholarship = success * 25;
  let socialScholarship = salary * 0.35;
  
     if (success >= 5.50 && income < salary){
 
          if (socialScholarship > scholarship){
           console.log(`You get a Social scholarship ${Math.floor(socialScholarship)} BGN.`);
             
          } else {
           console.log(`You get a scholarship for excellent results ${Math.floor(scholarship)} BGN.`);
          }             

     } else if (success >= 5.50){
        console.log(`You get a scholarship for excellent results ${Math.floor(scholarship)} BGN.`);

     } else if (success > 4.50 && income < salary){
          console.log(`You get a Social scholarship ${Math.floor(socialScholarship)} BGN.`)

     } else {
       console.log("You cannot get a scholarship!");
     }
}

scholarship(["300.00", "5.65", "420.00"]);