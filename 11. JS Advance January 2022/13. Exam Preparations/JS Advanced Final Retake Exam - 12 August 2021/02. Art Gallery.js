class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250,
        };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {

        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }

        const searchedArticle = this.listOfArticles.find(x => x.articleName == articleName);

        if (searchedArticle && searchedArticle.articleModel == articleModel) {
            searchedArticle.quantity += Number(quantity);

        } else {

            const newArticle = {
                articleModel: articleModel.toLowerCase(),
                articleName: articleName,
                quantity: Number(quantity),
            };

            this.listOfArticles.push(newArticle);
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        const personalities = {
            Vip: 500,
            Middle: 250,
        };

        if (this.guests.some(x => x.guestName == guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }

        const points = personalities[personality] || 50;
        const guest = {
            guestName,
            points,
            purchaseArticle: 0,
        };

        this.guests.push(guest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        const articleToBuy = this.listOfArticles.find(x => x.articleName == articleName);

        if (!articleToBuy || articleToBuy.articleModel != articleModel.toLowerCase()) {
            throw new Error('This article is not found.');
        }

        if (articleToBuy.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

        const guestWhoBuy = this.guests.find(x => x.guestName == guestName)

        if (!guestWhoBuy) {
            return 'This guest is not invited.';
        }

        const pointsNeeded = this.possibleArticles[articleModel.toLowerCase()];

        if (guestWhoBuy.points < pointsNeeded) {
            return`You need to more points to purchase the article.`;
        }

        guestWhoBuy.points -= pointsNeeded;
        guestWhoBuy.purchaseArticle++;

        articleToBuy.quantity--;

        return `${guestName} successfully purchased the article worth ${pointsNeeded} points.`;
    }

    showGalleryInfo(criteria) {
        const criterias = {
            article: () => {
                const result = this.listOfArticles
                    .map(x => `${x.articleModel} - ${x.articleName} - ${x.quantity}`)
                    .join('\n');

                return `Articles information:\n${result}`;
            },

            guest: () => {
                const result = this.guests
                    .map(x => `${x.guestName} - ${x.purchaseArticle}`)
                    .join('\n');

                return `Guests information:\n${result}`;
            }
        };

        return criterias[criteria]();
    }
}

// Input 1
// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.addArticle('picture', 'Mona Liza', 3));
// console.log(artGallery.addArticle('Item', 'Ancient vase', 2));
// console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));

// Input 2
//const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.inviteGuest('John', 'Vip'));
// console.log(artGallery.inviteGuest('Peter', 'Middle'));
//console.log(artGallery.inviteGuest('John', 'Middle'));

// Input 3
// const artGallery = new ArtGallery('Curtis Mayfield');
// artGallery.addArticle('picture', 'Mona Liza', 3);
// artGallery.addArticle('Item', 'Ancient vase', 2);
// artGallery.addArticle('picture', 'Mona Liza', 1);
// artGallery.inviteGuest('John', 'Vip');
// artGallery.inviteGuest('Peter', 'Middle');
// console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
// console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
// console.log(artGallery.buyArticle('item', 'Mona Liza', 'John'));

// Input 4
const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));