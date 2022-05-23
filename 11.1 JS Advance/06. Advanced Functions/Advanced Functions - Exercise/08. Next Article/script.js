function getArticleGenerator(articles) {
    const contentElement = document.querySelector('#content');
    const textToShow = articles;
    let currentIndex = 0;

    function showArticle() {
        if(currentIndex < textToShow.length){
            const articleElement = document.createElement('article');
            articleElement.textContent = textToShow[currentIndex++];

            contentElement.appendChild(articleElement);
        }
    }

    return showArticle;
}
