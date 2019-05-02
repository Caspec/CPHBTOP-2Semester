<template>
  <div>
    <div class="container">
      <h1>Add a new Product</h1>
      <div class="containerCrud">
        <div class="containerCrud one">
        
          <table>
              <tr><td><button class="goBack" @click="goBack">Go back</button></td><td></td></tr>
            <tr>
              <td class="align">
                <label>Product name</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <input class="input" type="text" name="product_name" placeholder="Product Name" v-model="product_name" required>
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align">
                <label>Product Description</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                  <textarea class="input" placeholder="Product Description" cols="60" rows="15" name="product_description" v-model="product_description" required></textarea>
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align">
                <label>Product Price</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <input class="input" type="text" name="product_price" placeholder="Product Price" v-model="product_price" required>
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align">
                <label>Product Image name</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <input class="input" type="text" name="image_name" placeholder="Product Image name" v-model="image_name" required>
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align">
                <label>Category</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <select class="dropdown" v-model="fk_category_id">
                  <option selected="selected" disabled>Please select one</option>
                  <option
                    v-for="(category, index) in category"
                    :value="category.category_id"
                    :key="index"
                  >{{ category.category_name}}</option>
                </select>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <button class="button" @click="createProduct" type="submit">Create</button>
              </td>
              <td></td>
            </tr>
          </table>
        </div>
        <div class="containerCrud two"></div>
      </div>
    </div>
  </div>
</template>

<script>
import { Store } from "../store/store.js";
export default {
  props: {
    user_name: {
      type: String
    }
  },
  data() {
    return {
      product_name: "",
      product_description: "",
      product_price: 0,
      fk_category_id: 0,
      image_name: "",
      category: []
    };
  },
  methods: {
    createProduct() {
      this.$http
        .post("http://localhost:3001/productadd", {
          product_name: this.product_name,
          product_description: this.product_description,
          product_price: this.product_price,
          image_name: this.image_name,
          fk_category_id: this.fk_category_id,
        })
        .then(res => {
          if (res.status == "200") {
            this.$router.push({
              name: "dashboard",
              params: { id: this.user_name, user_name: this.user_name }
            });
          }
        })
        .catch(error => {
          this.err = true;
        });
    },
    getCategory() {
      this.$http
        .get("http://localhost:3001/categories")
        .then(res => {
          this.category = res.data;
        })
        .catch(err => {
          console.log("error: " + res.status.send(err));
        });
    },
    goBack(){
         this.$router.push({
              name: "dashboard",
              params: { id: this.user_name, user_name: this.user_name }})
    }
  },
  mounted() {
    this.getCategory();
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
.containerCrud {
  width: 95%;
  height: auto;
  margin-bottom: 2em;
  margin-left: 1em;
  padding-top: 1em;
  padding-bottom: 1em;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-rows: auto;
}
.one {
  grid-column: span 2;
}
.two {
  grid-template-columns: span 1;
}
.button {
  background-color: #4caf50; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 24px;
  margin: 10px 2px;
  cursor: pointer;
}
.goBack{
  background-color: rgba(8, 98, 172, 0.986);
  border: none;
  color: white;
  padding: 10px 10px;
  text-align: center;
  text-decoration: none;
  font-size: 24px;
  cursor: pointer;
  margin-bottom: 1em;
}
.align {
  text-align: left;
}
.input {
  padding: 10px 10px;
  margin: 2px 2px;
  margin-bottom: 5px;
  width: 100%;
}
.dropdown {
  padding: 10px 5px;
  margin: 2px 2px;
  margin-bottom: 5px;
  width: 100%;
}
</style>
