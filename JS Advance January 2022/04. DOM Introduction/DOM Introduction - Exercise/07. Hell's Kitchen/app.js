function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        const restaurants = {};
        const inputData = JSON.parse(document.querySelector('#inputs textarea').value);
        const bestRestaurantElement = document.querySelector('#outputs #bestRestaurant p');
        const outputWorkersElement = document.querySelector('#outputs #workers p');

        for (const restaurantData of inputData) {
            let [restaurantName, workersData] = restaurantData.split(' - ');

            workersData = workersData.split(', ')
                .map(w => {
                    const [name, salary] = w.split(' ');

                    return {
                        name: name,
                        salary: Number(salary)
                    };
                });

            if (!restaurants.hasOwnProperty(restaurantName)) {
                restaurants[restaurantName] = {
                    workers: [],
                    averageSalary() {
                        return this.workers.reduce((a, b) => a + b.salary, 0) / this.workers.length || 0;
                    }
                };
            }

            restaurants[restaurantName].workers = restaurants[restaurantName].workers.concat(workersData);
        }

        const sorted = Object.entries(restaurants).sort((a, b) => b[1].averageSalary() - a[1].averageSalary());

        const bestRestaurantName = sorted[0][0];
        const avgSalary = sorted[0][1].averageSalary().toFixed(2);
        const sortedWorkers = sorted[0][1].workers.sort((a, b) => b.salary - a.salary);
        const maxSalary = sortedWorkers[0].salary.toFixed(2);

        const output = `Name: ${bestRestaurantName} Average Salary: ${avgSalary} Best Salary: ${maxSalary}`;
        const outputWorkers = sortedWorkers
            .map(w => `Name: ${w.name} With Salary: ${w.salary}`)
            .join(' ');

        bestRestaurantElement.textContent = output;
        outputWorkersElement.textContent = outputWorkers;
    }
}