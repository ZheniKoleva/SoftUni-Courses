function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let inputData = JSON.parse(document.querySelector('#inputs textarea').value);
        
      let restaurants = {};
      
      for (const restaurantData of inputData) {
         let extractedData = restaurantData.split(' - ');
         let restaurantName = extractedData[0];
         let workersData = extractedData[1]
            .split(', ')
            .map(x => {
               let workerInfo = x.split(' ');

               return { 
                  name: workerInfo[0], 
                  salary: Number(workerInfo[1])
               };
            });

         if (!restaurants.hasOwnProperty(restaurantName)) {
            restaurants[restaurantName] = {
               workers : [],
               getAverageSalary: function(){
                  return this.workers.length === 0 ? 0 : 
                  this.workers.reduce((acc, w) => acc + w.salary, 0) / this.workers.length;
               }
            };
         }  
         
         restaurants[restaurantName].workers = restaurants[restaurantName].workers.concat(workersData);
      }

      restaurants = Object.entries(restaurants)
         .sort((a,b) => b[1].getAverageSalary() - a[1].getAverageSalary());

      let bestRestaurant = restaurants[0][0];
      let avgSalary = restaurants[0][1].getAverageSalary().toFixed(2);
      let sortedWorkers = restaurants[0][1].workers
         .sort((a, b) => b.salary - a.salary);

      let bestSalary = sortedWorkers[0].salary.toFixed(2);
      
      let output = `Name: ${bestRestaurant} Average Salary: ${avgSalary} Best Salary: ${bestSalary}`;

      document.querySelector('#bestRestaurant p').textContent = output;

      let restaurantWorkers = sortedWorkers
         .map(x => `Name: ${x.name} With Salary: ${x. salary}`)
         .join(' ');

      document.querySelector('#workers p').textContent = restaurantWorkers;
   }
}