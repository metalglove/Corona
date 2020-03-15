import Vue from 'vue';
import App from './App.vue';

// Config

// Plugins
import CoronaRouter from '@/plugins/vuerouter.plugin';

// Modules

// Services

// Styling

const router = new CoronaRouter([
    { name: 'home' }
], true);

new Vue({
    router,
    render: (h: any) => h(App)
} as any).$mount('#app');
