import { createRouter, createWebHistory } from 'vue-router';
import Search from '../components/Search.vue';
import History from '../components/History.vue';

const routes = [
    { path: '/', redirect: '/search' },
    {
        path: '/search', component: Search,
            props: {
                loading: "true",
                url: "api/SearchEngine/GetSearchEngine/"
            }
    },
    {
        path: '/history', component: History,
        props: {
            loading: "true",
            url: "api/SearchEngine/GetHistory/"
        }
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
