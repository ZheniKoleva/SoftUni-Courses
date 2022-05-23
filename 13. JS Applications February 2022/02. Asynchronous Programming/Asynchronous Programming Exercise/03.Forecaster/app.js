function attachEvents() {
    const buttonElement = document.querySelector('#submit');
    buttonElement.addEventListener('click', getWeatherInfo);
}

function getWeatherInfo() {   
    const availableDivCurrent = document.querySelector('.forecasts');    
    const availableDivUpcoming = document.querySelector('.forecast-info');
    const availableErrorPElement = document.querySelector('#content > p');

    if (availableDivCurrent) {
        availableDivCurrent.remove();
    }

    if (availableDivUpcoming) {
        availableDivUpcoming.remove();
    }  
    
    if (availableErrorPElement) {
        availableErrorPElement.remove();
    }
    
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';

    fetch(url)
        .then(response => validateResponse(response))
        .then(data => getWeather(data))
        .catch(error => manageError());   
}   

function getWeather(data) {    
    const location = document.querySelector('#location');
    const locationData = data.find(x => x.name === location.value);

    if (!locationData) {        
        throw new Error();
    }

    const urlToday = `http://localhost:3030/jsonstore/forecaster/today/${locationData.code}`;
    const urlUpcoming = `http://localhost:3030/jsonstore/forecaster/upcoming/${locationData.code}`;

    const current = fetch(urlToday)
        .then(response => validateResponse(response))
        .then((data) => loadCurrentData(data));
        
    //console.log(current);

    const upcomming = fetch(urlUpcoming)
        .then(response => validateResponse(response))
        .then((data) => loadUpcomingData(data));   
        
    //console.log(upcomming);

    Promise.all([current, upcomming])
        .then((x) => {
            document.querySelector('#location').value = '';
            const forecastSection = document.querySelector('#forecast');
            forecastSection.style.display = 'block'
        })
        .catch(error => manageError());
}

function validateResponse(response) {
    if(response.status !== 200){
        throw new Error('Error');
    }

    return response.json();
}

function manageError(){    
    document.querySelector('#location').value = '';
    const forecastSection = document.querySelector('#forecast');
    forecastSection.style.display = 'none';
    const content = document.querySelector('#content');
    const pElement = createElement('p', 'label', 'Error', content);
}

function loadCurrentData(weatherReport) {
    const currentDivElement = document.querySelector('#current');

    const weatherSymbols = {
        'Sunny': '\u2600', //'☀'
        'Partly sunny': '\u26C5', //'⛅' 
        'Overcast': '\u2601', //'☁'
        'Rain': '\u2614', //'☂'        
    }; 

    const symbol = weatherSymbols[weatherReport.forecast.condition];
    const cityName = weatherReport.name;
    const temperature = `${weatherReport.forecast.low}°/${weatherReport.forecast.high}°`;
    const condition = weatherReport.forecast.condition;

    const divElement = createElement('div', 'forecasts', undefined, currentDivElement);
    const conditionSpan = createElement('span', 'condition', symbol, divElement);
    conditionSpan.classList.add('symbol');
    const detailsSpan = createElement('span', 'condition', undefined, divElement);
    const locationSpan = createElement('span','forecast-data', cityName, detailsSpan);
    const temperatureSpan = createElement('span','forecast-data', temperature, detailsSpan);
    const textConditionSpan = createElement('span','forecast-data', condition, detailsSpan);
}

function loadUpcomingData(weatherReport) {
    const upcomingDivElement = document.querySelector('#upcoming');
    const divForecastInfo = createElement('div', 'forecast-info', undefined, upcomingDivElement);
    
    const weatherSymbols = {
        'Sunny': '\u2600', //'☀'
        'Partly sunny': '\u26C5', //'⛅' 
        'Overcast': '\u2601', //'☁'
        'Rain': '\u2614', //'☂'        
    }; 

    weatherReport.forecast.forEach(x => {
        const symbol = weatherSymbols[x.condition];        
        const temperature = `${x.low}°/${x.high}°`;
        const condition = x.condition;
        
        const upcomingSpan = createElement('span', 'upcoming', undefined, divForecastInfo);
        const symbolSpan = createElement('span', 'symbol', symbol, upcomingSpan);        
        const temperatureSpan = createElement('span', 'forecast-data', temperature, upcomingSpan);
        const textConditionSpan = createElement('span', 'forecast-data', condition, upcomingSpan);        
    });        
}

function createElement(type, className, textContent, parent) {
    const element = document.createElement(type);

    if(className){
        element.classList.add(className);
    }

    if(textContent){
        element.textContent = textContent;
    }

    if(parent){
        parent.appendChild(element);
    } 

    return element;
}

attachEvents();