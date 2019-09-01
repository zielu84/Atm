require('./bootstrap');
import { Form, HasError, AlertError } from 'vform';

window.Vue = require('vue');
window.Form = Form;

Vue.component(HasError.name, HasError);
Vue.component(AlertError.name, AlertError);
Vue.component('withdraw-component', require('./components/WithdrawComponent.vue').default);

const app = new Vue({
    el: '#app'
});
