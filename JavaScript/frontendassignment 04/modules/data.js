import 'babel-polyfill';

class Data {
    // Get BTC US data
    static async getDataUS() {
        let response = await fetch('https://apiv2.bitcoinaverage.com/indices/global/ticker/BTCUSD');
        let data = await response.json();
        return data;
    }
    // Get local exchangerates data
    static async getDataLocal() {
        let response = await fetch('https://apiv2.bitcoinaverage.com/constants/exchangerates/local');
        let data = await response.json();
        return data;
    }

}

export default Data;

