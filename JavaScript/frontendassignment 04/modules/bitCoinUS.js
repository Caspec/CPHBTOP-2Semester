import Data from './data.js';
import 'babel-polyfill';

class BitCoinUS {
    constructor() {
        this.getData();
        this.getButtonHighBid();
        this.getButtonMultiHighBid();
    }
    // Get last bid, volume_percent and symbol
    async getData() {
        const last = "Last bid";
        const volumePercent = "Volume In Percent";
        let asyncData = await Data.getDataUS();
        for (let local of Object.keys(asyncData)) {
            let data = asyncData;
            document.querySelector(".usd").innerHTML = `${last}: ${data.last} ${volumePercent}: ${data.volume_percent}% ${data.display_symbol}`;
        }
    }
    // Get highest bid
    async getButtonHighBid() {
        let asyncData = await Data.getDataUS();
        let element = document.querySelector(".highBid");
        element.addEventListener("click", () => {
            document.querySelector(".displayHighBid").innerHTML = `<span class='time'>\$${asyncData.high}</span>`;
        });
    }
    // Multiple button two times the highest bid
    async getButtonMultiHighBid() {
        let asyncData = await Data.getDataUS();
        const multi = (high, times) => high * times;
        let element = document.querySelector(".multiBid");
        element.addEventListener("click", () => {
            document.querySelector(".displayMultiBid").innerHTML = `<span class='time'>\$${multi(asyncData.high, 2)}</span>`;
        });
    }
}

export default BitCoinUS;