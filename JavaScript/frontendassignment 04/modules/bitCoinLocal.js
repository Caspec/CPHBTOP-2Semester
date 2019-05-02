import Data from './data.js';
import 'babel-polyfill';

class BitCoinLocal {
    constructor() {
        this.getData();
        this.getButtonTime();
    }
    // Get country and rate
    async getData() {
        const country = "Country";
        const rate = "Rate";
        let asyncData = await Data.getDataLocal();
        for (let local of Object.keys(asyncData.rates)) {
            let data = asyncData.rates[local];
            document.querySelector(".local").innerHTML += `${country}: ${data.name} - <span class='rate'> ${rate}: ${data.rate} </span><br>`;
        }
    }
    // Get timestamp
    async getButtonTime() {
        let asyncData = await Data.getDataLocal();
        let element = document.querySelector(".localTime");
        element.addEventListener("click", () => {
            document.querySelector(".displayTime").innerHTML = `<span class='time'>${asyncData.time}</span>`;
        });
    }

}

export default BitCoinLocal;