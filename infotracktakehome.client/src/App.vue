<script setup lang="ts">
    import Search from "./components/Search.vue";
    import InfoTrackBanner from "./components/InfoTrackBanner.vue";
</script>

<template>
    <div id="app">
        <InfoTrackBanner />
        <div class="nav-container">
            <BNav pills class="justify-content-center">
                <BNavItem :active="$route.path === '/search'" @click="$router.push('/search')">Search</BNavItem>
                <BNavItem :active="$route.path === '/history'" @click="$router.push('/history')">History</BNavItem>
            </BNav>
        </div>
        <router-view />
    </div>
</template>

<style scoped>
    .nav-container {
        display: flex;
        justify-content: center;
        margin: 20px 0;
    }

    .nav-container .nav {
        border: 1px solid #007bff;
        border-radius: 5px;
    }

    .nav-container .nav .nav-item {
        margin: 0 10px;
    }

        .nav-container .nav .nav-link {
            color: #007bff;
            padding: 10px 20px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

            .nav-container .nav .nav-link.active {
                background-color: #007bff;
                color: #fff;
            }

            .nav-container .nav .nav-link:hover {
                background-color: #0056b3;
                color: #fff;
            }
</style>
