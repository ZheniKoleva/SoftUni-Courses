function createAssemblyLine(){
    const object = {
        hasClima(myCar){
            myCar.temp = 21,
            myCar.tempSettings = 21,
            myCar.adjustTemp = function adjustTemp(){
                if (this.temp > this.tempSettings) {
                    this.temp--;
                } else if(this.temp < this.tempSettings){
                    this.temp++;
                }
            } 
        },

        hasAudio(myCar){
            myCar.currentTrack = {},
            myCar.nowPlaying = function nowPlaying(){
                if (this.currentTrack !== undefined) {
                    console.log(`Now playing ${this.currentTrack.name} by ${this.currentTrack.artist}`);
                }                
            }
        },

        hasParktronic(myCar){
            myCar.checkDistance = function checkDistance(distance){
                let result = '';
                
                if (distance < 0.1) {
                    result = 'Beep! Beep! Beep!';
                } else if(distance < 0.25){
                    result = 'Beep! Beep!';
                }else{
                    result = 'Beep!';
                }

                console.log(result);
            }
        }
    }

    return object;
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

