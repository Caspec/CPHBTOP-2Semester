<template>
  <div class="container">
    <h1>Shopping Cart</h1>
    <table class="tabl">
      <tr class="table_row">
        <th>Product Name</th>
        <th>Price</th>
        <th>Quantity</th>
      </tr>
      <div v-for="(product, index) in cart" :key="index">
        <tr class="table_row">
          <td>{{ product.details.product_name }}</td>
          <td>{{ product.details.product_price | currency }}</td>
          <td>{{ product.quantity }} <button class="add_button"  @click="addToQuantity(product.details.product_id)">+</button>  <button class="subtract_button" @click="removeFromCart(product.details.product_id)">-</button></td>
        </tr>
      </div>
    </table>
    <div class="alignCost">Total Incl. taxing: {{ totalCost * tax | currency }}</div>
    <div><router-link :to="{name: 'checkout', params: {carts: cart}}"><button class="checkout">Checkout</button></router-link></div>
  </div>
</template>


<script>
import { Store } from "../store/store.js";

export default {
  data(){
    return{
    }
  },
  computed: {
    cart(){
      return Store.$data.cart
    },
    totalCost(){
      return Store.totalCost
    }
  },
  methods: {
    removeFromCart(product_id){
      Store.removeFromCart(product_id)
    },
    addToQuantity(product_id){
      Store.addToQuantity(product_id)
    }
  },

};
</script>


<style scoped>
.container {
  width: 90%;
  height: auto;
  margin-bottom: 2em;
  margin-top: 2em;
  margin-left: 1em;
  border: 5px solid black;
  padding-top: 1em;
  padding-bottom: 1em;
}
.tabl{
  width: 100%;
}
.table_row{
  display: grid;
  grid-template-columns: 1fr 0.3fr 0.3fr;
  text-align: left;
  padding: 1px 1em;
}
.add_button{
  background-color: #4CAF50; /* Green */
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
.subtract_button{
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
  display: inline-block;
  font-size: 24px;
  font-weight: bold;
  margin: 4px 2px;
  margin-top: 2em;
  cursor: pointer;
}
</style>