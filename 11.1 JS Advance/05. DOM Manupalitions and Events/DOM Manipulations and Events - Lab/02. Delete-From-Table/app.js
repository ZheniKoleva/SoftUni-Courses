function deleteByEmail() {
    let searchedEmail = document.querySelector('input').value

    let emailsToCheck = Array.from(document.querySelectorAll('tbody tr'));
    let isFound = false;

    emailsToCheck.forEach(row => {
        let rowElements = Array.from(row.querySelectorAll('td'));

        if (rowElements[1].textContent === searchedEmail) {            
            row.remove();
            isFound = true;;            
        } 
    });

   
    document.querySelector('#result').textContent = isFound ? 'Deleted.' : 'Not found.';
}