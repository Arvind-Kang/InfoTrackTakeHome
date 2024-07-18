<script setup lang="ts">
    import Search from "./components/Search.vue";
    import InfoTrackBanner from "./components/InfoTrackBanner.vue";
</script>

<template>
    <div id="app">
        <InfoTrackBanner />
        <div class="nav-container">
            <BNav pills class="justify-content-center custom-nav">
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
        border-radius: 10px;
    }

        .nav-container .nav {
            border: none;
            border-radius: 5px;
        }

            .nav-container .nav .nav-item {
                margin: 0 10px;
            }

    .custom-nav .nav-link {
        color: #007bff;
        padding: 10px 20px;
        border-radius: 5px;
        transition: background-color 0.3s ease;
        font-weight: bold;
    }

        .custom-nav .nav-link.active {
            background-color: #007bff;
            color: #fff;
        }

        .custom-nav .nav-link:hover {
            background-color: #0056b3;
            color: #fff;
        }
</style>
