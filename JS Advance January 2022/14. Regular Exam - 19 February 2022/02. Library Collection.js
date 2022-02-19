class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }
    addBook(bookName, bookAuthor) {

        if (this.books.length + 1 > this.capacity) {
            throw new Error('Not enough space in the collection.');
        }

        this.books.push({
            bookName,
            bookAuthor,
            payed: false,
        });

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        const searchedBook = this._findBook(bookName);

        if (!searchedBook) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (searchedBook.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }

        searchedBook.payed = true;

        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        const bookToRemove = this._findBook(bookName);

        if (!bookToRemove) {
            throw new Error('The book, you\'re looking for, is not found.');
        }

        if (!bookToRemove.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        const indx = this.books.indexOf(bookToRemove);
        this.books.slice(indx, 1);

        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let result = '""';

        if (bookAuthor) {
            const authorBook = this.books.find(x => x.bookAuthor == bookAuthor);

            if (!authorBook) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            result = `${authorBook.bookName} == ${bookAuthor} - ${authorBook.payed ? 'Has Paid' : 'Not Paid'}.`;

        } else {
            const firstRow = `The book collection has ${this.capacity - this.books.length} empty spots left.`

            const sortedBooks = this.books
                .sort((a, b) => a.bookName.localeCompare(b.bookName))
                .map(x => `${x.bookName} == ${x.bookAuthor} - ${x.payed ? 'Has Paid' : 'Not Paid'}.`)
                .join('\n');

            result = `${firstRow}\n${sortedBooks}`;
        }

        return result;
    }

    _findBook(bookName) {
        return this.books.find(x => x.bookName == bookName);
    }
}

// Input 1
// const library = new LibraryCollection(2)
// console.log(library.addBook('In Search of Lost Time', 'Marcel Proust'));
// console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
// console.log(library.addBook('Ulysses', 'James Joyce'));


// // Input 2
// const library = new LibraryCollection(2)
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// console.log(library.payBook('In Search of Lost Time'));
// console.log(library.payBook('Don Quixote'));

// // Input 3
// const library = new LibraryCollection(2)
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// library.addBook('Don Quixote', 'Miguel de Cervantes');
// library.payBook('Don Quixote');
// console.log(library.removeBook('Don Quixote'));
// console.log(library.removeBook('In Search of Lost Time'));

// // Input 4
// const library = new LibraryCollection(2)
// console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
// console.log(library.getStatistics('Miguel de Cervantes'));

// // Input 5
const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());



