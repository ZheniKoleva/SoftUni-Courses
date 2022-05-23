function extract(content) {    
    let text = document.getElementById(content).textContent;     
    let regex = /\(([A-Za-z]+\s*){1,}\)/g;
   
    let extracted = text.match(regex)
        .map(x => x = x.slice(1, x.length - 1));    

    let result = extracted.join('; ');   
    
    return result;
}

let text = extract("content");

