function createAssemblyLine() {    
    return {
        hasClima(obj) {
            obj.temp = 21,
            obj.tempSettings = 21,
            obj.adjustTemp = function(){
                if (this.temp < this.tempSettings) {
                    this.temp++;
                } else if (this.temp > this.tempSettings) {
                    this.temp--;
                }
            }
        },
        hasAudio(obj) {
            obj.currentTrack = {},
            obj.nowPlaying = function(){
                console.log(this.currentTrack ? 
                    `Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}` : _);
            }
        },
        hasParktronic(obj){
            obj.checkDistance = function(distance){
                let result = '';
                if (distance < 0.1) {
                    result = 'Beep! Beep! Beep!';
                }else if(distance < 0.25){
                    result = 'Beep! Beep!';
                }else if(distance < 0.5){
                    result = 'Beep!';
                }

                console.log(result);
            }
        }
    }
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);


