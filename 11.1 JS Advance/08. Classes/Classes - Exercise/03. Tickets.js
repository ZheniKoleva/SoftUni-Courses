function sortTickets(input, sortCriteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    
    const tickets = input.map(t => {
        const [destination, price, status] = t.split('|');
        return new Ticket(destination, Number(price), status);
    });

    const sorted = sortCriteria === 'price'
        ? tickets.sort((a, b) => a.price - b.price)
        : tickets.sort((a, b) => a[sortCriteria].localeCompare(b[sortCriteria]));

    return sorted;
}

console.log(sortTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(sortTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));