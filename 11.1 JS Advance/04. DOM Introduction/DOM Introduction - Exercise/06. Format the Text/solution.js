function solve() {
  let sentences = document.querySelector('#input').value
    .split('.')
    .filter(x => x)
    .map(x => x.concat('.'));

  let paragraphsCount = Math.ceil(sentences.length / 3);
  let result = document.querySelector('#output');

  for (let index = 0; index < paragraphsCount; index++) {

    let text = `${sentences.splice(0, 3).join('')}`;
    let paragraphText = document.createTextNode('');
    paragraphText.appendData(text);

    let paragraph = document.createElement('p');
    paragraph.appendChild(paragraphText);

    result.appendChild(paragraph);
  } 
}