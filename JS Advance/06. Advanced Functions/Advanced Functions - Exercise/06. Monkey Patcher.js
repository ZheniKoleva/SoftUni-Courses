function solution(command) {
    const operations = {
        upvote: () => { this.upvotes++; },
        downvote: () => {this.downvotes++; },
        score: () => {
            let totalVotes = this.upvotes + this.downvotes;
            let difference = this.upvotes - this.downvotes;

            let obfuscatedVotes = totalVotes > 50
                ? Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25)
                : 0;

            let upvotesOutput = this.upvotes + obfuscatedVotes;
            let downvotesOutput = this.downvotes + obfuscatedVotes;

            let ratingResult = 'new';

            if(totalVotes < 10){
                ratingResult = 'new';
            }else if ((this.upvotes / totalVotes) > 0.66) {
                ratingResult = 'hot';
            } else if (difference >= 0 && totalVotes > 100) {
                ratingResult = 'controversial';
            } else if (difference < 0) {
                ratingResult = 'unpopular';
            }

            return [upvotesOutput, downvotesOutput, difference, ratingResult];
        },
    }

    return operations[command]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score');
console.log(score); // [127, 127, 0, 'controversial']

for (let index = 0; index < 50; index++) {
    solution.call(post, 'downvote');         // (executed 50 times)    
}

score = solution.call(post, 'score'); 
console.log(score);     
