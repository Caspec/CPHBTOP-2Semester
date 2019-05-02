<template>
  <div>
    <div class="container">
      <div class="headline">
        <h1>{{ product.product_name }}</h1>
      </div>
      <div class="image">
        <img :src="'../src/assets/' + product.product_image">
      </div>
      <div class="desc">
        <h3>Description about the product:</h3>
        <p>{{ product.product_description }}</p>
      </div>
      <div class="price">
        <h3>Price: {{ product.product_price | currency }}</h3>
      </div>
      <div class="add">
        <button class="button" name="addToCart" @click="addToCart(product)">Add to cart</button>
      </div>
    </div>
  </div>
</template>
 <script>
import { Store } from "../store/store.js";
export default {
  props: {
    product: {
      type: Object,
      required: true
    }
  },
  methods: {
    addToCart(product) {
      Store.addToCart(product)
    }
  },
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
</style>
 
 