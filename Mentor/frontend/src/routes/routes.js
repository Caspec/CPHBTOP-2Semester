import Products from '../components/organisme/Products.vue';
import Home from '../Home.vue';
import Login from '../components/atom/Login.vue';
import Dashboard from '../components/atom/Dashboard.vue';
import Product from '../components/molekyle/Product.vue';
import Checkout from '../components/molekyle/Checkout.vue';
import ProductAdd from '../components/atom/ProductAdd.vue';
import ProductEdit from '../components/atom/ProductEdit.vue';
import ProductDelete from '../components/atom/ProductDelete.vue';

export const routes = [
    { path: '/', component: Home },
    { path: '/products', component: Products },
	{ path: '/product/:id', name: 'product', component: Product, props: true },
    { path: '/login', component: Login },
    { path: '/checkout', name: 'checkout', component: Checkout, props: true },
    { path: '/dashboard', name: 'dashboard', component: Dashboard, props: true },
    { path: '/productadd', name: 'productadd', component: ProductAdd, props: true },
    { path: '/productedit', name: 'productedit', component: ProductEdit, props: true },
    { path: '/productdelete', name: 'productdelete', component: ProductDelete, props: true }
];