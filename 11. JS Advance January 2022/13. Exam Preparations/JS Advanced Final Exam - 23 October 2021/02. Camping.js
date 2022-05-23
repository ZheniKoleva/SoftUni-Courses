class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500,
        };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {

        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (this.priceForTheCamp[condition] > money) {
            return 'The money is not enough to pay the stay at the camp.';
        }

        this.listOfParticipants.push({
            name,
            condition,
            power: 100,
            wins: 0
        });

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        const participantToRemoveIndx = this.listOfParticipants.findIndex(x => x.name == name);

        if (participantToRemoveIndx == -1) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants.splice(participantToRemoveIndx, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        const games = ['WaterBalloonFights', 'Battleship'];

        const player = this._getPlayer(participant1);
        let winner = '';

        if (typeOfGame == games[0]) {
            const secondPlayer = this._getPlayer(participant2);
            this._validatePlayersConditions(player.condition, secondPlayer.condition);

            if (player.power > secondPlayer.power) {
                player.wins++;
                winner = player;
            } else if (player.power < secondPlayer.power) {
                secondPlayer.wins++;
                winner = secondPlayer;
            }

        } else if (typeOfGame == games[1]) {
            player.power += 20;

            return `The ${player.name} successfully completed the game ${typeOfGame}.`;
        }

        return winner ? `The ${winner.name} is winner in the game ${typeOfGame}.` : 'There is no winner.';
    }

    toString() {
        const firstRow = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`;
        const participants = this.listOfParticipants
            .sort((a, b) => b.wins - a.wins)
            .map(x => `${x.name} - ${x.condition} - ${x.power} - ${x.wins}`)
            .join('\n');

        return `${firstRow}\n${participants}`;
    }

    _getPlayer(playerName) {
        const player = this.listOfParticipants.find(x => x.name == playerName);

        if (!player) {
            throw new Error('Invalid entered name/s.');
        }

        return player;
    }

    _validatePlayersConditions(condition1, condition2) {
        if (condition1 != condition2) {
            throw new Error('Choose players with equal condition.');
        }
    }
}

// Input 1
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// Input 2
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.unregisterParticipant("Petar"));
console.log(summerCamp.unregisterParticipant("Petar Petarson"));


// Input 3
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

// Input 4
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());



