<template>
  <div class="container">
    <h1>Checkout</h1>
    <div class="bold" v-if="cart.length === 0">Cart is empty..... fill some in it to buy them!</div>
    <div v-else>
      <table class="tabl">
        <div v-for="(product, index) in carts" :key="index">
          <tr class="table_row">
            <th>Product Name</th>
            <th>Product Description</th>
            <th>Product Price</th>
            <th>Product Quantity</th>
          </tr>
          <tr class="table_row">
            <td>{{ product.details.product_name }}</td>
            <td>{{ product.details.product_description }}</td>
            <td class="left">{{ product.details.product_price | currency }}</td>
            <td class="left">
              {{ product.quantity }}
              <button
                class="add_button"
                @click="addToQuantity(product.details.product_id)"
              >+</button>
              <button class="subtract_button" @click="removeFromCart(product.details.product_id)">-</button>
            </td>
            <td>
              <img class="img" :src="'../src/assets/' + product.details.product_image">
            </td>
          </tr>
        </div>
      </table>
      <div class="alignCost total">Total Incl. taxing: {{ totalCost * tax | currency }}</div>
      
      <transition name="fade">
        <div class="paymethod" v-if="!show">
          <h3>Payment</h3>
          <img src="../../assets/payment.png" alt="payment" class="paymentImage">
          <div class="total">
              Total Incl. taxing: {{ totalCost * tax | currency }}
          </div>
          <div class="paymentContainer">
          <label>Card Number</label>
          <input type="number" placeholder="Card Number" class="input">
          <label>Cardholders Name</label>
          <input type="text" placeholder="Cardholders Name" class="input">
          <label>Expiry Date</label>
          <input type="number" placeholder="01 / 01 2000" class="input">
          <label>Security Code</label>
          <div></div>
          <input type="number" placeholder="3 digits" class="security">
          <button class="pay">Pay</button>
          </div>
        </div>
      </transition>
      <div>
        <button class="checkout" @click="show = !show">Finish</button>
      </div>
    </div>
  </div>
</template>

<script>
import { Store } from "../store/store.js";
export default {
  props: {
    carts: {
      type: Array
    }
  },
  data() {
    return {
      show: true
    };
  },
  computed: {
    totalCost() {
      return Store.totalCost;
    },
    cart() {
      return Store.$data.cart;
    }
  },
  methods: {
    removeFromCart(product_id) {
      Store.removeFromCart(product_id);
    },
    addToQuantity(product_id) {
      Store.addToQuantity(product_id);
    }
  }
};
</script>

<style scoped>
.container {
  width: 95%;
  height: auto;
  margin-bottom: 2em;
  margin-top: 2em;
  margin-left: 1em;
  border: 5px solid black;
  padding-top: 1em;
  padding-bottom: 1em;
}
.bold {
  font-weight: bold;
  margin-top: 1em;
}
.img {
    width: 50%;
    height: auto;
}
.add_button {
  background-color: #4caf50; /* Green */
  border: none;
  color: white;
  height: auto;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 20px;
  margin: 2px;
  width: 1em;
  cursor: pointer;
}
.subtract_button {
  background-color: rgb(209, 60, 60); /* Red */
  border: none;
  color: white;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 20px;
  margin: 2px;
  width: 1em;
  cursor: pointer;
}
.tabl {
  width: 100%;
  margin-top: 1em;
}
.table_row {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
  text-align: left;
  padding: 1px 1em;
}
.alignCost {
  text-align: left;
  padding-left: 1.2em;
  font-weight: bold;
}
.checkout {
  background-color: rgba(8, 98, 172, 0.986);
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: block;
  font-size: 24px;
  font-weight: bold;
  margin: 4px 2px;
  margin-top: 1em;
  margin-left: 0.8em;
  cursor: pointer;
}
.pay {
  background-color: #4caf50;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: block;
  font-size: 24px;
  font-weight: bold;
  margin: 4px 2px;
  margin-top: 1em;
  cursor: pointer;
}
.left {
  padding-left: 1.5em;
}
.paymethod {
  background-color: rgb(255, 255, 255);
  width: 50%;
  border: none;
  color: black;
  padding: 15px 32px;
  text-align: left;
  text-decoration: none;
  display: block;
  font-size: 24px;
  font-weight: bold;
  margin: 4px 2px;
  margin-top: 1em;
  margin-left: 0.8em;
  margin-right: 0.5em;
}
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
.input {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
}
.security {
  width: 25%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
}
.paymentContainer {
    margin-top: 1em;
}
.paymentImage {
    margin-top: 0.5em;
    margin-bottom: 0.5em;
}
.total {
    color: #4caf50;
    font-weight: bolder;
}
</style>

