import Vue from 'vue';
import App from './App.vue';

// Config

// Plugins
import CoronaRouter from '@/plugins/vuerouter.plugin';
import Vuex from '@/plugins/vuex.plugins';
import vuetify from '@/plugins/vuetify.plugin';

// Modules
import { IRootState } from '@/interfaces/IRootState';
import AppModule, { IAppModule } from './modules/App.module';

// Services

// Styling
import 'typeface-nunito';

const appModule: IAppModule = new AppModule();

const store = new Vuex.Store<IRootState>({
    modules: {
        app: appModule
    }
});

const router = new CoronaRouter([
    { name: 'home' }
], true);

new Vue({
    router,
    store,
    vuetify,
    render: (h: any) => h(App)
} as any).$mount('#app');
