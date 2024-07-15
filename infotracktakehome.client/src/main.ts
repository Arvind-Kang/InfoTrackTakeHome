import { createApp } from 'vue';
import App from './App.vue';
import {createBootstrap} from 'bootstrap-vue-next';
import router from './router/index';

// Import Bootstrap and Bootstrap-Vue CSS files
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue-next/dist/bootstrap-vue-next.css';

const app = createApp(App);

// Make BootstrapVueNext available throughout your project
app.use(createBootstrap());
app.use(router);
app.mount('#app');
