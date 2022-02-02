class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
        this.divElement = document.createElement('div');
    }

    get online(){
        return this._online;
    }

    set online(value){
        this._online = value;

        if (!this._online) {
            this.divElement.classList.remove('online');
        } else {
            this.divElement.classList.add('online');
        }
        
    }

    render(id){
        const articleElement = document.createElement('article');
        
        this.divElement.textContent = `${this.firstName} ${this.lastName}`;
        this.divElement.classList.add('title');
        const buttonDivElement =  document.createElement('button');
        buttonDivElement.textContent = '\u2139';
        this.divElement.appendChild(buttonDivElement);
        
        const dataDivElement = document.createElement('div');
        dataDivElement.classList.add('info');
        dataDivElement.style.display = 'none';
        
        const phoneSpanElement = document.createElement('span');
        phoneSpanElement.textContent = `\u260E ${this.phone}`;
        dataDivElement.appendChild(phoneSpanElement);

        const emailSpanElement = document.createElement('span');
        emailSpanElement.textContent = `\u2709 ${this.email}`;
        dataDivElement.appendChild(emailSpanElement); 

        articleElement.appendChild(this.divElement);
        articleElement.appendChild(dataDivElement);

        buttonDivElement.addEventListener('click', () => {
            dataDivElement.style.display = dataDivElement.style.display == 'none'
            ? 'block'
            : 'none';
        });

        document.querySelector(`#${id}`).appendChild(articleElement);
    }
}


let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));

// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);
