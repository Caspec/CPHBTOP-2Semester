<template>
  <div id="app">
    <app-header></app-header>
    <router-view keep-alive></router-view>
    <app-footer></app-footer>
  </div>
</template>

<script>
import Header from './components/molekyle/Header.vue'
import Footer from './components/atom/Footer.vue'

export default {
  name: 'app',
	components: {
            appHeader: Header,
            appFooter: Footer
        }
  
}
</script>

<style>
*{
  margin: 0;
  padding: 0;
  
}
body{
  background-color: #262c3a; 
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: antiquewhite; 
   
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
  text-decoration: none;
}
</style>
