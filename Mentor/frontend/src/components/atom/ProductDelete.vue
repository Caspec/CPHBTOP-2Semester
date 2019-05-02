<template>
  <div>
    <div class="container">
      <h1>Delete Product</h1>
      <div class="containerCrud">
        <div class="containerCrud one">
          <table>
            <tr>
              <td>
                <button class="goBack" @click="goBack">Go back</button>
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align">
                <label>Product ID</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <input
                  class="input"
                  type="text"
                  name="product_id"
                  v-model="product_id"
                  required
                  disabled
                >
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align">
                <label>Product name</label>
              </td>
              <td></td>
            </tr>
            <tr>
              <td>
                <input
                  class="input"
                  type="text"
                  name="product_name"
                  v-model="product_name"
                  required
                  disabled
                >
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="align"><label>Category</label></td><td></td>
            </tr>
            <tr>
              <td>
                <select class="dropdown" v-model="fk_category_id" disabled>
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
                <button class="delete" @click="deleteProduct" type="submit">Delete</button>
              </td>
              <td></td>
            </tr>
          </table>
        </div>
        <div class="containerCrud two">
          <img :src="'./src/assets/' + product.product_image" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    product: {
      type: Object
    },
    user_name: {
      type: String
    }
  },
  data() {
    return {
      product_id: this.product.product_id,
      product_name: this.product.product_name,
      fk_category_id: this.product.fk_category_id,
      category: []
    };
  },
  methods: {
    goBack() {
      this.$router.push({
        name: "dashboard",
        params: { id: this.user_name, user_name: this.user_name }
      });
    },
    deleteProduct() {
      this.$http
        .delete("http://localhost:3001/productdelete/" + this.product_id, {
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
.input {
  padding: 10px 10px;
  margin: 2px 2px;
  margin-bottom: 5px;
  width: 100%;
}
.align {
  text-align: left;
}
.goBack {
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
.delete {
  background-color:red;
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
.dropdown {
  padding: 10px 5px;
  margin: 2px 2px;
  margin-bottom: 5px;
  width: 100%;
}
</style>
