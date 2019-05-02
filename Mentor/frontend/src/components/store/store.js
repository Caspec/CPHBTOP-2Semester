import Vue from 'vue'
import products from '../organisme/Products.vue'

export const Store = new Vue({
	data() {
	    return {
				products,
	    	cart: []
	    };
	},
	computed: {
		totalCost(){
			return this.cart.reduce((accum, product) => {
				return accum + product.details.product_price * product.quantity // product.quantity
			}, 0)
		},
		totalItems(){
			return this.cart.length
		}
	},
	methods: {
		addToCart(product){
			const locationInCart = this.cart.findIndex(p => {return p.details.product_id === product.product_id})
		    if (locationInCart === -1) {
		        this.cart.push({
		          details: product,
		          quantity: 1
		        })
		    } else {
				this.cart[locationInCart].quantity++
		    }
		},
		removeFromCart(product_id){
			const locationInCart = this.cart.findIndex(p => {
				return p.details.product_id === product_id
			})
			if(this.cart[locationInCart].quantity <= 1){
				this.cart.splice(locationInCart, 1)
			} else {
				this.cart[locationInCart].quantity--
			}
		},
		addToQuantity(product_id){
			const locationInCart = this.cart.findIndex(p => {
				return p.details.product_id === product_id
			})
			if(this.cart[locationInCart].quantity >= 1){
				this.cart[locationInCart].quantity++
			} 
		}
	}
});