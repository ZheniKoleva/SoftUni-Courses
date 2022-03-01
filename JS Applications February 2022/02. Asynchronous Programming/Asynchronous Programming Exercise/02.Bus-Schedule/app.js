function solve() {
    const departButton = document.querySelector('#depart');
    const arriveButton = document.querySelector('#arrive');
    const busstopNameField = document.querySelector('.info');

    let busStop = {
        next: 'depot'        
    };   

    function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${busStop.next}`;

        fetch(url)
            .then(response => validateResponse(response))
            .then(data => {              
                busStop = data;
                arriveButton.removeAttribute('disabled');
                departButton.setAttribute('disabled', true);
                busstopNameField.textContent = `Next stop ${busStop.name}`;
            })
            .catch(error => processError(error));
    }

    function arrive() {
        busstopNameField.textContent = `Arriving at ${busStop.name}`;      
        departButton.removeAttribute('disabled');
        arriveButton.setAttribute('disabled', true);
    }

    function validateResponse(response){
        if(response.status !== 200) {
            throw new Error();
        }

        return response.json();
    }

    function processError(error) {
        busstopNameField.textContent = 'Error';        
        departButton.setAttribute('disabled', true);
        arriveButton.setAttribute('disabled', true);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();