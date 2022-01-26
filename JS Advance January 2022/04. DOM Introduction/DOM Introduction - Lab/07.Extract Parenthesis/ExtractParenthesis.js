function extract(content) {
    const textToSearch = document.getElementById(content).textContent;
    const pattern = /((?:\()(?<text>[^(]+)(?:\)))/g;

    const matches = [...textToSearch.matchAll(pattern)]
        .map(x => x.groups.text)
        .join('; ');        

    return matches;
}