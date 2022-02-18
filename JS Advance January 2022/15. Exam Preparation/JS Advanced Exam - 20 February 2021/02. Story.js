class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
        this._id = 0;
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
    }

    like(username) {       

        if (this._likes.includes(username)) {
            throw new Error('You can\'t like the same story twice!');
        }

        if (this.creator === username) {
            throw new Error('You can\'t like your own story!');
        }

        this._likes.push(username);

        return `${username} liked ${this.title}!`
    }

    dislike(username) {
        const indx = this._likes.indexOf(username);

        if (indx === -1) {
            throw new Error('You can\'t dislike this story!');
        }

        this._likes.splice(indx, 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        const searchedComment = this._comments.find(x => x.id === id);

        if (!searchedComment) {

            this._comments.push({
                id: ++this._id,
                username,
                content,
                replies: []
            });

            return `${username} commented on ${this.title}`;
        }

        searchedComment.replies.push({
            id: Number(searchedComment.id.toString().concat(`.${searchedComment.replies.length + 1}`)),
            username,
            content
        });

        return 'You replied successfully'; 
    }

    toString(sortingType) {
        const criterias = {
            asc: (a, b) => a.id - b.id,
            desc: (a, b) => b.id - a.id,
            username: (a, b) => a.username.localeCompare(b.username)
        };

        this._comments.forEach(c => c.replies.sort((a,b) => criterias[sortingType](a,b)));
        this._comments.sort((a,b) => criterias[sortingType](a,b));

        const result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push(`Comments:`);
        let commentsOutput = '';

        if (this._comments) {
            commentsOutput = this._comments
                .map(x => {
                    const comment = `-- ${x.id}. ${x.username}: ${x.content}`;
                    let replies = '';

                    if (x.replies) {
                        replies = x.replies
                            .map(r => `--- ${r.id}. ${r.username}: ${r.content}`)
                            .join('\n');
                    }

                    return replies ? `${comment}\n${replies}` : comment;
                })
                .join('\n');

            result.push(commentsOutput);
        }

        return result.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

