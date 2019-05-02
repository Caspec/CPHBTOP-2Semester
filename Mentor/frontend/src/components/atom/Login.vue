<template>
<div>
    <div class="containerLogin">
        <table>
            <tr>
                <td><label>Brugernavn</label></td><td><input class="input" type="text" name="user_name" placeholder="Username" v-model="user_name"></td><td></td>
            </tr>
            <tr>
                <td><label>Password</label></td><td><input class="input" name="user_password" placeholder="Password" v-model="user_password" :type="passwordFieldType"></td><td><button class="showHide" type="password" @click="showHidePassword">Show / Hide</button></td>
            </tr>
            <tr>
                <td></td><td><button class="button" name="login" @click="login" type="submit">Login to Admin</button></td><td></td>
            </tr>
        </table>
        <p v-if="err" class="red">Username or Password is sjakal, try again !</p>
    </div>
</div>
</template>

<script>
export default {
    data(){
        return {
            user_name: '',
            user_password: '',
            passwordFieldType: 'password',
            err: false
        }
    },
    methods: {
        login(){
         this.$http.post('http://localhost:3001/login', { user_name: this.user_name, user_password: this.user_password })
        .then ((res) => {
            if(res.status == "200"){
                this.$router.push({name: 'dashboard', params: {id: this.user_name, user_name: this.user_name}})
            }
        })
        .catch ((error) => {this.err = true})
    },
    showHidePassword(){
        this.passwordFieldType = this.passwordFieldType === 'password' ? 'text' : 'password'
    }
    }
}
</script>

<style>
.containerLogin {
margin-top: 5em;
}
.input {
    padding: 15px 32px;
    margin: 4px 2px;
    width: 100%;
}
.button {
  background-color: #4CAF50; /* Green */
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
table {
    margin: 0 auto;
}
label {
    font-size: 20px;
}
.red{
    color: red;
}
.showHide{
  background-color: rgba(8, 98, 172, 0.986);
  border: none;
  color: white;
  padding: 10px 10px;
  text-align: center;
  text-decoration: none;
  font-size: 24px;
  margin-left: 75px;
  cursor: pointer;
}
</style>


